using TechTalk.SpecFlow;
using NUnit.Framework;
using learningCsharp.Core.PageObjects;

namespace learningCsharp.Tests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;
        private readonly DashboardPage _dashboardPage;
        private readonly PfValidation _pfValidation;

        public LoginSteps(LoginPage loginPage, DashboardPage dashboardPage, PfValidation pfValidation)
        {
            _loginPage = loginPage;
            _dashboardPage = dashboardPage;
            _pfValidation = pfValidation;
        }

        [Given(@"user navigates to login page")]
        public async Task GivenUserNavigatesToLoginPage()
        {
            // ✅ Using your current tab URL
            await _loginPage.NavigateToAsync("http://eaapp.somee.com");
        }

        [When(@"user enters valid credentials")]
        public async Task WhenUserEntersValidCredentials()
        {
            await _loginPage.LoginAsync("admin", "password");
        }

        [Then(@"user should see dashboard")]
        public async Task ThenUserShouldSeeDashboard()
        {
            Assert.True(await _dashboardPage.IsDashboardVisibleAsync());
        }
        [Then(@"user validate PF & Contributions")]
        public async Task ThenUserValidatePFContributions()
        {
            
            Assert.True(await _pfValidation.IsPfHeaderVisibleAsync());
                await _pfValidation.ClickPfDetailsAsync();
        }
        [Then(@"user validate employee name and salary")]
        public async Task ThenUserValidateEmployeeNameAndSalary()
        {
            string empName = await _pfValidation.GetEmployeeNameAsync();
            string empSalary = await _pfValidation.GetEmployeeSalaryAsync();
            Console.WriteLine($"Employee Name: {empName}, Employee Salary: {empSalary}");

            Assert.AreEqual("John Doe", empName);
            Assert.AreEqual("₹ 10,000.00", empSalary);
        }

    }

}
