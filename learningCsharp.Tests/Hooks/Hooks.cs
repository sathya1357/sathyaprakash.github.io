using TechTalk.SpecFlow;
using Microsoft.Playwright;
using System.Threading.Tasks;
using BoDi;
using learningCsharp.Core.PageObjects;

namespace learningCsharp.Tests.Hooks
{
    [Binding]
    public class TestHooks
    {
        private IPlaywright? playwright;
        private IBrowser? browser;
        private IBrowserContext? context;
        private IPage? page;

        [BeforeScenario]
        public async Task Setup(IObjectContainer objectContainer)
        {
            playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            context = await browser.NewContextAsync();
            page = await context.NewPageAsync();

            // Register IPage in the DI container so page objects can be resolved
            objectContainer.RegisterInstanceAs<IPage>(page);
            
            // Register page objects for dependency injection
            objectContainer.RegisterTypeAs<LoginPage, LoginPage>();
            objectContainer.RegisterTypeAs<DashboardPage, DashboardPage>();
            objectContainer.RegisterTypeAs<PfValidation, PfValidation>();
        }

        [AfterScenario]
        public async Task TearDown()
        {
            if (browser != null)
            {
                await browser.CloseAsync();
            }
            playwright?.Dispose();
        }
    }
}
