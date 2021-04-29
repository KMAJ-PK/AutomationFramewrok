using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebFramework
{
    public class SeleniumWait
    {
        private readonly Browser browser;

        public SeleniumWait(Browser browser)
        {
            this.browser = browser;
        }

        private static WebDriverWait Delay { get; set; }

        public IWebElement Until(Func<IWebDriver, IWebElement> element, double timeoutInSeconds = 60, double pollingIntervalSeconds = 0.5)
        {
            Delay = new WebDriverWait(browser.Driver, TimeSpan.FromSeconds(timeoutInSeconds))
            {
                PollingInterval = TimeSpan.FromSeconds(pollingIntervalSeconds)
            };
            return Delay.Until(element);
        }
    }
}
