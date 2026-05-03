# learningCsharp - Automation Testing Project

A comprehensive C# automation testing framework using **Playwright**, **SpecFlow**, and **NUnit** for browser-based testing with Behavior-Driven Development (BDD).

## Project Overview

This project demonstrates automated testing of an Employee Management Application with the following capabilities:
- User authentication and login validation
- Dashboard navigation
- Employee data validation (PF & Contributions)
- Employee salary information verification
- New employee registration workflows

## Project Structure

```
learningCsharp/
├── learningCsharp.Core/              # Core framework and page objects
│   ├── pageObjects/                  # Page Object Model classes
│   │   ├── BasePage.cs              # Base class for all page objects
│   │   ├── LoginPage.cs             # Login page interactions
│   │   ├── DashboardPage.cs         # Dashboard page interactions
│   │   ├── AddEmployee.cs           # Add employee functionality
│   │   └── PfValidation.cs          # PF & salary validation
│   └── learningCsharp.Core.csproj   # Core project configuration
│
├── learningCsharp.Tests/             # Test project
│   ├── Features/                     # SpecFlow feature files (BDD scenarios)
│   │   ├── Login.feature            # Login and employee scenarios
│   │   └── Login.feature.cs         # Auto-generated feature code-behind
│   ├── StepDefinitions/             # SpecFlow step implementations
│   │   └── LoginSteps.cs            # Step definitions for login scenarios
│   ├── Hooks/                        # Test setup/teardown logic
│   │   └── Hooks.cs                 # Browser initialization & cleanup
│   ├── UnitTest1.cs                 # Sample unit tests
│   └── learningCsharp.Tests.csproj  # Test project configuration
│
├── learningCsharp.slnx              # Solution file
└── README.md                        # This file
```

## Technology Stack

### Core Dependencies

#### learningCsharp.Core
| Package | Version | Purpose |
|---------|---------|---------|
| **Microsoft.Playwright** | 1.59.0 | Browser automation library for cross-browser testing |

#### learningCsharp.Tests
| Package | Version | Purpose |
|---------|---------|---------|
| **Microsoft.Playwright** | 1.59.0 | Browser automation |
| **NUnit** | 4.5.1 | Testing framework |
| **NUnit.Analyzers** | 4.7.0 | Code analysis for NUnit tests |
| **NUnit3TestAdapter** | 5.0.0 | Test adapter for running NUnit tests in Visual Studio |
| **SpecFlow.NUnit** | 3.9.74 | SpecFlow integration with NUnit |
| **SpecFlow.Tools.MsBuild.Generation** | 3.9.74 | BDD feature file code generation |
| **Microsoft.NET.Test.Sdk** | 17.14.0 | Test SDK for running tests |
| **coverlet.collector** | 6.0.4 | Code coverage collection |

### Framework Details
- **.NET Target**: .NET 10.0
- **Language Version**: Latest
- **Implicit Usings**: Enabled
- **Nullable Reference Types**: Enabled

## Prerequisites

- **.NET 10.0** SDK or later
- **Visual Studio** 2022 or **VS Code** with C# extensions
- **Playwright browsers** (automatically installed via NuGet)
- Windows, macOS, or Linux

## Installation & Setup

### 1. Clone the Repository
```bash
git clone <repository-url>
cd learningCsharp
```

### 2. Restore NuGet Packages
```bash
dotnet restore
```

### 3. Build the Solution
```bash
dotnet build
```

### 4. Install Playwright Browsers
```bash
cd learningCsharp.Tests
dotnet build
pwsh bin/Debug/net10.0/playwright.ps1 install
```

## Running Tests

### Run All Tests
```bash
dotnet test
```

### Run Specific Test Project
```bash
dotnet test learningCsharp.Tests/learningCsharp.Tests.csproj
```

### Run Tests with Verbose Output
```bash
dotnet test --verbosity=detailed
```

### Run Tests with Code Coverage
```bash
dotnet test /p:CollectCoverageOnTestExecution=true
```

### Run Specific SpecFlow Feature
```bash
dotnet test --filter "Login"
```

## Available Scenarios

### Feature: Login (Login.feature)

#### Scenario 1: ValidLogin
**Purpose**: Validate successful user login and dashboard access
```gherkin
Given user navigates to login page
When user enters valid credentials
Then user should see dashboard
Then user validate PF & Contributions
And user validate employee name and salary
```

#### Scenario 2: Adding new employee details
**Purpose**: Test new employee creation workflow
```gherkin
Given user navigates to login page
When user enters valid credentials
Then user should see dashboard
And the user add new employee details
```

## Architecture & Design Patterns

### Page Object Model (POM)
All UI interactions are encapsulated in page object classes:
- **BasePage**: Base class providing common navigation functionality
- **Specific Page Objects**: LoginPage, DashboardPage, AddEmployee, PfValidation

### Dependency Injection (DI)
- Uses BoDi (Dependency Injection Container) for SpecFlow
- Page objects are automatically instantiated and injected into step definitions
- Playwright IPage instance is shared across page objects

### BDD with SpecFlow
- Feature files define test scenarios in Gherkin language
- Step definitions map Gherkin steps to C# code
- Automatic test report generation

## Building from Command Line

### Build Solution
```bash
dotnet build learningCsharp.slnx
```

### Clean Solution
```bash
dotnet clean learningCsharp.slnx
```

### Rebuild Solution
```bash
dotnet build learningCsharp.slnx --no-incremental
```

## Test Application URL

- **Application Under Test**: `http://eaapp.somee.com`
- **Purpose**: Employee Management Application for testing login and employee operations

## Development Workflow

### Adding New Test Scenarios
1. Create new scenarios in `Features/Login.feature` using Gherkin syntax
2. Auto-generate feature code-behind if needed
3. Implement corresponding step definitions in `StepDefinitions/LoginSteps.cs`
4. Run tests with `dotnet test`

### Adding New Page Objects
1. Create new class in `learningCsharp.Core/pageObjects/`
2. Inherit from `BasePage`
3. Define locators and interaction methods
4. Register in `Hooks.cs` dependency injection container
5. Inject into step definitions

### Modifying Page Selectors
All CSS selectors and XPath locators are defined in page object classes:
- Update locators in respective page classes
- No changes needed in step definitions

## Useful Commands Reference

| Command | Purpose |
|---------|---------|
| `dotnet restore` | Restore NuGet packages |
| `dotnet build` | Build the solution |
| `dotnet test` | Run all tests |
| `dotnet clean` | Clean build artifacts |
| `dotnet publish` | Publish/prepare for deployment |
| `dotnet add package <name>` | Add NuGet package |
| `dotnet remove package <name>` | Remove NuGet package |

## Debugging

### Enable Playwright Debug Mode
```bash
$env:DEBUG = "pw:api"
dotnet test
```

### Run Tests Headful (Non-Headless)
Browser launches in non-headless mode by default (visible window). See `Hooks.cs` - `Headless = false`

### Screenshots & Videos
Extend `TestHooks` class to capture screenshots on failure:
```csharp
[AfterScenario]
public async Task CaptureScreenOnFailure(ScenarioContext context)
{
    if (context.TestError != null)
    {
        var screenshot = await page.ScreenshotAsync(new PageScreenshotOptions 
        { 
            Path = $"screenshots/{context.ScenarioInfo.Title}.png" 
        });
    }
}
```

## Troubleshooting

### Playwright Browsers Not Installed
```bash
pwsh bin/Debug/net10.0/playwright.ps1 install
```

### Test Timeouts
Increase timeout in page goto calls (currently set to 60000ms):
```csharp
await _page.GotoAsync(url, new PageGotoOptions 
{ 
    WaitUntil = WaitUntilState.NetworkIdle, 
    Timeout = 120000 
});
```

### NUnit Not Found
Ensure `NUnit3TestAdapter` is installed and run:
```bash
dotnet restore
```

## Continuous Integration

The project structure supports CI/CD pipelines:
```bash
dotnet build learningCsharp.slnx
dotnet test learningCsharp.Tests/learningCsharp.Tests.csproj --logger=trx
```

## Resources

- [Playwright .NET Documentation](https://playwright.dev/dotnet/)
- [SpecFlow Documentation](https://specflow.org/)
- [NUnit Documentation](https://docs.nunit.org/)
- [Page Object Model Pattern](https://www.selenium.dev/documentation/test_practices/encouraged/page_object_models/)

## License

This project is for learning purposes.

## Author

Created as a learning project for C# automation testing practices.

---

**Last Updated**: May 2026
