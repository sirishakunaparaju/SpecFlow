using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using AmazonSpecflow.PageModel;
using AmazonSpecflow.Repository;
using NUnit.Framework;

namespace AmazonSpecflow
{
    [Binding]
    public class AmazonLoginSteps
    {

        public IWebDriver driver { get; set; }
        LoginPage loginPage = new LoginPage();
        HomePage homePage = new HomePage();

        [Given(@"User Navigated to Amazon Url Page")]
        public void GivenUserNavigatedToAmazonUrlPage()
        {
            driver = SharedWebDriver.driver;
            driver.Navigate().GoToUrl(SharedWebDriver.url);
           
        }
        
        [When(@"User enetered valid Credentials")]
        public void WhenUserEneteredValidCredentials()
        {
            homePage.CheckbtnSignIn();
            loginPage.EnterUserName();
            loginPage.ClickContinue();
            loginPage.EnterPassword();
            
        }
        
        [When(@"Click on SignIn button")]
        public void WhenClickOnSignInButton()
        {
            loginPage.submitSignIn();
        }
        
        [Then(@"the application displays Users Amazon Home Page\.")]
        public void ThenTheApplicationDisplaysUsersAmazonHomePage_()
        {
            homePage.FindUserAmazonElement();
            Assert.Pass();
        }
    }
}
