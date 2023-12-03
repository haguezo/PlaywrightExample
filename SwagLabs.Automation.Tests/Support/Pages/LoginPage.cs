using Microsoft.Playwright;

namespace SwagLabs.Automation.Tests.Support.Pages
{
    public class LoginPage : PageBase
    {
        public LoginPage(IPage page) : base(page) { }

        #region Element locators

        private ILocator UsernameInput => _page.GetByTestId("username");
        private ILocator PasswordInput => _page.GetByTestId("password");
        private ILocator LoginButton => _page.GetByTestId("login-button");
        private ILocator ErrorMessage => _page.GetByTestId("error");

        #endregion

        #region Actions

        public async Task Login(string username, string password)
        {
            await UsernameInput.FillAsync(username);
            await PasswordInput.FillAsync(password);
            await LoginButton.ClickAsync();
        }

        #endregion

        #region Assertions

        public override async Task IsDisplayed()
        {
            await Assertions.Expect(_page).ToHaveTitleAsync("Swag Labs");

            await Assertions.Expect(UsernameInput).ToBeVisibleAsync();
            await Assertions.Expect(UsernameInput).ToBeEnabledAsync();

            await Assertions.Expect(PasswordInput).ToBeVisibleAsync();
            await Assertions.Expect(PasswordInput).ToBeEnabledAsync();

            await Assertions.Expect(LoginButton).ToBeVisibleAsync();
            await Assertions.Expect(LoginButton).ToBeEnabledAsync();
        }

        public async Task IsLockedOut()
        {
            await Assertions.Expect(ErrorMessage).ToBeVisibleAsync();
            await Assertions.Expect(ErrorMessage).ToContainTextAsync("Epic sadface: Sorry, this user has been locked out.");
        }

        #endregion
    }
}
