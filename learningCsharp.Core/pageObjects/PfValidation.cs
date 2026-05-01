using Microsoft.Playwright;
using System.Threading.Tasks;
namespace learningCsharp.Core.PageObjects
{
    public class PfValidation : BasePage
    {
        public PfValidation(IPage page) : base(page) { }

        private ILocator PfHeader => _page.Locator("h5:has-text('PF & Contributions')");
        private ILocator PfDetails => _page.Locator("a:has-text('View Details')");
         // New locators for employee name and salary
        private ILocator EmployeeName => _page.Locator("//span[contains(@class,'emp-name') and contains(text(),'John Doe')]").First;
        private ILocator EmployeeSalary => _page.Locator("//span[contains(@class,'salary-cell') and contains(text(),'₹ 10,000.00')]").First;

        public async Task<bool> IsPfHeaderVisibleAsync()
        {
            return await PfHeader.IsVisibleAsync();
        }

        public async Task ClickPfDetailsAsync()
        {
            await PfDetails.ClickAsync();
        }
        public async Task<string> GetEmployeeNameAsync()
        {
            return await EmployeeName.InnerTextAsync();
        }

        public async Task<string> GetEmployeeSalaryAsync()
        {
            return await EmployeeSalary.InnerTextAsync();
        }
    }
}