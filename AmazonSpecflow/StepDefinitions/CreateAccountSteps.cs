using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using AmazonSpecflow.PageModel;
using AmazonSpecflow.Repository;
using AmazonSpecflow.Utils;
using NUnit.Framework;

namespace AmazonSpecflow.StepDefinitions
{
    [Binding]
    public class CreateAccountSteps
    {
        public IWebDriver driver { get; set; }
        CreateAccount createAccountPage = new CreateAccount();
        HomePage homePage = new HomePage();
        LoginPage loginPage = new LoginPage();
        [When(@"Clicked on New User the browser should be redirected to createAccount page")]
        public void WhenClickedOnNewUserTheBrowserShouldBeRedirectedToCreateAccountPage()
        {
           
            homePage.CheckbtnStartHere();
        }
        
        [When(@"User User entered Name,email, passowrd, re-password")]
        public void WhenUserUserEnteredNameEmailPassowrdRe_Password()
        {
            createAccountPage.EnterValidData();
            createAccountPage.ClickcreateAccount();
        }
        
        [When(@"Clicked on CreateAccount Button")]
        public void WhenClickedOnCreateAccountButton()
        {
            homePage.FindUserAmazonElement();
            Assert.Pass();
        }
    }
}
