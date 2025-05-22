using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace AudioControl
{
    public static class AppSettings
    {
        private const string Esp32IpKey = "Esp32Ip";
        private const string DefaultIp = "http://192.168.1.42"; // fallback

        public static string Esp32Ip
        {
            get => Preferences.Get(Esp32IpKey, DefaultIp);
            set => Preferences.Set(Esp32IpKey, value);
        }
    }
}
