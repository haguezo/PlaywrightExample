using Microsoft.Playwright;

namespace SwagLabs.Automation.Tests.Support.Pages
{
    public class ProductsPage : PageBase
    {
        public ProductsPage(IPage page) : base(page) { }

        #region Element locators

        private ILocator Title => GetByClass("header_secondary_container").Locator("span.title");
        private ILocator ProductFilter => _page.GetByTestId("product_sort_container");
        private ILocator ProductList => GetById("inventory_container").First;
        private ILocator ShoppingCartLink => GetById("shopping_cart_container");

        #endregion

        #region Assertions

        public override async Task IsDisplayed()
        {
            await Assertions.Expect(Title).ToContainTextAsync("Products", new() { IgnoreCase = false });

            await Assertions.Expect(ProductFilter).ToBeVisibleAsync();
            await Assertions.Expect(ProductFilter).ToBeEnabledAsync();

            await Assertions.Expect(ProductList).ToBeVisibleAsync();
            await Assertions.Expect(GetByClass("inventory_item")).ToHaveCountAsync(6);

            await Assertions.Expect(ShoppingCartLink).ToBeVisibleAsync();
        }

        public async Task ContainsProduct(string productName, string price)
        {
            var item = GetByClass("inventory_item").Filter(new() { HasText = productName });
            var itemName = item.Locator("div.inventory_item_name");
            var itemPrice = item.Locator("div.inventory_item_price").Filter(new() { HasText = price.ToString() });

            await Assertions.Expect(itemName).ToHaveCountAsync(1);
            await Assertions.Expect(itemPrice).ToHaveCountAsync(1);
        }


        #endregion
    }
}
