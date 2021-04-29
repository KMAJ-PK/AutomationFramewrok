namespace WebFramework
{
    public class LoginDriver
    {
        private readonly ControlFactory controlFactory;

        public LoginDriver(ControlFactory controlFactory)
        {
            this.controlFactory = controlFactory;
        }

        public Button LoginButton => controlFactory.CreateButton("login-button");

        public Button BasketButton => controlFactory.CreateButton("shopping_cart_container");

        public Button AddToCartSourceLabsBackpackButton => controlFactory.CreateButton("add-to-cart-sauce-labs-backpack");

        public Button RemoveSauceLabsBackpack => controlFactory.CreateButton("remove-sauce-labs-backpack");

        public Button AddToCartSauceLabsBikeLightButton => controlFactory.CreateButton("add-to-cart-sauce-labs-bike-light");

        public Button RemoveSauceLabsBikeLightsButton => controlFactory.CreateButton("remove-sauce-labs-bike-light");

        public TextBox UserNameTextBox => controlFactory.CreateTextBox("user-name");

        public TextBox PasswordTextBox => controlFactory.CreateTextBox("password");

    }
}
