using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace TravelAgencyApp.Ultilities
{
    public static class Browser
    {
        private static IWebDriver _webDriver = new ChromeDriver(@"C:\Users\MNG06\Documents\Visual Studio Code\Amaris\SeleniumFramework\Drivers");
        //private static IWebDriver _webDriver = new InternetExplorerDriver(@"C:\Users\MNG06\Documents\Visual Studio Code\Amaris\SeleniumFramework\Drivers");
        private static string _baseUrl = "";

        private const int TIME_OUT = 10;
        
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
            else if (how.ToLower().Contains("linktext"))
            {
                by = By.LinkText(locator);
            }
            else if (how.ToLower().Contains("class"))
            {
                by = By.ClassName(locator);
            }
            return by;
        }

        public static IWebElement GetElement(string how,string locator)
        {
            IWebElement ele = null;
            ele = _webDriver.FindElement(GetElementBy(how, locator));
            return ele;
        }
        public static IWebElement GetElement(this By element,int timeout = TIME_OUT)
        {
            return _webDriver.FindElement(element);
        }

        public static string GetText(string how, string locator,int timeoutInSeconds = TIME_OUT)
        {
            WaitUntilElementIsDisplayed(how, locator, timeoutInSeconds);
            string text;
            text = GetElement(how, locator).Text;
            return text;
        }

        public static string GetText(this By element,int timeoutInSeconds = TIME_OUT)
        {
            element.WaitUntilElementIsDisplayed(timeoutInSeconds);
            string text;
            text = element.GetElement().Text;
            return text;
        }

        public static void EnterText(string how, string locator,string textToType,int timeoutInSeconds = TIME_OUT)
        {
            WaitUntilElementIsDisplayed(how, locator, timeoutInSeconds);
            GetElement(how, locator).Clear();
            GetElement(how, locator).SendKeys(textToType);
        }
        public static void EnterText(this By byElement, string textToType,int timeoutInSeconds = TIME_OUT)
        {
            byElement.WaitUntilElementIsDisplayed(timeoutInSeconds);
            byElement.GetElement().Clear();
            byElement.GetElement().SendKeys(textToType);
        }
        public static void PressEnter(string how,string locator)
        {
            GetElement(how, locator).SendKeys(Keys.Enter);
        }

        public static void PressEnter(this By byElement)
        {
            GetElement(byElement).SendKeys(Keys.Enter);
        }

        public static void Select(string how, string locator,int timeoutInSeconds = TIME_OUT)
        {
            WaitUntilElementIsDisplayed(how, locator, timeoutInSeconds);
            GetElement(how, locator).Click();
        }

        public static void Select(this By byElement,int timeoutInSeconds = TIME_OUT)
        {
            byElement.WaitUntilElementIsDisplayed(timeoutInSeconds);
            byElement.GetElement().Click();
        }


        public static bool WaitUntilElementIsDisplayed(string how,string locator,int timeoutInSeconds = TIME_OUT)
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

        public static bool WaitUntilElementIsDisplayed(this By byElement, int timeoutInSeconds = TIME_OUT)
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(byElement));
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

        //public static void Authenticate(string username,string password)
        //{
        //    WaitFor(5);
        //    _webDriver.SwitchTo().Alert().SetAuthenticationCredentials(username,password);
        //}

        public static bool WaitUntilElementIsInvisibled(string how, string locator, int timeoutInSeconds = TIME_OUT)
        {
            WaitUntilElementIsDisplayed(how, locator, 30);
            var wait = new WebDriverWait(_webDriver,TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(GetElementBy(how,locator)));
        }

        public static bool WaitUntilElementIsInvisibled(this By byElement, int timeoutInSeconds = TIME_OUT)
        {
            WaitUntilElementIsDisplayed(byElement, timeoutInSeconds);
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(byElement));
        }

        //to handle Travel Agency search field 
        public static void SearchAndSelect(string how, string locator, string textToSearch,int timeoutInSeconds = TIME_OUT)
        {
            WaitUntilElementIsDisplayed(how, locator, timeoutInSeconds);
            EnterText(how, locator, textToSearch);
            WaitUntilElementIsInvisibled("xpath", "//li[contains(text(),'Searching…')]", timeoutInSeconds);
            PressEnter(how, locator);
        }

        public static void SearchAndSelect (this By byElement, string textToSearch,int timeoutInSeconds = TIME_OUT)
        {
            byElement.WaitUntilElementIsDisplayed(timeoutInSeconds);
            byElement.EnterText(textToSearch);
            WaitUntilElementIsInvisibled("xpath", "//li[contains(text(),'Searching…')]", timeoutInSeconds);
            byElement.PressEnter();
        }

        public static void SelectDropdown(string how, string locator, string value)
        {
            new SelectElement(GetElement(how, locator)).SelectByText(value);
        }
    }
}