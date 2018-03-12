using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonSpecflow.Utils;
using OpenQA.Selenium.Support.PageObjects;
using AmazonSpecflow.Repository;

namespace AmazonSpecflow.PageModel
{
    public class HomePage
    {
       
        public void FindUserAmazonElement()
        {
            Support.wait_for_element_exists(HomeElements.lnkBtnUserAmazon);
           
        }
        public void CheckbtnSignIn()
        {
            SharedWebDriver.driver.FindElement(By.XPath(HomeElements.SignIn)).Click();

        }
        public void CheckbtnStartHere()
        {
            Support.mouseHover(HomeElements.SignIn);
            SharedWebDriver.driver.FindElement(By.XPath(HomeElements.Starthere)).Click();

        }
    }
}
