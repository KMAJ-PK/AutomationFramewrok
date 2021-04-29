using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebFramework
{
    public class TextBox : Control
    {
        public TextBox(Browser browser, IWebElement element) : base(browser, element)
        {
        }

        public double Value
        {
            get
            {
                return Convert.ToDouble(Element.GetAttribute("value") ?? Element.Text);
            }
            set
            {
                ClearText();
                SendKeys(value.ToString());
                LoseFocus();
            }
        }

        public new string Text
        {
            get
            {
                return Element.GetAttribute("value") ?? Element.Text;
            }
            set
            {
                ClearText();
                SendKeys(value);
                LoseFocus();
            }
        }

        public void SendKeys(string inputText)
        {
            Element.SendKeys(inputText);
            LoseFocus();
        }

        public void ClearText()
        {
            AssertUITimeout.IsTrue(() =>
            {
                Element.SendKeys(Keys.Control + "a");
                Element.SendKeys(Keys.Delete);
                return Element.Text == "";
            });
        }

        public bool HasAttribute(string attribute)
        {
            var att = Element.GetAttribute(attribute);

            if (att != null)
                return true;

            return false;
        }
    }
}
