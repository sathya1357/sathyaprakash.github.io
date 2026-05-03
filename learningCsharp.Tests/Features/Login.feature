Feature: Login

Scenario: ValidLogin
    Given user navigates to login page
    When user enters valid credentials
    Then user should see dashboard
    Then user validate PF & Contributions
    And user validate employee name and salary

Scenario: Adding new employee details
    Given user navigates to login page
    When user enters valid credentials
    Then user should see dashboard
    And the user add new employee details