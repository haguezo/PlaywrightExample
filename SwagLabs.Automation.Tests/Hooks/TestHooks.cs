using BoDi;
using Microsoft.Playwright;
using SwagLabs.Automation.Tests.Support.Configuration;

namespace SwagLabs.Automation.Tests.Hooks
{
    [Binding]
    public class TestHooks
    {
        private readonly IObjectContainer _objectContainer;

        public TestHooks(IObjectContainer container)
        {
            _objectContainer = container;
        }

        /// <summary>
        /// Runs before each tests. Launches Playwright and a Chrome browser instance containing a single page.
        /// </summary>
        [BeforeScenario()]
        public async Task Setup()
        {
            var playwright = await Playwright.CreateAsync();

            playwright.Selectors.SetTestIdAttribute(ConfigurationService.Get<string>(ConfigurationItem.DataTestId));

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Channel = ConfigurationService.Get<string>(ConfigurationItem.Browser),
                Headless = ConfigurationService.Get<bool>(ConfigurationItem.Headless),
                SlowMo = ConfigurationService.Get<int>(ConfigurationItem.SlowMo),
                Args = new[] { "--start-maximized", "--no-sandbox", "--disable-extensions" }
            });

            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync(ConfigurationService.Get<string>(ConfigurationItem.BaseUrl));

            _objectContainer.RegisterInstanceAs(page);
            _objectContainer.RegisterInstanceAs(context);
            _objectContainer.RegisterInstanceAs(browser);
            _objectContainer.RegisterInstanceAs(playwright);
        }

        /// <summary>
        /// Cleans up after each test.
        /// </summary>
        [AfterScenario()]
        public async Task Teardown()
        {
            var page = _objectContainer.Resolve<IPage>();

            if (page != null)
            {
                await page.CloseAsync();
            }

            await _objectContainer.Resolve<IBrowserContext>().DisposeAsync();
            await _objectContainer.Resolve<IBrowser>().DisposeAsync();

            _objectContainer.Resolve<IPlaywright>().Dispose();
        }
    }
}
