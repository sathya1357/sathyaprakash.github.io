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
        private readonly AddEmployee _addEmployee;
        private readonly ScenarioContext _scenarioContext;

        public LoginSteps(LoginPage loginPage, DashboardPage dashboardPage, PfValidation pfValidation, AddEmployee addEmployee, ScenarioContext scenarioContext)
        {
            _loginPage = loginPage;
            _dashboardPage = dashboardPage;
            _pfValidation = pfValidation;
            _addEmployee = addEmployee;
            _scenarioContext = scenarioContext;
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

            // Store in ScenarioContext for use in other steps or reports
            _scenarioContext["EmployeeName"] = empName;
            _scenarioContext["EmployeeSalary"] = empSalary;

            Assert.AreEqual("John Doe", empName);
            Assert.AreEqual("₹ 10,000.00", empSalary);
        }
        [Then(@"the user add new employee details")]
        public async Task ThenTheUserAddNewEmployeeDetails()
        {
            string firstName = "John"; 
            string lastName = "Doe";

            // Store in ScenarioContext for tracking
            _scenarioContext["NewEmployeeFirstName"] = firstName;
            _scenarioContext["NewEmployeeLastName"] = lastName;

            // Implement the logic to add new employee details
            await _addEmployee.AddNewEmployeeAsync(firstName, lastName);
            
            Console.WriteLine($"New employee added: {firstName} {lastName}");
        }

    }

}
