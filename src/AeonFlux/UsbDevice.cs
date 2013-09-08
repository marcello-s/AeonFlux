#region license and copyright
/*
 * The MIT License, Copyright (c) 2013 Marcel Schneider
 * for details see License.txt
 */
#endregion
        
namespace AeonFlux
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;

    internal abstract class UsbDevice : IDisposable
    {
        protected SafeFileHandle _handle;
        protected int _inputBufferLength;
        protected int _outputBufferLength;
        protected FileStream _fs;

        public Action<IOException> DeviceRemovedHandler = ex => { };
        protected Action<byte[]> DataReceivedHandler = buffer => { };

        ~UsbDevice()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_fs != null)
            {
                _fs.Close();
                _fs = null;
            }
            if (_handle != null && !_handle.IsClosed)
                Kernel32.CloseHandle(_handle);
        }

        private static string GetDevicePath(IntPtr infoSet, ref SetupApi.DeviceInterfaceData interfaceData)
        {
            uint requiredSize = 0;
            if (!SetupApi.SetupDiGetDeviceInterfaceDetail(
                infoSet, 
                ref interfaceData, 
                IntPtr.Zero, 
                0, 
                ref requiredSize, 
                IntPtr.Zero))
            {
                var detailData = new SetupApi.DeviceInterfaceDetailData();
                detailData.Size = Environment.Is64BitProcess ? 8 : 5;
                if (SetupApi.SetupDiGetDeviceInterfaceDetail(
                    infoSet,
                    ref interfaceData,
                    ref detailData,
                    requiredSize,
                    ref requiredSize,
                    IntPtr.Zero))
                {
                    return detailData.DevicePath;                    
                }
            }
            return null;
        }

        public static IEnumerable<string> Enumerate(Guid classGuid)
        {
            var devicePathList = new List<string>();
            var infoSet = SetupApi.SetupDiGetClassDevs(
                ref classGuid, 
                null, 
                IntPtr.Zero, 
                SetupApi.DIGCF_PRESENT | SetupApi.DIGCF_DEVICEINTERFACE);

            var interfaceData = new SetupApi.DeviceInterfaceData();
            interfaceData.Size = Marshal.SizeOf(interfaceData);

            try
            {
                var index = 0;
                while (SetupApi.SetupDiEnumDeviceInterfaces(infoSet, 0, ref classGuid, (uint)index, ref interfaceData))
                {
                    devicePathList.Add(GetDevicePath(infoSet, ref interfaceData));
                    index++;
                }
            }
            finally
            {
                SetupApi.SetupDiDestroyDeviceInfoList(infoSet);
            }
            return devicePathList;
        }

        public static object CreateDevice(Guid classGuid, int vid, int pid, Type deviceType)
        {
            var vendorProduct = string.Format("vid_{0:x4}&pid_{1:x4}", vid, pid);
            var devicePath = Enumerate(classGuid).FirstOrDefault(d => d.IndexOf(vendorProduct) >= 0);
            if (!string.IsNullOrEmpty(devicePath))
            {
                var usbDevice = (UsbDevice)Activator.CreateInstance(deviceType);
                usbDevice.Initialize(devicePath);
                return usbDevice;
            }
            return null;
        }

        protected abstract void Initialize(string devicePath);

        protected virtual void BeginAsyncRead()
        {
            var buffer = new byte[_inputBufferLength];
            _fs.BeginRead(buffer, 0, _inputBufferLength, ReadCompleted, buffer);
        }

        protected virtual void ReadCompleted(IAsyncResult result)
        {
            var buffer = result.AsyncState as byte[];
            try
            {
                _fs.EndRead(result);
                try
                {
                    DataReceivedHandler(buffer);
                }
                finally
                {
                    BeginAsyncRead();
                }
            }
            catch (IOException ex)
            {
                DeviceRemovedHandler(ex);
                Dispose();
            }
        }

        protected virtual void Write(byte[] buffer)
        {
            _fs.Write(buffer, 0, _outputBufferLength);
        }
    }
}
