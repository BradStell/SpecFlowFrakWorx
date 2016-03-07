using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrakWorx2SpecFlow.SpecFlow
{
    public static class PropertiesCollection
    {
        public static IWebDriver driver { get; set; }

        public static void NavigateToLoginPage(this IWebDriver driver)
        {            
            driver.Navigate().GoToUrl("http://localhost:57789/Account/Login");
        }

        public static void ContainsText(this IWebDriver driver, string text)
        {
            // Not finding elements with XPath
            driver.FindElement(By.Id(text));
            //driver.FindElement(By.XPath("//span[@class='field-validation-error text-danger']"));
            //driver.FindElement(By.XPath("//a[@class='" + text + "']"));
        }

        public static IWebElement FindById(this IWebDriver driver, string id)
        {
            return driver.FindElement(By.Id(id));
        }
    }
}
