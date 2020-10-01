using System;
using Xunit;
using DeviceApp.Services;

using Microsoft.Azure.Devices.Client;
using Microsoft.VisualStudio.TestPlatform.Common;
using System.Text;

namespace DeviceAppTest
{
    public class StatusCodeTest2
    {
        public DeviceClient deviceClient = DeviceClient.CreateFromConnectionString("HostName=ecwin20-iothub.azure-devices.net;DeviceId=DeviceApp;SharedAccessKey=2ckDw25bKM0kQaM7e9ohZ+T8WKhVoUz/+AMkGTEHY5c=", TransportType.Mqtt);

        
        [Fact]   
      
        public void SetTelemetryInterval_ShouldShowReturnStatusCodeBadRequest()
        {
            var array = Encoding.UTF8.GetBytes("A");
            var response = DeviceServices.SetTelemetryInterval(new MethodRequest("SetTelemetryInterval", array), null).GetAwaiter().GetResult();
            Assert.Equal(400, response.Status);
           
        }
    }
}
