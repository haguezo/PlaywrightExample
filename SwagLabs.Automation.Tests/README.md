# Test Automation with Playwright.NET and SpecFlow
---

An example test automation framework which uses [Swag Labs](https://www.saucedemo.com/) as its 'system under test'.  Swag Labs is a sample web-site created by [SauceLabs](https://saucelabs.com/) to enable developers to practise their automation skills. 

The browser is automated using [Playwright for .NET](https://playwright.dev/dotnet/docs/writing-tests).  

The test scenarios are defined using the BDD framework [SpecFlow](https://specflow.org/) and written in **C#** implementing the **Page Object Model pattern**.  

The [SpecFlow+LivingDocGenerator](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html) is used to generate **living documentation**.

## Getting started
---

- Open the solution in Visual Studio ([download the free Community version](https://visualstudio.microsoft.com/vs/)).
- Restore all packages.
- Build the solution.

The **Test Explorer** will discover the tests and display the features.

### Install the required browsers

Playwright provides a PowerShell script `playwright.ps1` to install the required browsers.  After building the project, you will find this script in your **Debug** folder in a subfolder named with the .NET version.

To run the script:

- Ensure you have built the project.
- Go to the **Developer PowerShell** window.
- Change directory to the project's `bin\Debug\net6.0` folder. 
- Observe the `playwright.ps1` script.
- Run `.\playwright.ps1 install` from **Developer PowerShell** prompt.

You should see the browsers downloading.


### Project structure

The project contains the following folders:

- Features - _contains the SpecFlow feature files._
- Hooks - _contains the setup and teardown code._
- StepDefinitions - _contains the step definition files._
- Support - _contains folders for configuration and page object models._


### Running the tests

The tests can be run from Visual Studio's **Test Explorer**.  By default, they are configured to run in headed mode meaning you can see the browser opening, running the test and closing.  