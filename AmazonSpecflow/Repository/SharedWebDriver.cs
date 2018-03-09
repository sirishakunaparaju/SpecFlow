using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support;
using System.Configuration;
using OpenQA.Selenium.Support.PageObjects;

namespace AmazonSpecflow.Repository
{
   public static class SharedWebDriver
    {
        public static IWebDriver driver { get; set; }
        public static string url { get; set; }
        static SharedWebDriver()
        {
            Intialize();
            PageFactory.InitElements(driver, typeof(Support));
        }
        public static void Intialize()
        {
            try
            {
                string browser = ConfigurationManager.AppSettings.Get("browser");

                string env = ConfigurationManager.AppSettings.Get("environment");
                if (env.ToLower() == "local")
                {
                    url = ConfigurationManager.AppSettings.Get("devurl");
                }
                else
                {
                    url = ConfigurationManager.AppSettings.Get("produrl");
                }

                DesiredCapabilities cap;
                if (string.Equals(env, "Remote", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.Equals(browser, "firefox", StringComparison.OrdinalIgnoreCase))
                    {
                       // System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", "c://Users//openr//Desktop//Ravi//geckodriver.exe");
                       //cap = DesiredCapabilities.Firefox();
                       // cap.SetCapability("marionette", true);
                       // cap.SetCapability(CapabilityType.BrowserName, "firefox");
                       // cap.SetCapability(CapabilityType.Platform, "org.openqa.selenium.Platform.ANY");
                       // driver = new RemoteWebDriver(new Uri("http://192.168.2.49:4444/wd/hub"), cap);
                       // driver.Manage().Window.Maximize();
                    }
                    else if (string.Equals(browser, "chrome", StringComparison.OrdinalIgnoreCase))
                    {

                        ChromeOptions options = new ChromeOptions();
                        options.AddArguments("disable-infobars");
                        options.AddUserProfilePreference("credentials_enable_service", false);
                        options.AddUserProfilePreference("profile.password_manager_enabled", false);
                        driver = new  ChromeDriver(options);
                        cap = options.ToCapabilities() as DesiredCapabilities;
                        driver.Manage().Window.Maximize();

                    }
                    else if (string.Equals(browser, "ie", StringComparison.OrdinalIgnoreCase))
                    {
                        // cap = DesiredCapabilities.InternetExplorer();
                        //cap.SetCapability("ignoreProtectedModeSettings", true);
                        //cap.SetCapability(CapabilityType.BrowserName, "ie");
                        //cap.SetCapability(CapabilityType.Platform, "org.openqa.selenium.Platform.ANY");
                        //driver = new RemoteWebDriver(new Uri("http://192.168.2.49:4444/wd/hub"), cap);
                        //driver.Manage().Window.Maximize();
                    }
                    else if (string.Equals(browser, "safari", StringComparison.OrdinalIgnoreCase))
                    {
                         //cap = DesiredCapabilities.Safari();
                        //cap.SetCapability(CapabilityType.BrowserName, "safari");
                        //cap.SetCapability(CapabilityType.Platform, "org.openqa.selenium.Platform.WINDOWS");
                        //Console.WriteLine(System.Environment.GetEnvironmentVariable("user.dir"));
                        //driver = new RemoteWebDriver(new Uri("http://192.168.2.49:4444/wd/hub"), cap);
                        //driver.Manage().Window.Maximize();
                        //driver.Manage().Cookies.DeleteAllCookies();
                        //driver.Navigate().GoToUrl(url);
                    }
                }
                else if (string.Equals(env, "Mobile", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.Equals(browser, "chrome", StringComparison.OrdinalIgnoreCase))
                    {
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddAdditionalCapability("androidPackage", "com.android.chrome");
                        chromeOptions.AddAdditionalCapability("androidDeviceSerial", "HT4CBJT01080");
                        System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", System.Environment.GetEnvironmentVariable("user.dir") + "/src/test/resources/chromedriver");
                        driver = new ChromeDriver(chromeOptions);
                    }
                    else if (string.Equals(browser, "safari", StringComparison.OrdinalIgnoreCase))
                    {

                    }

                }
                // * To run tests in Local machine
                else
                {

                    if (string.Equals(browser, "firefox", StringComparison.OrdinalIgnoreCase))
                    {
                        //Console.WriteLine("In the ie block");
                        ///*FirefoxProfile prof = new FirefoxProfile();
                        //prof.setEnableNativeEvents(true);
                        //driver = new FirefoxDriver(prof);
                        //driver.manage().window().maximize()*/
                        //;
                        //System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", System.Environment.GetEnvironmentVariable("user.dir") + "/src/test/resources/geckodriver");
                        //DesiredCapabilities capabilities = DesiredCapabilities.Firefox();
                        //capabilities.SetCapability("marionette", true);
                        //driver = new FirefoxDriver(capabilities);
                        //driver.Manage().Cookies.DeleteAllCookies();
                        //driver.Manage().Window.Maximize();
                    }
                    else if (string.Equals(browser, "chrome", StringComparison.OrdinalIgnoreCase))
                    {
                        // System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", System.Environment.GetEnvironmentVariable("user.dir") + "/src/test/resources/chromedriver");

                        driver = new ChromeDriver();
                        Console.WriteLine("In the chrome block");
                        driver.Manage().Window.Maximize();
                    }
                    else if (string.Equals(browser, "ie", StringComparison.OrdinalIgnoreCase))
                    {
                        System.Environment.SetEnvironmentVariable("webdriver.ie.driver", System.Environment.GetEnvironmentVariable("user.dir") + "/src/test/resources/IEDriverServer.exe");
                        driver = new InternetExplorerDriver();
                        driver.Manage().Window.Maximize();
                    }
                    else if (string.Equals(browser, "safari", StringComparison.OrdinalIgnoreCase))
                    {
                        driver = new SafariDriver();
                        driver.Manage().Window.Maximize();
                    }
                }
            }
            catch (Exception e)
            {
                e.StackTrace.ToString();
            }

        }
    }
}
