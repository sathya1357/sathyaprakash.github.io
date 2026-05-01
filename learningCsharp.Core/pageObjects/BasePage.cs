using Microsoft.Playwright;
using System.Threading.Tasks;

namespace learningCsharp.Core.PageObjects
{
    public class BasePage
    {
        protected readonly IPage _page;

        public BasePage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateToAsync(string url)
        {
            await _page.GotoAsync(url, new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle, Timeout = 60000 });
        }
    }
}