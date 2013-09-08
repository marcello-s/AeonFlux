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
    using Microsoft.Win32.SafeHandles;

    internal static class Kernel32
    {
        internal const uint GENERIC_READ = 0x80000000;
        internal const uint GENERIC_WRITE = 0x40000000;
        internal const uint FILE_FLAG_OVERLAPPED = 0x40000000;
        internal const uint OPEN_EXISTING = 3;

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern SafeFileHandle CreateFile(
            [MarshalAs(UnmanagedType.LPStr)] string name,
            uint access,
            uint shareMode,
            IntPtr security,
            uint creationFlags,
            uint attributes,
            IntPtr template);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int CloseHandle(
            SafeFileHandle handle);
    }
}
