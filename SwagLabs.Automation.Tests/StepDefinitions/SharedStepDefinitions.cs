using Microsoft.Playwright;
using SwagLabs.Automation.Tests.Support.Configuration;

namespace SwagLabs.Automation.Tests.StepDefinitions
{
    [Binding]
    public class SharedStepDefinitions
    {
        private readonly IPage _page;

        public SharedStepDefinitions(IPage page)
        {
            _page = page;
        }

        [Given(@"I navigate to the website")]
        public async Task GivenINavigateToTheWebsite()
        {
            await _page.ReloadAsync();
        }
    }
}
