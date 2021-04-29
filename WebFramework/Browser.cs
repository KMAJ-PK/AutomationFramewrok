using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace WebFramework
{
    public class Browser
    {
        private IWebDriver webDriver;
        private readonly Uri baseUrl;
        private readonly WebDriverfactory webDriverfactory;

        public Browser(WebDriverfactory webDriverfactory, TestRunConfiguration testRunConfiguration)
        {
            this.webDriverfactory = webDriverfactory;

            if (!FeatureContext.Current.TryGetValue(out webDriver))
            {
                if (FeatureContext.Current.FeatureInfo.Tags.Contains("BrowserSafari"))
                {
                    testRunConfiguration.BrowserType = "Safari";
                }

                else if (FeatureContext.Current.FeatureInfo.Tags.Contains("BrowserFirefox"))
                {
                    testRunConfiguration.BrowserType = "firefox";
                }

                else
                {
                    testRunConfiguration.BrowserType = "chrome";
                }

                CreateWebDriver();
                FeatureContext.Current.Set(webDriver);
            }

            this.baseUrl = testRunConfiguration.BaseURL;
            AssertUITimeout.Browser = this;
        }

        public IWebDriver Driver => webDriver;

        public Uri BaseUrl => baseUrl;

        public string WindowHandle
        {
            set => Driver.SwitchTo().Window(value);
        }

        public void NavigateTo(string address)
        {
            var currentPage = OnRequestedPage(address);

            if (currentPage) return;

            GoToUrl(address);
            if (address.Contains("saucedemo"))
            {
                try
                {
                    WaitForLogin();
                }
                catch (Exception)
                {
                    LogDebugMessage("Unable to find Waters logo. Attempting to recreate the web driver.");
                    Thread.Sleep(10000);
                    webDriver = webDriverfactory.CreateWebDriver();
                    FeatureContext.Current.Set(webDriver);
                    Driver.Navigate().GoToUrl(GetUrl(address));
                    WaitForLogin();
                }
            }
        }

        public bool OnRequestedPage(string address)
        {
            var currentPage = false;
            try
            {
                currentPage = Driver.Url.Contains(address);
            }
            catch (Exception e)
            {
                LogDebugMessage("Unable to request url");
                Console.WriteLine(e);
            }

            return currentPage;
        }

        public void Refresh()
        {
            webDriver.Navigate().Refresh();
        }

        private void WaitForLogin(int timeoutInSeconds = 20)
        {
            try
            {
                var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementExists(By.Id("login_button_container")));
            }
            catch (Exception)
            {
                Assert.Fail($"[AUTOMATION] - {DateTime.Now.ToUniversalTime()} - Unable to find Login after {timeoutInSeconds} seconds");
            }
        }

        private void GoToUrl(string address)
        {
            int maxAttempt = 2;
            for (int i = 1; i <= maxAttempt; i++)
            {
                try
                {
                    Driver.Navigate().GoToUrl(GetUrl(address));
                    break;
                }
                catch (Exception e)
                {
                    LogDebugMessage($"Attempt {i} - Unable to load url {address}");

                    if (i == maxAttempt) throw e;

                    // Recreate the web driver
                    webDriver.Quit();
                    CreateWebDriver();
                    FeatureContext.Current.Set(webDriver);
                }
            }
        }

        private Uri GetUrl(string path)
        {
            return new Uri(BaseUrl, path);
        }

        private void LogDebugMessage(string message)
        {
            Console.WriteLine($"[AUTOMATION] - {DateTime.Now.ToUniversalTime()} - {message}");
        }

        private void CreateWebDriver()
        {
            int maxAttempt = 20;
            for (int i = 1; i <= maxAttempt; i++)
            {
                try
                {
                    LogDebugMessage($"Attempt {i} to create the web driver");
                    this.webDriver = webDriverfactory.CreateWebDriver();
                    break;
                }
                catch (Exception e)
                {
                    LogDebugMessage("Exception occurred when creating the web driver");
                    Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);

                    try
                    {
                        foreach (var process in Process.GetProcessesByName("chrome"))
                        {
                            Console.WriteLine("Killing process " + process.ProcessName);
                            process.Kill();
                        }

                        foreach (var process in Process.GetProcessesByName("chromedriver"))
                        {
                            Console.WriteLine("Killing process " + process.ProcessName);
                            process.Kill();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Something went wrong killing chrome or chromedriver processes");
                    }

                    if (i == maxAttempt) throw;
                }
            }
        }
    }
}
