using SwagLabs.Automation.Tests.Support.Pages;

namespace SwagLabs.Automation.Tests.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly LoginPage _loginPage;
        private readonly ProductsPage _productsPage;

        public LoginStepDefinitions(LoginPage loginPage, ProductsPage productsPage)
        {
            _loginPage = loginPage;
            _productsPage = productsPage;
        }

        [Given(@"I see the Login page")]
        public async Task GivenISeeTheLoginPage()
        {
            await _loginPage.IsDisplayed();
        }

        [StepDefinition(@"I log in as '(.*)' with the password '(.*)'")]
        public async Task WhenILogInWithMyUsernameAndPassword(string username, string password)
        {
            await _loginPage.Login(username, password);
        }

        [Then(@"I see the Products page")]
        public async Task ThenISeeTheProductsPage()
        {
            await _productsPage.IsDisplayed();
        }

        [Then(@"I see an error message telling me I am locked out")]
        public async Task ThenISeeAnErrorMessageTellingMeIAmLockedOut()
        {
            await _loginPage.IsLockedOut();
        }
    }
}
