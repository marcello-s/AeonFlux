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
    using System.Text;

    internal class MakeyMakeyDevice : HidDevice
    {
        internal const int VID = 0x2341;
        internal const int PID = 0x8036;

        public MakeyMakeyDevice()
        {
            DataReceivedHandler = DataHandler;
        }

        protected void DataHandler(byte[] buffer)
        {
#if DEBUG
            var dataString = string.Empty;
            foreach (var b in buffer)
            {
                dataString += dataString.Length > 0 ? "," : string.Empty;
                dataString += string.Format("{0:x2}", b);
            }
            System.Diagnostics.Debug.WriteLine("bytes: " + dataString);
#endif

        }
    }
}
