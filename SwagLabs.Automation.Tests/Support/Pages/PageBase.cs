using Microsoft.Playwright;

namespace SwagLabs.Automation.Tests.Support.Pages
{
    public abstract class PageBase
    {
        protected IPage _page;

        protected PageBase(IPage page)
        {
            _page = page;
        }

        public abstract Task IsDisplayed();

        /// <summary>
        /// Get a locator which has the given class.
        /// </summary>
        /// <param name="className">The class name applied to the element.</param>
        /// <returns>An element locator</returns>
        public ILocator GetByClass(string className)
        {
            return _page.Locator($".{className.Trim()}");
        }

        /// <summary>
        /// Get a locator which has the given id.
        /// </summary>
        /// <param name="id">The id applied to the element.</param>
        /// <returns>An element locator</returns>
        public ILocator GetById(string id)
        {
            return _page.Locator($"id={id.Trim()}");
        }

    }
}
