using DeviceApp.Services;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DeviceApp
{
    class Program
    {

       
                
        static void Main(string[] args)
        {
            DeviceServices.deviceClient.SetMethodHandlerAsync("SetTelemetryInterval", DeviceServices.SetTelemetryInterval, null).GetAwaiter();
            DeviceServices.SendMessageAsync().GetAwaiter();

            Console.ReadKey();
        
        }

            
            
        }

    }

