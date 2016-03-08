using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace FrakWorx2SpecFlow.SpecFlow
{
    /// <summary>
    /// Main Page Object Model
    /// Holds a few id's on the page and actions to test
    /// </summary>
    class MainPageObject
    {
        // Main Page ID's
        private string MyProfileButton = "My Profile-button";
        private string ReportsButton = "Reports-button";
        private string ApplicationUsersButton = "Application Users-button";

        /// <summary>
        /// Init selenium inbuilt method with this driver
        /// </summary>
        public MainPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        /// <summary>
        /// Verify that we are on the home page by finding the menu toggle button
        /// </summary>
        public void Verify()
        {
            PropertiesCollection.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            PropertiesCollection.driver.FindById("menu-toggle");
        }

        /// <summary>
        /// Looks for the incoming button and tries to click it.
        /// If the button cannot be found then it will click the menu toggle button 
        /// and try to find it again.
        /// </summary>
        /// <param name="what">The button to look for</param>
        public void View(string what)
        {
            // Set 10 second timeout to wait for angular app to load while looking for html elements
            PropertiesCollection.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            string id = "";

            switch (what)
            {
                case "My Profile":
                    id = MyProfileButton;
                    break;

                case "Reports":
                    id = ReportsButton;
                    break;

                case "Application Users":
                    id = ApplicationUsersButton;
                    break;
            }

            // Try to click the element, if it is not visible then the menu toggle button needs to be depressed
            try
            {
                PropertiesCollection.driver.FindById(id).Click();
            }

            catch (ElementNotVisibleException e)
            {
                PropertiesCollection.driver.FindById("menu-toggle").Click();
                PropertiesCollection.driver.FindById(id).Click();
            }
        }
    }
}
