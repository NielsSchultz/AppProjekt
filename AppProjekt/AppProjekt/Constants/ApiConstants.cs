using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppProjekt.Constants
{
    public static class ApiConstants
    {
        //public static string BaseApiUrl = Device.RuntimePlatform == Device.Android ? "https://api.thingspeak.com/channels" : "https://localhost:5001/";
        //public const string TelemetricsEndpoint = "/1321079/feeds.json?results=10";
        public static string BaseApiUrl = Device.RuntimePlatform == Device.Android ? "https://api.thingspeak.com" : "https://localhost:5001/";
       
        public const string TelemetricsEndpoint = "/1321079/feeds.json?results=10";
    }
}
