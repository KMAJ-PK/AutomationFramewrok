using System;
using System.Collections.Generic;
using WebFramework;
using TechTalk.SpecFlow;

namespace TestFramework
{
    [Binding, Scope(Tag = "@SwagLabs")]
    public class CommonSteps
    {
        private readonly AssertLogin assertLogin;
        private readonly NavigationDriver navigationDriver;
        private readonly LoginDriver loginDriver;

        public CommonSteps(AssertLogin assertLogin, NavigationDriver navigationDriver, LoginDriver loginDriver)
        {
            this.assertLogin = assertLogin;
            this.navigationDriver = navigationDriver;
            this.loginDriver = loginDriver;
        }

        [Given(@"that i am on the login page")]
        public void GivenThatIAmOnTheLoginPage()
        {
            navigationDriver.GoToLoginUrl();
        }

        [Given(@"that I have entered a valid username and password")]
        public void GivenThatIHaveEnteredAValidUsernameAndPassword()
        {
            loginDriver.UserNameTextBox.SendKeys("standard_user");
            loginDriver.PasswordTextBox.SendKeys("secret_sauce");
        }

        [Then(@"an error will be thorwn below the form stating '(.*)'")]
        public void ThenAnErrorWillBeThorwnBelowTheFormStating(string errorMessage)
        {
            assertLogin.LoginFailedWithError(errorMessage);
        }
    }
}
