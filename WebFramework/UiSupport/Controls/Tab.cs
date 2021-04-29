using OpenQA.Selenium;

namespace WebFramework
{
    public class Tab : Control
    {
        public string Name { get { return Element.Text; } }

        public Tab(Browser browser, IWebElement element) : base(browser, element)
        {
        }

        public void Rename(string name)
        {
            //TODO: Need a better way to ensure the double click has worked
            IWebElement renameTextBox;
            try
            {
                Element.DoubleClick(browser.Driver);
                renameTextBox = Element.FindElement(By.TagName("input"));
            }
            catch (NoSuchElementException)
            {
                Element.DoubleClick(browser.Driver);
                renameTextBox = Element.FindElement(By.TagName("input"));
            }

            renameTextBox.SendKeys(Keys.Control + "a");
            renameTextBox.SendKeys(Keys.Delete);
            renameTextBox.SendKeys(name);
            renameTextBox.LoseFocus(browser.Driver);
        }
    }
}
