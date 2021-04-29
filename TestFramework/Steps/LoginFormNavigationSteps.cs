using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using WebFramework;

namespace TestFramework
{
    [Binding, Scope(Feature = "Login Form Navigation")]
    public class LoginFormNavigationSteps
    {
        private readonly AssertLogin assertLogin;
        private readonly LoginDriver loginDriver;

        public LoginFormNavigationSteps(AssertLogin assertLogin, LoginDriver loginDriver)
        {
            this.assertLogin = assertLogin;
            this.loginDriver = loginDriver;
        }

        [Given(@"that I am currently focused on the username field")]
        public void GivenThatIAmCurrentlyFocusedOnTheUsernameField()
        {
            loginDriver.UserNameTextBox.Click();
        }
        
        [Given(@"that I am currently focused on the password field")]
        public void GivenThatIAmCurrentlyFocusedOnThePasswordField()
        {
            loginDriver.PasswordTextBox.Click();
        }
        
        [Given(@"that I have the submit button in focus")]
        public void GivenThatIHaveTheSubmitButtonInFocus()
        {
            loginDriver.PasswordTextBox.Click();
            loginDriver.PasswordTextBox.SendKeys(Keys.Tab);
        }
        
        [When(@"I hit the tab key on username field")]
        public void WhenIHitTheTabKeyOnUsernameField()
        {
            loginDriver.UserNameTextBox.SendKeys(Keys.Tab);
        }

        [When(@"I hit the tab key on password field")]
        public void WhenIHitTheTabKeyOnPasswordField()
        {
            loginDriver.PasswordTextBox.SendKeys(Keys.Tab);
        }

        [When(@"I hit the enter key")]
        public void WhenIHitTheEnterKey()
        {
            loginDriver.LoginButton.Element.SendKeys(Keys.Enter);
        }
        
        [Then(@"it will take me to the password field")]
        public void ThenItWillTakeMeToThePasswordField()
        {
            assertLogin.IsActiveInput(loginDriver.PasswordTextBox);
        }
        
        [Then(@"it will take me to the submit button")]
        public void ThenItWillTakeMeToTheSubmitButton()
        {
            assertLogin.IsActiveButton(loginDriver.LoginButton);
        }
        
        [Then(@"it will try to log me in")]
        public void ThenItWillTryToLogMeIn()
        {
            DoNothing();
        }

        private void DoNothing()
        {
            // No Implementation required;
        }
    }
}
