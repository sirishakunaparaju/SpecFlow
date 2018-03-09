using AmazonSpecflow.Repository;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonSpecflow.Utils;

namespace AmazonSpecflow.PageModel
{
    class CreateAccount
    {
    
        public CreateAccount()
        {            
            //PageFactory.InitElements(SharedWebDriver.driver, typeof(Support));
        }

        public void EnterValidData()
        {
            SharedWebDriver.driver.FindElement(By.Name(CreateAccountElements.Name)).SendKeys(CreateAccountElements.strName);
            SharedWebDriver.driver.FindElement(By.Name(CreateAccountElements.Email)).SendKeys(CreateAccountElements.strEmail);
            SharedWebDriver.driver.FindElement(By.Name(CreateAccountElements.Password)).SendKeys(CreateAccountElements.strPassword);
            SharedWebDriver.driver.FindElement(By.Name(CreateAccountElements.ReEnterPassword)).SendKeys(CreateAccountElements.strReEnterPassword);

        }
        public void ClickcreateAccount()
        {
            SharedWebDriver.driver.FindElement(By.XPath(CreateAccountElements.CreateAccount)).Click();

        }
    }
}
