using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WebFramework
{
    public static class IWebElementExtensions
    {
        public static void DoubleClick(this IWebElement element, IWebDriver driver)
        {
            new Actions(driver).DoubleClick(element).Perform();
        }

        public static void LoseFocus(this IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].blur();", element);
        }
    }
}
