using Microsoft.Azure.Devices.Client;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DeviceApp
{
    class Program
    {

        private static DeviceClient deviceClient = DeviceClient.CreateFromConnectionString("HostName=ecwin20-iothub.azure-devices.net;DeviceId=DeviceApp;SharedAccessKey=2ckDw25bKM0kQaM7e9ohZ+T8WKhVoUz/+AMkGTEHY5c=", TransportType.Mqtt);
        private static int telemetryInterval = 5; 
        
        
        static void Main(string[] args)
        {
        
        }

        private static Task<MethodResponse> SetTelemetryInterval(MethodRequest request, object userContext)
        {
            var payload = Encoding.UTF8.GetString(request.Data); 

            if(Int32.TryParse(payload, out telemetryInterval))
            {

            }
            else
            {

            }


        }
    }
}
