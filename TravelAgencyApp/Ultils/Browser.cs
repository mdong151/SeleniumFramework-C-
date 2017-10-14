using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TravelAgencyApp.Configurations;


namespace TravelAgencyApp.Ultils
{
    public class Browser
    {
        private static readonly BrowserTypes BrowserType = AppConfigReader.GetBrowser();
        private static readonly TestEnvironmentTypes TestEnvironment = AppConfigReader.GetTestEnvironment();
        public static IWebDriver Driver { get; private set; }
        private static int Timeout { get; set; } = AppConfigReader.GetTimeout();
        public static string Title { get; } = Driver.Title;

        private static string BaseUrl
        {
            get
            {
                switch (TestEnvironment)
                {
                    case TestEnvironmentTypes.Inte:
                        return "inte.amaris.com/TravelAgency";
                    case TestEnvironmentTypes.Qa:
                        return "qaarp.amaris.com/TravelAgency";
                    case TestEnvironmentTypes.Product:
                        return "arp.amaris.com/TravelAgency";
                    default:
                        return null;
                }
            }
        }

        public static void Initialize()
        {
            switch (BrowserType)
            {
                case BrowserTypes.InternetExplorer:
                    Driver = new InternetExplorerDriver(@"C:\Users\MNG06\Documents\Visual Studio Code\Amaris\SeleniumFramework\Drivers");
                    break;
                case BrowserTypes.Chrome:
                    Driver = new ChromeDriver(@"C:\Users\MNG06\Documents\Visual Studio Code\Amaris\SeleniumFramework\Drivers");
                    break;
                case BrowserTypes.Firefox:
                    Driver = new FirefoxDriver();
                    break;
                default:
                    Driver = null;
                    break;
            }
        }

        public static void GoToPage(string url,bool useBaseUrl = true)
        {
            string goToUrl = (useBaseUrl) ? "https://" + BaseUrl + url : url;
            Driver.Navigate().GoToUrl(goToUrl);           
        }

        public static void GoToPageWithCredentials(string url, bool useBase = true)
        {
            string username = AppConfigReader.GetUsername();
            string password = AppConfigReader.GetPassword();
            string goToUrl = (useBase) ? "https://" + username + ":" + password + "@" + BaseUrl + url 
                : "https://" + username + ":" + password + "@" + url.Substring(1, url.Length - 1);
            Driver.Navigate().GoToUrl(goToUrl);
        }

        public static void Close()
        {
            Driver.Close();
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
            return Driver.FindElement(GetElementBy(how, locator));

        }
        public static IWebElement GetElement(By byElement)
        {
            return Driver.FindElement(byElement);
        }

        public static string GetText(string how, string locator,int timeoutInSeconds)
        {
            WaitUntilElementIsDisplayed(how, locator, timeoutInSeconds);
            return GetElement(how, locator).Text;
        }

        public static string GetText(string how, string locator)
        {
            return GetText(how, locator, Timeout);
        }

        public static string GetText(By element,int timeoutInSeconds)
        {
            WaitUntilElementIsDisplayed(element,timeoutInSeconds);
            return GetElement(element).Text;
        }

        public static string GetText(By byElement)
        {
            return GetText(byElement,Timeout);
        }

        public static void ClearAndEnterText(string how, string locator,string textToType,int timeoutInSeconds)
        {
            WaitUntilElementIsDisplayed(how, locator, timeoutInSeconds);
            GetElement(how, locator).Clear();
            GetElement(how, locator).SendKeys(textToType);
        }

        public static void ClearAndEnterText(string how, string locator, string textToType)
        {
            ClearAndEnterText(how, locator, textToType, Timeout);
        }

        public static void ClearAndEnterText(By byElement, string textToType, int timeoutInSeconds)
        {
            WaitUntilElementIsDisplayed(byElement, timeoutInSeconds);
            GetElement(byElement).Clear();
            GetElement(byElement).SendKeys(textToType);
        }

        public static void ClearAndEnterText(By byElement, string textToType)
        {
            ClearAndEnterText(byElement, textToType, Timeout);
        }

        public static void EnterText(string how, string locator, string textToType, int timeoutInSeconds )
        {
            WaitUntilElementIsDisplayed(how, locator, timeoutInSeconds);
            GetElement(how, locator).SendKeys(textToType);
        }

        public static void EnterText(string how, string locator, string textToType)
        {
            EnterText(how, locator, textToType, Timeout);
        }

        public static void EnterText(By byElement, string textToType, int timeoutInSeconds)
        {
            WaitUntilElementIsDisplayed(byElement,timeoutInSeconds);
            GetElement(byElement).SendKeys(textToType);
        }

        public static void EnterText(By byElement, string textToType)
        {
            EnterText(byElement, textToType, Timeout);
        }

        public static void PressEnter(string how,string locator)
        {
            GetElement(how, locator).SendKeys(Keys.Enter);
        }

        public static void PressEnter(By byElement)
        {
            GetElement(byElement).SendKeys(Keys.Enter);
        }

        public static void Select(string how, string locator,int timeoutInSeconds)
        {
            WaitUntilElementIsDisplayed(how, locator, timeoutInSeconds);
            GetElement(how, locator).Click();
        }

        public static void Select(string how, string locator)
        {
            Select(how, locator, Timeout);
        }

        public static void Select(By byElement,int timeoutInSeconds)
        {
            WaitUntilElementIsDisplayed(byElement,timeoutInSeconds);
            GetElement(byElement).Click();
        }

        public static void Select(By byElement)
        {
            Select(byElement, Timeout);
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

        public static bool WaitUntilElementIsDisplayed(string how, string locator)
        {
            return WaitUntilElementIsDisplayed(how, locator, Timeout);
        }

        public static bool WaitUntilElementIsDisplayed(By byElement, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(byElement));
            return false;
        }

        public static bool WaitUntilElementIsDisplayed(By byElement)
        {
            return WaitUntilElementIsDisplayed(byElement, Timeout);
        }

        public static bool ElementIsDisplayed(string how,string locator)
        {
            var isDisplayed = false;
            try
            {
                isDisplayed = GetElement(how, locator).Displayed;
            }
            catch (NoSuchElementException) { }
            return isDisplayed;
        }

        public static bool IsAt(string pageTitle)
        {
            return Driver.Title.Contains(pageTitle);
        }

        public static void SwitchToTab(int tabIndex)
        {
            var windows = Driver.WindowHandles;
            Driver.SwitchTo().Window(windows[tabIndex]);
        }

        public static void Maximize()
        {
            Driver.Manage().Window.Maximize();
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

        public static bool WaitUntilElementIsInvisibled(string how, string locator, int timeoutInSeconds)
        {
            WaitUntilElementIsDisplayed(how, locator, timeoutInSeconds);
            var wait = new WebDriverWait(Driver,TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(GetElementBy(how,locator)));
        }

        public static bool WaitUntilElementIsInvisibled(string how, string locator)
        {
            return WaitUntilElementIsInvisibled(how, locator, Timeout);
        }

        public static bool WaitUntilElementIsInvisibled(By byElement, int timeoutInSeconds)
        {
            WaitUntilElementIsDisplayed(byElement, timeoutInSeconds);
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(byElement));
        }

        public static bool WaitUntilElementIsInvisibled(By byElement)
        {
            return WaitUntilElementIsInvisibled(byElement, Timeout);
        }

        //to handle Travel Agency search field 
        public static void SearchAndSelect(string how, string locator, string textToSearch,int timeoutInSeconds)
        {
            WaitUntilElementIsDisplayed(how, locator, timeoutInSeconds);
            EnterText(how, locator, textToSearch);
            WaitUntilElementIsInvisibled("xpath", "//li[contains(text(),'Searching…')]", timeoutInSeconds);
            PressEnter(how, locator);
        }

        public static void SearchAndSelect(string how, string locator, string textToSearch)
        {
            SearchAndSelect(how, locator, textToSearch, Timeout);
        }

        public static void SearchAndSelect (By byElement, string textToSearch,int timeoutInSeconds)
        {
            WaitUntilElementIsDisplayed(byElement,timeoutInSeconds);
            EnterText(byElement,textToSearch);
            WaitUntilElementIsInvisibled("xpath", "//li[contains(text(),'Searching…')]", timeoutInSeconds);
            PressEnter(byElement);
        }

        public static void SearchAndSelect(By byElement, string textToSearch)
        {
            SearchAndSelect(byElement, textToSearch, Timeout);
        }

        public static void SelectDropdown(string how, string locator, string value)
        {
            new SelectElement(GetElement(how, locator)).SelectByText(value);
        }
    }
}