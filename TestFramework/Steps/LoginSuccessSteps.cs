using System;
using TechTalk.SpecFlow;
using WebFramework;

namespace TestFramework
{
    [Binding, Scope(Feature = "Login Success")]
    public class LoginSuccessSteps
    {
        private readonly LoginDriver loginDriver;
        private readonly AssertLogin assertLogin;

        public LoginSuccessSteps(LoginDriver loginDriver, AssertLogin assertLogin)
        {
            this.loginDriver = loginDriver;
            this.assertLogin = assertLogin;
        }
        
        [Given(@"that I have entered a username but no password")]
        public void GivenThatIHaveEnteredAUsernameButNoPassword()
        {
            loginDriver.UserNameTextBox.SendKeys("standard_user");
        }
        
        [Given(@"that I have entered an incorrect username and password")]
        public void GivenThatIHaveEnteredAnIncorrectUsernameAndPassword()
        {
            loginDriver.UserNameTextBox.SendKeys("stana_user");
            loginDriver.PasswordTextBox.SendKeys("sauce");
        }

        [When(@"I attempt to login")]
        [When(@"i click login")]
        [When(@"i click login with no username and password")]
        public void WhenIClickLogin()
        {
            loginDriver.LoginButton.Click();
        }
        
        [Then(@"it will successfully redirect me to '(.*)'")]
        public void ThenItWillSuccessfullyRedirectMeTo(string address)
        {
            assertLogin.RequestedPageIsLoaded(address);
        }
    }
}
