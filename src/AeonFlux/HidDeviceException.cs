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

    public class HidDeviceException : Exception
    {
        public HidDeviceException(string message)
            : base(message)
        { }

        public HidDeviceException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public static HidDeviceException CreateWithWin32Error(string message)
        {
            return new HidDeviceException(string.Format("Msg:{0} Win32Err:{1:X8}", message, Marshal.GetLastWin32Error()));
        }
    }
}
