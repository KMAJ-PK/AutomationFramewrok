using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebFramework
{
    public class ControlFactory
    {
        private Browser browser;
        private SeleniumWait wait;

        public ControlFactory(Browser browser, SeleniumWait wait)
        {
            this.browser = browser;
            this.wait = wait;
        }

        private IWebElement GetElement(string id)
        {
            IWebElement element = null;
            try
            {
                element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
            }
            catch (WebDriverTimeoutException timeoutException)
            {
                Assert.Fail($"Timeout retrieving web element {id} with exception {timeoutException}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Error retrieving web element {id} with exception {ex}");
            }

            return element;
        }

        private IWebElement GetElementByClass(string className)
        {
            IWebElement element = null;
            try
            {
                element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(className)));
            }
            catch (WebDriverTimeoutException timeoutException)
            {
                Assert.Fail($"Timeout retrieving web element {className} with exception {timeoutException}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Error retrieving web element {className} with exception {ex}");
            }

            return element;
        }

        public bool IsElementVisible(string id, double timeoutInSeconds = 2)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)), timeoutInSeconds);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public Button CreateButton(string id)
        {
            return new Button(browser, GetElement(id));
        }

        public TextBox CreateTextBox(string id)
        {
            return new TextBox(browser, GetElement(id));
        }

        public Tab CreateTab(string id)
        {
            return new Tab(browser, GetElement(id));
        }

        public Label CreateLabel(string id)
        {
            return new Label(browser, GetElement(id));
        }

        public IWebElement FindElementById(string id)
        {
            return GetElement(id);
        }

        public IWebElement FindElementByClass(string classname)
        {
            return GetElementByClass(classname);
        }

    }
}
