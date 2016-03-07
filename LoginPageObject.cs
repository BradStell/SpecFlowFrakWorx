using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace FrakWorx2SpecFlow.SpecFlow
{
    class LoginPageObject
    {
        public LoginPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        ///////////////////
        /// Properties ///
         
        // Username Text Field
        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement UserNameTextBox { get; set; }

        // Password Text field
        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordTextBox { get; set; }

        // Login Button
        [FindsBy(How = How.Id, Using = "login-button-login")]
        public IWebElement LoginButton { get; set; }


        ////////////////////////////
        ///  Login Page Actions ///

        /// <summary>
        /// Login to frakworx application
        /// </summary>
        /// <param name="username">the username to login with</param>
        /// <param name="password">the password to login with</param>
        /// <returns>POM representing the main page of the SPA</returns>
        public MainPageObject ValidLogin()
        {
            UserNameTextBox.SendKeys("Administrator");
            PasswordTextBox.SendKeys("Password1234!");
            LoginButton.Submit();

            return new MainPageObject();
        }

        public MainPageObject InvalidLogin()
        {
            UserNameTextBox.SendKeys("kkasdfj");
            PasswordTextBox.SendKeys("nlliasdk");
            LoginButton.Submit();

            return new MainPageObject();
        }

        /// <summary>
        /// Searches for Username text field, if exists then still on login page because
        /// login failed
        /// </summary>
        public void FindUsernameTextField()
        {
            Console.WriteLine(UserNameTextBox.Text);
        }
    }
}
