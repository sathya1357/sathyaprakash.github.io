using Microsoft.Playwright;
using System.Threading.Tasks;

namespace learningCsharp.Core.PageObjects
{
    public class LoginPage : BasePage
    {
        public LoginPage(IPage page) : base(page) { }
        private ILocator LoginLink => _page.Locator("text=Login");

        private ILocator Username => _page.Locator("#UserName");
        private ILocator Password => _page.Locator("#Password");
        private ILocator LoginButton => _page.Locator("button:has-text('Sign In')");

        public async Task LoginAsync(string user, string pass)
        {
            await LoginLink.ClickAsync();
            await Username.FillAsync(user);
            await Password.FillAsync(pass);
            await LoginButton.ClickAsync();
         
        }
    }
}
