using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using System.Threading;
using System.IO;
using OpenQA.Selenium.Interactions;



namespace AmazonSpecflow.Repository
{
    class Support
    {
        // private static IWebDriver _driver;
        static string browser = ConfigurationManager.AppSettings.Get("browser");
        //public Support(IWebDriver driver)
        //{
        //    _driver = (IWebDriver)driver;
        //}

        public static void wait_for_element_exists(string obj)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(SharedWebDriver.driver, TimeSpan.FromSeconds(1));
                 wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(obj)));
                //if (string.Equals(browser, "safari", StringComparison.OrdinalIgnoreCase))
                //{
                //    safari_wait_for_element(obj);
                //}
                //else
                //{
                //    wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(obj)));
                //}
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("element not present on the page");
            }
            catch (TimeoutException)
            {
                Console.WriteLine("element not present on the page");
            }

        }
        public static void safari_wait_for_element(String obj)
        {
            for (int i = 0; i < 30; i++)
            {
                try
                {
                    Console.WriteLine("\n element found");
                    Thread.Sleep(1000);
                    if (element_exists(obj))
                    {
                        Console.WriteLine("\n element found");
                        break;
                    }
                }
                catch (ThreadInterruptedException e)
                {
                    // TODO Auto-generated catch block
                    e.StackTrace.ToString();
                }
            }
        }

        public static bool element_exists(string element)
        {
            try
            {
                Thread.Sleep(3000);
                SharedWebDriver.driver.FindElement(By.XPath(element));
                return true;
            }
            catch (Exception e)
            {

                if (e is NoSuchElementException || e is ThreadInterruptedException)
                {
                    return false;
                }
                return true;
            }
        }
        public static bool element_does_not_exist(string element)
        {
            try
            {
                SharedWebDriver.driver.FindElement(By.XPath(element));
                return false;
            }
            catch (NoSuchElementException e)
            {
                e.StackTrace.ToString();
                return true;
            }
            catch (TimeoutException to)
            {
                to.StackTrace.ToString();
                return true;
            }
        }
        public static void screenshot()
        {

            try
            {

                ITakesScreenshot screenshotDriver = SharedWebDriver.driver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                String fp = "D:\\" + "snapshot" + "_" + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".png";
                screenshot.SaveAsFile(fp, ScreenshotImageFormat.Png);
            }
            catch (IOException e)
            {
                e.StackTrace.ToString();
            }
        }
        public static void selectValueFromGroup(String element1, String element2, String text)
        {
            IWebElement items = SharedWebDriver.driver.FindElement(By.XPath(element1));
            //IReadOnlyList<IWebElement>  item = items.FindElements(By.XPath(element2));
            List<IWebElement> item = items.FindElements(By.XPath(element2)).ToList();
            foreach (var i in item)
            {
                IWebElement element = i;
                String text1 = element.Text;
                Console.WriteLine("address is: " + element.Text);
                if (string.Equals(text1, text, StringComparison.OrdinalIgnoreCase))
                {
                    element.Click();
                    break;
                }
            }
        }
        public static void scrollDown()
        {
            Actions actions = new Actions(SharedWebDriver.driver);
            actions.KeyDown(Keys.Control).SendKeys(Keys.End).Perform();
        }

        public static void scrollDownJS()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)SharedWebDriver.driver;
            jse.ExecuteScript("return window.scrollBy(0, 100)");
        }
        public static void scrollToElement(String element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)SharedWebDriver.driver;
            IWebElement element1 = SharedWebDriver.driver.FindElement(By.XPath(element));
            jse.ExecuteScript("arguments[0].scrollIntoView(true);", element1);
        }

        public static void mouseHover(string obj)
        {
            Actions actions = new Actions(SharedWebDriver.driver);
            //wait_for_element_clickable(element);
            //WebDriverWait wait = new WebDriverWait(SharedWebDriver.driver, TimeSpan.FromSeconds(1));
            //IWebElement element=wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(obj)));           
            IWebElement mainMenu = SharedWebDriver.driver.FindElement(By.XPath(obj));
            actions.MoveToElement(mainMenu);
            actions.Build().Perform();
        }
        public static void wait_for_element_clickable(string obj)
        {
            WebDriverWait wait = new WebDriverWait(SharedWebDriver.driver, TimeSpan.FromSeconds(10));
            if (string.Equals(browser, "safari", StringComparison.OrdinalIgnoreCase))
            {
                safari_wait_for_element(obj);
            }
            else
            {
                //@SuppressWarnings("unused")
                IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(obj)));
            }
        }
        public static void enter_text(string element, string text)
        {
            wait_for_element_exists(element);
            SharedWebDriver.driver.FindElement(By.XPath(element)).Clear();
            SharedWebDriver.driver.FindElement(By.XPath(element)).SendKeys(text);
        }
        public static void click(String element)
        {
            try
            {
                wait_for_element_exists(element);
            }
            catch (TimeoutException to)
            {
                Console.WriteLine("Element doesn't load");
                to.Message.ToString();
            }
            SharedWebDriver.driver.FindElement(By.XPath(element)).Click();
        }
        public static void wait_for_element_does_not_exists(string obj)
        {
            WebDriverWait wait = new WebDriverWait(SharedWebDriver.driver, TimeSpan.FromSeconds(10));
            if (string.Equals(browser, "safari", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    Thread.Sleep(1000);
                }
                catch (ThreadInterruptedException e)
                {
                    // TODO Auto-generated catch block
                    e.StackTrace.ToString();
                }
            }
            else
            {
                //@SuppressWarnings("unused")
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(obj)));

            }

        }

        public static void wait_for_element_exists_cssSel(string obj)
        {
            WebDriverWait wait = new WebDriverWait(SharedWebDriver.driver, TimeSpan.FromSeconds(10));
            if (string.Equals(browser, "safari", StringComparison.OrdinalIgnoreCase))
            {
                safari_wait_for_element(obj);
            }
            else
            {
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(obj)));

            }
        }
        public static void wait_for_element_flue(string text)
        {

            IWait<IWebDriver> wait = new DefaultWait<IWebDriver>(SharedWebDriver.driver);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            Func<IWebDriver, bool> waiter = new Func<IWebDriver, bool>((IWebDriver ele) =>
            {
                if (element_exists(text))
                {
                    return true;
                }
                return false;


            });
            wait.Until(waiter);



        }
    }
}
