using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;

namespace FrakWorx2SpecFlow.SpecFlow
{
    [Binding]
    public class LoginSteps
    {
        // POM for login page to frakworx
        LoginPageObject loginPage;
        MainPageObject mainPage;

        /////////////////////////////////////////
        ////////                        ////////
        ///         Scenario "login"        ///        

        [BeforeScenario("login")]
        public void SetupSelenium()
        {
            PropertiesCollection.driver = new ChromeDriver();
        }

        [AfterScenario("login")]
        public void CleanupSelenium()
        {
            // For some reason this crashes test with chrome not reachable error
            //PropertiesCollection.driver.Close();
        }

        [Given(@"I am at the login page")]
        public void GivenIAmAtTheLoginPage()
        {
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
            if (status.Equals("successfully"))
                // Check for successfull login
                mainPage.Verify();
            else if (status.Equals("unsuccessfully"))
            {
                // Check for unsuccessful login
                loginPage.FindUsernameTextField();
            }
        }
    }
}
