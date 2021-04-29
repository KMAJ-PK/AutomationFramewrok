using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebFramework
{
    public class Control
    {
        protected Browser browser;
        public IWebElement Element;

        public virtual string Text => Element.Text;

        public Control(Browser browser, IWebElement element)
        {
            Element = element;
            this.browser = browser;
        }


        public virtual void Click()
        {
            var wait = new WebDriverWait(browser.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(Element));
            Element.Click();
        }

        public virtual bool Enabled()
        {
            return Element.Enabled;
        }

        public void LoseFocus()
        {
            ((IJavaScriptExecutor)browser.Driver).ExecuteScript(ClientSideScripts.LoseFocus, Element);
        }

        public bool Visible
        {
            get
            {
                return Element.Displayed;
            }
        }

        public bool Hidden
        {
            get { return !Element.Displayed; }
        }
    }
}
