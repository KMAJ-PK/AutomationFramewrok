namespace WebFramework
{
    public class NavigationDriver
    {
        private const string LoginUrl = @"https://www.saucedemo.com/";
        private readonly Browser browser;

        public NavigationDriver(Browser browser)
        {
            this.browser = browser;
        }

        public void GoToLoginUrl()
        {
            browser.NavigateTo(LoginUrl);
        }

        public bool VerifyTheRequestedPage(string address)
        {
            var pageStatus = browser.OnRequestedPage(address) ? true: false;
            return pageStatus;
        }
    }
}
