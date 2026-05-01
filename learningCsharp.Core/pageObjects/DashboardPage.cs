using Microsoft.Playwright;
using System.Threading.Tasks;

namespace learningCsharp.Core.PageObjects
{
    public class DashboardPage : BasePage
    {
        public DashboardPage(IPage page) : base(page) { }

        private ILocator DashboardHeader => _page.Locator("text=Dashboard");

        public async Task<bool> IsDashboardVisibleAsync()
        {
            return await DashboardHeader.IsVisibleAsync();
        }
    }
}
