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
    using Xunit;

    public class MakeyMakeyDeviceTests
    {
        private MakeyMakeyDevice _makeyMakeyDevice;

        [Fact]
        public void CreateDevice_WhenConnected_ThenInstanceCanBeCreated()
        {
            _makeyMakeyDevice = UsbDevice.CreateDevice(
                HidDevice.ClassGuid, 
                MakeyMakeyDevice.VID, 
                MakeyMakeyDevice.PID, 
                typeof (MakeyMakeyDevice)) as MakeyMakeyDevice;
            Assert.IsAssignableFrom<MakeyMakeyDevice>(_makeyMakeyDevice);

            // keep connection for about 10s
            Console.WriteLine("MakeyMakey device connected, touch buttons during 10s..");
            for (var i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(100);
            }

            _makeyMakeyDevice.Dispose();
        }
    }
}
