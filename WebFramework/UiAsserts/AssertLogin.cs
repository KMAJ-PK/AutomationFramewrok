using System;

namespace WebFramework
{
    public class AssertLogin
    {
        private readonly Browser browser;
        private readonly ControlFactory controlFactory;
        private readonly NavigationDriver navigationDriver;

        public AssertLogin(Browser browser, ControlFactory controlFactory, NavigationDriver navigationDriver)
        {
            this.browser = browser;
            this.controlFactory = controlFactory;
            this.navigationDriver = navigationDriver;
        }

        public void LoginFailedWithError(string errorMessage)
        {
            AssertUITimeout.IsTrue(() => controlFactory.FindElementByClass("error-message-container error").Text == errorMessage, $"Failed to find the message: { errorMessage }");
        }

        public void RequestedPageIsLoaded(string address)
        {
            AssertUITimeout.IsTrue(() => navigationDriver.VerifyTheRequestedPage(address), $"Failed to find the requested page { address }");
        }

        public void BasketIsEmpty()
        {
            AssertUITimeout.IsFalse(() => controlFactory.FindElementByClass("shopping_cart_badge").Displayed, "Basket is not empty");
        }

        public void BasketHasItems(string value)
        {
            AssertUITimeout.IsTrue(() => controlFactory.FindElementByClass("shopping_cart_badge").Text == value, "Count of products don't match");
        }

        public void CartContainerIsAvailable()
        {
            AssertUITimeout.IsTrue(() => controlFactory.FindElementById("cart_contents_container").Displayed, "Cart container is not displayed");
        }

        public void IsActiveInput(TextBox input)
        {
            AssertUITimeout.IsTrue(() => input.Equals(browser.Driver.SwitchTo().ActiveElement()), "Failed to Switch to Active Input");
        }

        public void IsActiveButton(Button loginButton)
        {
            AssertUITimeout.IsTrue(() => loginButton.Equals(browser.Driver.SwitchTo().ActiveElement()), "Failed to Switch to Active Button");
        }
    }
}
