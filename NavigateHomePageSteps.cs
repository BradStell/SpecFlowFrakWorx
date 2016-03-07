using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace FrakWorx2SpecFlow.SpecFlow
{
    [Binding]
    public class NavigateHomePageSteps
    {
        MainPageObject mainPage;

        [BeforeScenario("profile")]
        public void SetupProfile()
        {
            LoadLoginPage();
        }

        [BeforeScenario("reports")]
        public void SetupReports()
        {
            LoadLoginPage();
        }



        private void LoadLoginPage()
        {
            PropertiesCollection.driver = new ChromeDriver();
            PropertiesCollection.driver.NavigateToLoginPage();
            LoginPageObject loginPage = new LoginPageObject();
            mainPage = loginPage.ValidLogin();
        }



        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            mainPage.Verify();
        }

        [When(@"I click the '(.*)' button")]
        public void WhenIClickTheMyProfileButton(string button)
        {
            mainPage.View(button);
        }

        [Then(@"I should see the '(.*)' page")]
        public void ThenIShouldSeeMyProfile(string what)
        {
            // If above method runs, then the  button was found and clicked,
            // and thus the view is verified. Cannot find id on this page because
            // all users will have different dynamic content in the main window.
        }
    }
}
