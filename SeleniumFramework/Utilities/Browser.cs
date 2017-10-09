using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SeleniumFramework
{
    public static class Browser
    {
        private static IWebDriver _webDriver = new ChromeDriver(@"C:\Users\MNG06\Documents\Visual Studio Code\Amaris\SeleniumFramework\Drivers");
        //private static IWebDriver _webDriver = new InternetExplorerDriver(@"C:\Users\MNG06\Documents\Visual Studio Code\Amaris\SeleniumFramework\Drivers");
        private static string _baseUrl = "";
        //private static string _baseUrl = "https://inte.amaris.com/TravelAgency/";

        public static ISearchContext Driver { get { return _webDriver; } }
        public static string Title { get { return _webDriver.Title; } }
 
        public static void Initialize()
        {
            GoTo("");
        }

        public static void GoTo(string url,bool useBaseUrl = true)
        {
            if (useBaseUrl == true)
            {
                _webDriver.Navigate().GoToUrl(_baseUrl + url);
            }
            else
            {
                _webDriver.Navigate().GoToUrl(url);
            }
            
        }

        public static void Close()
        {
            _webDriver.Close();
        }

        public static By GetElementBy(string how,string locator)
        {
            By by = null;
            if (how.ToLower().Contains("xpath"))
            {
                by = By.XPath(locator);
            }
            else if (how.ToLower().Contains("id"))
            {
                by = By.Id(locator);
            }
            else if (how.ToLower().Contains("name"))
            {
                by = By.Name(locator);
            }
            else if (how.ToLower().Contains("css"))
            {
                by = By.CssSelector(locator);
            }
            return by;
        }

        public static IWebElement GetElement(string how,string locator)
        {
            IWebElement ele = null;
            ele = _webDriver.FindElement(GetElementBy(how, locator));
            return ele;
        }

        public static string GetText(string how, string locator)
        {
            string text;
            text = GetElement(how, locator).Text;
            return text;
        }

        public static void EnterText(string how, string locator,string textToType)
        {
            GetElement(how, locator).Clear();
            GetElement(how, locator).SendKeys(textToType);
        }
        public static void EnterText(this IWebElement element, string textToType)
        {
            element.Clear();
            element.SendKeys(textToType);
        }
        public static void PressEnter(string how,string locator)
        {
            GetElement(how, locator).SendKeys(Keys.Enter);
        }
        
        public static void Select(string how, string locator)
        {
            GetElement(how, locator).Click();
        }

        public static void Select(this IWebElement element)
        {
            element.Click();
        }


        public static bool WaitUntilElementIsDisplayed(string how,string locator,int timeoutInSeconds)
        {
            for(int i = 0; i < timeoutInSeconds; i++)
            {
                if (ElementIsDisplayed(how, locator))
                {
                    return true;
                }
                Thread.Sleep(1000);
            }
            return false;
        }

        public static bool ElementIsDisplayed(string how,string locator)
        {
            var isDisplayed = false;
            //_webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            try
            {
                isDisplayed = GetElement(how, locator).Displayed;
            }
            catch (NoSuchElementException) { }
            //_webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return isDisplayed;
        }

        public static bool IsAt(string pageTitle)
        {
            return _webDriver.Title.Contains(pageTitle);
        }

        public static void SwitchToTab(int tabIndex)
        {
            var windows = _webDriver.WindowHandles;
            _webDriver.SwitchTo().Window(windows[tabIndex]);
        }

        public static void Maximize()
        {
            _webDriver.Manage().Window.Maximize();
        }

        public static void WaitFor(int seconds)
        {
            var miliseconds = seconds * 1000;
            Thread.Sleep(miliseconds);
        }

        public static void Authenticate(string username,string password)
        {
            WaitFor(5);
            _webDriver.SwitchTo().Alert().SetAuthenticationCredentials(username,password);
        }

        public static bool WaitUntilElementIsInvisibled(string how, string locator, int timeout)
        {
            WaitUntilElementIsDisplayed(how, locator, 30);
            var wait = new WebDriverWait(_webDriver,TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(GetElementBy(how,locator)));
        }
        public static bool WaitUntilElementIsInvisibled(IWebElement element, int timeout)
        {

            return true;
        }

        //to handle Travel Agency search field 
        public static void SearchAndSelect(string how, string locator, string textToSearch,int timeout)
        {
            WaitUntilElementIsDisplayed(how, locator,timeout);
            Browser.EnterText(how, locator, textToSearch);
            Browser.WaitUntilElementIsInvisibled("xpath", "//li[contains(text(),'Searching…')]", timeout);
            Browser.PressEnter(how, locator);
        }

        public static void SelectDropdown(string how, string locator, string value)
        {
            new SelectElement(GetElement(how, locator)).SelectByText(value);
        }
    }
}