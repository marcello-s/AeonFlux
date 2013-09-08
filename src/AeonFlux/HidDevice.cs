#region license and copyright
/*
 * The MIT License, Copyright (c) 2013 Marcel Schneider
 * for details see License.txt
 */
#endregion
        
namespace AeonFlux
{
    using System;
    using System.IO;

    internal class HidDevice : UsbDevice
    {
        internal static Guid ClassGuid
        {
            get
            {
                Guid hidGuid;
                Hid.HidD_GetHidGuid(out hidGuid);
                return hidGuid;
            }
        }

        protected override void Initialize(string devicePath)
        {
            _handle = Kernel32.CreateFile(
                devicePath, 
                Kernel32.GENERIC_READ | Kernel32.GENERIC_WRITE, 
                0, 
                IntPtr.Zero, 
                Kernel32.OPEN_EXISTING, 
                Kernel32.FILE_FLAG_OVERLAPPED, 
                IntPtr.Zero);
            if (!_handle.IsInvalid)
            {
                IntPtr data;
                if (Hid.HidD_GetPreparsedData(_handle.DangerousGetHandle(), out data))
                {
                    try
                    {
                        Hid.HidCaps caps;
                        Hid.HidP_GetCaps(data, out caps);
                        _inputBufferLength = caps.InputReportByteLength;
                        _outputBufferLength = caps.OutputReportByteLength;
                        _fs = new FileStream(_handle, FileAccess.ReadWrite, _inputBufferLength, true);
                        BeginAsyncRead();
                    }
                    finally
                    {
                        Hid.HidD_FreePreparsedData(ref data);
                    }
                }
                else
                {
                    throw HidDeviceException.CreateWithWin32Error("HidD_GetPreparsedData failed.");
                }
            }
            else
            {
                _handle.SetHandleAsInvalid();
                throw HidDeviceException.CreateWithWin32Error("Failed to initialize device file handle.");
            }
        }
    }
}
