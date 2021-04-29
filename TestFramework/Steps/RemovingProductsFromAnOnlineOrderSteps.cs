using TechTalk.SpecFlow;
using WebFramework;

namespace TestFramework
{
    [Binding, Scope(Feature = "Removing Products FromAn Online Order")]
    public class RemovingProductsFromAnOnlineOrderSteps
    {
        private readonly AssertLogin assertLogin;
        private readonly LoginDriver loginDriver;

        public RemovingProductsFromAnOnlineOrderSteps(AssertLogin assertLogin, LoginDriver loginDriver)
        {
            this.assertLogin = assertLogin;
            this.loginDriver = loginDriver;
        }

        [Given(@"that I am on the basket page with multiple items in it")]
        [Given(@"that I have multiple items in my basket")]
        [Given(@"that I am on the inventory page with items in my basket")]
        public void GivenThatIAmOnTheInventoryPageWithItemsInMyBasket()
        {
            loginDriver.AddToCartSourceLabsBackpackButton.Click();
            loginDriver.AddToCartSauceLabsBikeLightButton.Click();
            assertLogin.BasketHasItems("2");
        }
        
        [Given(@"that I am on the basket page with an item in it")]
        public void GivenThatIAmOnTheBasketPageWithAnItemInIt()
        {
            loginDriver.AddToCartSourceLabsBackpackButton.Click();
        }

        [When(@"I click to 'Remove' a product")]
        [When(@"I click 'Remove' on an item I have in my basket")]
        public void WhenIClickOnAnItemIHaveInMyBasket()
        {
            loginDriver.RemoveSauceLabsBackpack.Click();
        }
        
        [When(@"I visit the basket page")]
        public void WhenIVisitTheBasketPage()
        {
            loginDriver.BasketButton.Click();
        }
        
        [Then(@"it will change the 'Remove' button to 'Add to cart'")]
        public void ThenItWillChangeTheButtonTo()
        {
            loginDriver.AddToCartSourceLabsBackpackButton.Enabled();
        }
        
        [Then(@"it will reduce the basket counter icon accordingly")]
        public void ThenItWillReduceTheBasketCounterIconAccordingly()
        {
            assertLogin.BasketHasItems("1");
        }
        
        [Then(@"I can see options to remove each product present from the basket")]
        public void ThenICanSeeOptionsToRemoveEachProductPresentFromTheBasket()
        {
            assertLogin.CartContainerIsAvailable();
            loginDriver.RemoveSauceLabsBackpack.Enabled();
            loginDriver.RemoveSauceLabsBikeLightsButton.Enabled();
        }
        
        [Then(@"it will remove the item from the basket")]
        public void ThenItWillRemoveTheItemFromTheBasket()
        {
            loginDriver.RemoveSauceLabsBackpack.Visible.Equals(false);
        }
        
        [Then(@"it will reduce the basket counter icon by (.*)")]
        public void ThenItWillReduceTheBasketCounterIconBy(int count)
        {
            assertLogin.BasketHasItems(count.ToString());
        }
        
        [Then(@"it will remove the basket counter icon")]
        public void ThenItWillRemoveTheBasketCounterIcon()
        {
            assertLogin.BasketIsEmpty();
        }
    }
}
