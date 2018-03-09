using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using AmazonSpecflow.Repository;
using AmazonSpecflow.Utils;
using System.Configuration;


namespace AmazonSpecflow.PageModel
{
    class LoginPage
    {
        public void EnterUserName()
        {

            SharedWebDriver.driver.FindElement(By.Name(LoginElements.txtEmail)).SendKeys(ConfigurationManager.AppSettings.Get("Email"));
        }
        public void ClickContinue()
        {
            SharedWebDriver.driver.FindElement(By.XPath(LoginElements.btnContinue)).Click();
        }
        public void EnterPassword()
        {
            SharedWebDriver.driver.FindElement(By.Name(LoginElements.txtPassword)).SendKeys(ConfigurationManager.AppSettings.Get("Password"));
        }
        public void submitSignIn()
        {
            SharedWebDriver.driver.FindElement(By.XPath(LoginElements.btnSignIn)).Click();
        }
    }
}
