using System;
using TechTalk.SpecFlow;
using WebFramework;

namespace TestFramework
{
    [Binding, Scope(Feature = "Building UpOnline Order")]
    public class BuildingUpOnlineOrderSteps
    {
        private readonly AssertLogin assertLogin;
        private readonly LoginDriver loginDriver;

        public BuildingUpOnlineOrderSteps(AssertLogin assertLogin, LoginDriver loginDriver)
        {
            this.assertLogin = assertLogin;
            this.loginDriver = loginDriver;
        }

        [Given(@"that I am on the inventory shop page with an empty basket")]
        public void GivenThatIAmOnTheInventoryShopPageWithAnEmptyBasket()
        {
            assertLogin.BasketIsEmpty();
        }
        
        [Given(@"that I am on the inventory shop page with an item in my basket")]
        public void GivenThatIAmOnTheInventoryShopPageWithAnItemInMyBasket()
        {
            loginDriver.AddToCartSourceLabsBackpackButton.Click();
        }
        
        [When(@"I click 'Add to cart' on a product")]
        public void WhenIClickOnAProduct()
        {
            loginDriver.AddToCartSourceLabsBackpackButton.Click();
        }
        
        [When(@"I click 'Add to cart' on a different product")]
        public void WhenIClickAddToCartOnAProduct()
        {
            loginDriver.AddToCartSauceLabsBikeLightButton.Click();
        }
        
        [Then(@"it will change the '(.*)' button to a '(.*)' button")]
        public void ThenItWillChangeTheButtonToAButton(string p0, string p1)
        {
            loginDriver.RemoveSauceLabsBackpack.Enabled();
        }
        
        [Then(@"it creates a counter on the basket icon with the value '(.*)' in it")]
        public void ThenItCreatesACounterOnTheBasketIconWithTheValueInIt(string count)
        {
            assertLogin.BasketHasItems(count);
        }
        
        [Then(@"it will increment the basket counter by (.*)")]
        public void ThenItWillIncrementTheBasketCounterBy(int count)
        {
            assertLogin.BasketHasItems((count + 1).ToString());
        }
    }
}
