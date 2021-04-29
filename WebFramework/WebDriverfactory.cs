using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;
using System.IO;
using System.Net;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace WebFramework
{
    public class WebDriverfactory
    {
        private readonly TestRunConfiguration testRunConfiguration;

        public WebDriverfactory(TestRunConfiguration testRunConfiguration)
        {
            this.testRunConfiguration = testRunConfiguration;
        }

        private void SetupWebDriverManager(string environment)
        {
            switch (environment)
            {
                case "local":
                    if (testRunConfiguration.ChromeVersion == "Latest")
                    {
                        new DriverManager().SetUpDriver(new ChromeConfig(), testRunConfiguration.ChromeVersion);
                    }
                    else
                    {
                        new DriverManager().SetUpDriver(new ChromeConfig(), GetMatchingChromeDriverVersion());
                    }

                    break;
                case "docker":
                    break;
                default:
                    throw new NotImplementedException($"{environment} test environment is not currently supported");
            }
        }

        private string GetMatchingChromeDriverVersion()
        {
            var endIndex = testRunConfiguration.ChromeVersion.LastIndexOf(".", StringComparison.Ordinal);
            var majorChromeVersion = testRunConfiguration.ChromeVersion.Substring(0, endIndex);

            var uri = new Uri($"https://chromedriver.storage.googleapis.com/LATEST_RELEASE_{majorChromeVersion}");
            var webRequest = WebRequest.Create(uri);
            using (var response = webRequest.GetResponse())
            {
                using (var content = response.GetResponseStream())
                {
                    if (content == null) throw new ArgumentNullException($"Can't get content from URL: {uri}");
                    using (var reader = new StreamReader(content))
                    {
                        var version = reader.ReadToEnd().Trim();
                        return version;
                    }
                }
            }
        }

        public IWebDriver CreateWebDriver()
        {
            Console.WriteLine($"********  {testRunConfiguration.BrowserType.ToLowerInvariant()} **********");
            IWebDriver driver;

            SetupWebDriverManager(testRunConfiguration.TestEnvironment);

            switch (testRunConfiguration.BrowserType.ToLowerInvariant())
            {
                case "safari":
                    driver = new SafariDriver(new SafariOptions());
                    break;
                case "firefox":
                    driver = new FirefoxDriver(new FirefoxOptions());
                    break;
                case "chrome":
                    driver = new ChromeDriver(new ChromeOptions());
                    break;
                default:
                    throw new NotImplementedException("Browser not currently supported");
            }

            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromMinutes(2.0);
            driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(60));

            return driver;
        }
    }
}
