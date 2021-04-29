using OpenQA.Selenium;
using System;

namespace WebFramework
{
    public class Button : Control
    {
        public Button(Browser browser, IWebElement element) : base(browser, element)
        {
        }

        public void Click(Action expectedConditionAfterClick)
        {
            int numOfAttempts = 1;
            int maxAttempts = 3;

            while (numOfAttempts <= maxAttempts)
            {
                try
                {
                    base.Element.Click();

                    expectedConditionAfterClick();
                    break;
                }
                catch (Exception)
                {
                    numOfAttempts++;

                    if (numOfAttempts >= maxAttempts)
                        throw;
                }
            }
        }


    }
}
