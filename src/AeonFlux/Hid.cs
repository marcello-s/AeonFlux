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

    internal static class Hid
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct HidCaps
        {
            public short Usage;
            public short UsagePage;
            public short InputReportByteLength;
            public short OutputReportByteLength;
            public short FeatureReportByteLength;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
            public short[] Reserved;
            public short NumberLinkCollectionNodes;
            public short NumberInputButtonCaps;
            public short NumberInputValueCaps;
            public short NumberInputDataIndices;
            public short NumberOutputButtonCaps;
            public short NumberOutputValueCaps;
            public short NumberOutputDataIndices;
            public short NumberFeatureButtonCaps;
            public short NumberFeatureValueCaps;
            public short NumberFeatureDataIndices;
        }

        [DllImport("hid.dll", SetLastError = true)]
        internal static extern void HidD_GetHidGuid(
            out Guid hidGuid);

        [DllImport("hid.dll", SetLastError = true)]
        internal static extern bool HidD_GetPreparsedData(
            IntPtr handle,
            out IntPtr data);

        [DllImport("hid.dll", SetLastError = true)]
        internal static extern bool HidD_FreePreparsedData(
            ref IntPtr data);

        [DllImport("hid.dll", SetLastError = true)]
        internal static extern int HidP_GetCaps(
            IntPtr data,
            out HidCaps caps);
    }
}
