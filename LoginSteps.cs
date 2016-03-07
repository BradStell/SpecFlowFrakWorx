using System;
using TechTalk.SpecFlow;

namespace FrakWorx2SpecFlow.SpecFlow
{
    [Binding]
    public class LoginSteps
    {
        [Given(@"I am at the login page")]
        public void GivenIAmAtTheLoginPage()
        {
            Console.WriteLine("In login page");
        }
        
        [When(@"I login with '(.*)' credentials")]
        public void WhenILoginWithValidCredentials(string type)
        {
            Console.WriteLine("In when");
        }
        
        [Then(@"I should be '(.*)' logged into the program")]
        public void ThenIShouldBeSuccessfullyLoggedIntoTheProgram(string status)
        {
            Console.WriteLine("In then");
        }
    }
}
