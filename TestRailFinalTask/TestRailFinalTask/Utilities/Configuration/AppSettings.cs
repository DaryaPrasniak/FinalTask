using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRailFinalTask.Utilities.Configuration
{
    public class AppSettings
    {
        private static AppSettings instance;

        private AppSettings() { }

        public static AppSettings GetInstance(IConfiguration configuration)
        {
            if (instance is null)
            {
                instance = new AppSettings();
                var child = configuration.GetSection("AppSettings");

                instance.URL = child["URL"];
            }

            return instance;
        }

        public string? URL { get; set; }
    }
}
