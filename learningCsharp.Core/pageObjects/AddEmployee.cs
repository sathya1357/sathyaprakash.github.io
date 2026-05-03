using Microsoft.Playwright;
using System.Threading.Tasks;
namespace learningCsharp.Core.PageObjects
{
    public class AddEmployee : BasePage
    {
        public AddEmployee(IPage page) : base(page) { }

        private ILocator AddEmployeeLink => _page.Locator("text=Add Employee");
        private ILocator FirstName => _page.Locator("#FirstName");
        private ILocator LastName => _page.Locator("#LastName");
        private ILocator SaveButton => _page.Locator("button:has-text('Save')");

        public async Task AddNewEmployeeAsync(string firstName, string lastName)
        {
            await AddEmployeeLink.ClickAsync();
            await FirstName.FillAsync(firstName);
            await LastName.FillAsync(lastName);
            await SaveButton.ClickAsync();
        }
    }
}
// https://github.com/sathya1357/sathyaprakash.github.io