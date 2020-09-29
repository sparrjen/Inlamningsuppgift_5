using System;
using Xunit;
using DeviceApp.Services;

using Microsoft.Azure.Devices.Client;

namespace DeviceAppTest
{
    public class SetTelemetryIntervalTests
    {
        public DeviceClient deviceClient = DeviceClient.CreateFromConnectionString("HostName=ecwin20-iothub.azure-devices.net;DeviceId=DeviceApp;SharedAccessKey=2ckDw25bKM0kQaM7e9ohZ+T8WKhVoUz/+AMkGTEHY5c=", TransportType.Mqtt);

        [Theory]   
        [InlineData("SetTelemetryInterval", "10", 200)]
        [InlineData("SetInterval", "10", 501)]
        public void SetTelemetryInterval_ShouldChangeTelemetryInterval(string methodName, string payload, int statusCode)
        {
            deviceClient.SetMethodHandlerAsync(methodName, DeviceServices.SetTelemetryInterval, null).Wait();
           
        }
    }
}
