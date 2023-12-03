using SwagLabs.Automation.Tests.Support.Pages;

namespace SwagLabs.Automation.Tests.StepDefinitions
{
    [Binding]
    public class ProductsStepDefinitions
    {
        private readonly ProductsPage _productsPage;

        public ProductsStepDefinitions(ProductsPage productsPage)
        {
            _productsPage = productsPage;
        }

        [When(@"I am viewing the Products page")]
        public async Task GivenIAmViewingTheProductsPage()
        {
            await _productsPage.IsDisplayed();
        }

        [Then(@"I see the '([^']*)' with the price \$'([^']*)'")]
        public async Task ThenISeeTheWithThePrice(string productName, string price)
        {
            await _productsPage.ContainsProduct(productName, price);
        }
    }
}
