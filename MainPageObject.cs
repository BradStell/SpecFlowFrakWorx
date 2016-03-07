using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrakWorx2SpecFlow.SpecFlow
{
    class MainPageObject
    {
        // Main Page ID's
        private string MyProfileButton = "My Profile-button";
        private string ReportsButton = "Reports-button";
        private string FileManagerButton = "File Manager-button";


        public MainPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        public void Verify()
        {
            PropertiesCollection.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            PropertiesCollection.driver.FindById("menu-toggle");
        }

        public void View(string what)
        {
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

                case "File Manager":
                    id = FileManagerButton;
                    break;
            }

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
