using System;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using Microsoft.Win32;

namespace WebFramework
{
    public class TestRunConfiguration
    {
        public string TestDataDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                    Path.DirectorySeparatorChar + "testdata" + Path.DirectorySeparatorChar;

        private string browserType;
        private string environment;

        public string BrowserType
        {
            get
            {
                if (string.IsNullOrEmpty(browserType))
                    return Environment.GetEnvironmentVariable("BROWSER_TYPE") ?? "chrome";

                return browserType;
            }

            set => browserType = value;
        }

        public string TestEnvironment
        {
            get
            {
                if (string.IsNullOrEmpty(environment))
                    return Environment.GetEnvironmentVariable("TEST_ENVIRONMENT") ?? "local";

                return environment;
            }

            set => environment = value;
        }

        public Uri BaseURL
        {
            get
            {
                return new Uri($"https://www.saucedemo.com/");
            }
        }

        public string ChromeVersion
        {
            get
            {
                var path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe", "", null)?.ToString();
                var chromeVersion = path != null ? FileVersionInfo.GetVersionInfo(path).ProductVersion : "Latest";

                return chromeVersion;
            }
        }
    }
}
