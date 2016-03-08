using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;

namespace FrakWorx2SpecFlow.SpecFlow
{
    /// <summary>
    /// Code that maps to the Login.feature file Gherkin code
    /// </summary>
    [Binding]
    public class LoginSteps
    {
        // Page Object Model's
        LoginPageObject loginPage;
        MainPageObject mainPage;

        /////////////////////////////////////////
        ////////                        ////////
        ///         Scenario "login"        ///        

        [BeforeScenario("login")]
        public void SetupSelenium()
        {
            // Create a new Chrome driver object for working with google chrome
            PropertiesCollection.driver = new ChromeDriver();
        }

        /////////////////////////////////////////////
        ////  Code that maps to feature file    ////

        [Given(@"I am at the login page")]
        public void GivenIAmAtTheLoginPage()
        {
            // Navigate to the login page
            PropertiesCollection.driver.NavigateToLoginPage();
            loginPage = new LoginPageObject();
        }

        [When(@"I login with '(.*)' credentials")]
        public void WhenILoginWithCredentials(string type)
        {
            // Handle a valid login
            if (type.Equals("valid"))
                mainPage = loginPage.ValidLogin();

            // Handle an invalid login
            else if (type.Equals("invalid"))
                mainPage = loginPage.InvalidLogin();
        }

        [Then(@"I should be '(.*)' logged into the program")]
        public void ThenIShouldBeLoggedIntoTheProgram(string status)
        {
            // Check for successfull login
            if (status.Equals("successfully"))                
                mainPage.Verify();

            // Check for unsuccessful login
            else if (status.Equals("unsuccessfully"))
                loginPage.FindUsernameTextField();

            // Close the driver after done with tests
            PropertiesCollection.driver.Close();
        }
    }
}
