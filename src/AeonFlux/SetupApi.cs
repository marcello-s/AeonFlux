#region license and copyright
/*
 * The MIT License, Copyright (c) 2013 Marcel Schneider
 * for details see License.txt
 */
#endregion
        
namespace AeonFlux
{
    using System;
    using System.Runtime.InteropServices;

    internal static class SetupApi
    {
        internal const int DIGCF_PRESENT = 0x02;
        internal const int DIGCF_DEVICEINTERFACE = 0x10;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct DeviceInterfaceData
        {
            internal int Size;
            internal Guid InterfaceClassGuid;
            internal int Flags;
            internal int Reserved;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct DeviceInterfaceDetailData
        {
            internal int Size;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] 
            internal readonly string DevicePath;
        }

        [DllImport("setupapi.dll", SetLastError = true)]
        internal static extern IntPtr SetupDiGetClassDevs(
            ref Guid classGuid,
            [MarshalAs(UnmanagedType.LPStr)] string enumerator,
            IntPtr parent,
            uint flags);

        [DllImport("setupapi.dll", SetLastError = true)]
        internal static extern int SetupDiDestroyDeviceInfoList(
            IntPtr infoSet);

        [DllImport("setupapi.dll", SetLastError = true)]
        internal static extern bool SetupDiEnumDeviceInterfaces(
            IntPtr infoSet,
            uint infoData,
            ref Guid classGuid,
            uint index,
            ref DeviceInterfaceData interfaceData);

        [DllImport("setupapi.dll", SetLastError = true)]
        internal static extern bool SetupDiGetDeviceInterfaceDetail(
            IntPtr infoSet,
            ref DeviceInterfaceData interfaceData,
            IntPtr interfaceDetailData,
            uint interfaceDetailDataSize,
            ref uint requiredSize,
            IntPtr deviceInfoData);

        [DllImport("setupapi.dll", SetLastError = true)]
        internal static extern bool SetupDiGetDeviceInterfaceDetail(
            IntPtr infoSet,
            ref DeviceInterfaceData interfaceData,
            ref DeviceInterfaceDetailData detailData,
            uint interfaceDetailDataSize,
            ref uint requieredSize,
            IntPtr deviceInfoData);
    }
}
