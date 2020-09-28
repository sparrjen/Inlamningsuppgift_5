using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DeviceApp
{
    class Program
    {

        private static DeviceClient deviceClient = DeviceClient.CreateFromConnectionString("HostName=ecwin20-iothub.azure-devices.net;DeviceId=DeviceApp;SharedAccessKey=2ckDw25bKM0kQaM7e9ohZ+T8WKhVoUz/+AMkGTEHY5c=", TransportType.Mqtt);
        private static int telemetryInterval = 5;
        private static Random rnd = new Random(); 
        
        
        static void Main(string[] args)
        {
            deviceClient.SetMethodHandlerAsync("SetTelemetryInterval", SetTelemetryInterval, null).GetAwaiter();
            SendMessageAsync().GetAwaiter();

            Console.ReadKey();
        
        }

        private static Task<MethodResponse> SetTelemetryInterval(MethodRequest request, object userContext)
        {
            var payload = Encoding.UTF8.GetString(request.Data);

            if (Int32.TryParse(payload, out telemetryInterval))
            {
                Console.WriteLine($"Interval set to: {telemetryInterval} seconds.");

                string json = "{\"result\": \"Executed direct method: " + request.Name +"\"}";                                
                return Task.FromResult(new MethodResponse(Encoding.UTF8.GetBytes(json), 200));
            }
            else
            {
                string json = "{\"result\": \"Invalid method\"}";
                return Task.FromResult(new MethodResponse(Encoding.UTF8.GetBytes(json), 400));
            }


        }

        private static async Task SendMessageAsync()           
        {
            while(true)
            {
                double temp = 10 + rnd.NextDouble() * 15;
                double hum = 40 + rnd.NextDouble() * 20;
                var data = new

                {
                    temperature = temp,
                    humidity = hum

                };

                var json = JsonConvert.SerializeObject(data);
                var payload = new Message(Encoding.UTF8.GetBytes(json));
                payload.Properties.Add("temperatureAlert", (temp > 30) ? "true" : "false");

                await deviceClient.SendEventAsync(payload);

                Console.WriteLine($"Message sent: {json}");

                await Task.Delay(telemetryInterval * 1000);

            }

            
            
        }

    }
}
