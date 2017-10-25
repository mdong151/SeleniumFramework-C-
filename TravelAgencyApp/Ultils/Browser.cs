using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using TravelAgencyApp.Configurations;
using static TravelAgencyApp.Configurations.Types;

namespace TravelAgencyApp.Ultils
{
    public class Browser : BrowserBase
    {
        #region Hardcoded
        private static readonly By SearchingText = GetElementBy("xpath", "//li[contains(text(),'Searching…')]");
        #endregion
        private static readonly TestEnvironmentTypes TestEnvironment = AppConfigReader.GetTestEnvironment();
        private static int Timeout { get; } = AppConfigReader.GetTimeout();
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
        

        public static void GoToPage(string url,bool useBaseUrl = true)
        {
            string goToUrl = (useBaseUrl) ? "https://" + BaseUrl + url : url;
            Driver.Navigate().GoToUrl(goToUrl);
            if (useBaseUrl)
                Logger.Info("Navigate to " + "https://" + BaseUrl + url);
            else
                Logger.Info("Navigate to " + url);
        }

        public static void GoToPageWithCredentials(string url, bool useBase = true)
        {
            string username = AppConfigReader.GetUsername();
            string password = AppConfigReader.GetPassword();
            string goToUrl = (useBase) ? "https://" + username + ":" + password + "@" + BaseUrl + url 
                : "https://" + username + ":" + password + "@" + url.Substring(1, url.Length - 1);
            GoToPage(goToUrl, useBase);
        }

        public static void Close()
        {
            try
            {
                Driver.Quit();
                Logger.Info("Close Browser");
            }
            catch (Exception e)
            {
                Logger.Error("Cannot close Driver");
                Logger.Error(e.StackTrace);
                throw;
            }
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
            else if (how.ToLower().Contains("tagname"))
            {
                by = By.TagName(locator);
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
            string text = GetElement(how, locator).Text;
            Logger.Info("Get Text from element "+ locator + ": "+ text);
            return text;

        }

        public static string GetText(string how, string locator)
        {
            return GetText(how, locator, Timeout);
        }

        public static string GetText(By element,int timeoutInSeconds)
        {
            WaitUntilElementIsDisplayed(element,timeoutInSeconds);
            string text = GetElement(element).Text;
            Logger.Info("Get Text from element " + element + ": " + text);
            return text;
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
            ClearText(byElement);
            EnterText(byElement,textToType,timeoutInSeconds);
        }

        public static void ClearText(By byElement)
        {
            GetElement(byElement).Clear();
            Logger.Info("Clear text on element: "+ byElement);
        }
        public static void ClearAndEnterText(By byElement, string textToType)
        {
            ClearAndEnterText(byElement, textToType, Timeout);
        }

        public static void EnterText(string how, string locator, string textToType, int timeoutInSeconds )
        {
            WaitUntilElementIsDisplayed(how, locator, timeoutInSeconds);

            try
            {
                GetElement(how, locator).SendKeys(textToType);
                Logger.Info("Text "+ "'"+ textToType +"' typed on element: "+ how +"=" + locator);
            }
            catch (Exception e)
            {
                Logger.Error("Cannot enter text on element: "+ locator + " after "+ timeoutInSeconds + " seconds");
                Logger.Error(e.StackTrace);
                throw;
            }
        }

        public static void EnterText(string how, string locator, string textToType)
        {
            EnterText(how, locator, textToType, Timeout);
        }

        public static void EnterText(By byElement, string textToType, int timeoutInSeconds)
        {
            WaitUntilElementIsDisplayed(byElement,timeoutInSeconds);
            try
            {
                GetElement(byElement).SendKeys(textToType);
                Logger.Info("Text "+"'"+textToType+ "' typed on element " + byElement);
            }
            catch (Exception e)
            {
                Logger.Error("Could not set text to element "+ byElement);
                Logger.Error(e.StackTrace);
                throw;
            }
        }

        public static void EnterText(By byElement, string textToType)
        {
            EnterText(byElement, textToType, Timeout);
        }

        public static void PressEnter(string how,string locator)
        {
            try
            {
                GetElement(how, locator).SendKeys(Keys.Enter);
                Logger.Info("Press Enter on element: "+ locator);
            }
            catch (Exception e)
            {
                Logger.Error("Cannot press Enter on element: "+ locator);
                Logger.Error(e.StackTrace);
                throw;
            }
        }

        public static void PressEnter(By byElement)
        {
            GetElement(byElement).SendKeys(Keys.Enter);
        }

        public static void Select(string how, string locator,int timeoutInSeconds)
        {
            WaitUntilElementIsDisplayed(how, locator, timeoutInSeconds);
            GetElement(how, locator).Click();
            Logger.Info("Click on element "+ locator);
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
                    Logger.Info("Element "+ how + "=" + locator + " is displayed");
                    return true;
                }
                Thread.Sleep(1000);
                Logger.Info("wait for " + i + " seconds," + " Element " + locator + " is not display..");
            }
            Logger.Info("Element "+ locator +" is not display after "+timeoutInSeconds+" seconds");
            return false;
        }

        public static bool WaitUntilElementIsDisplayed(string how, string locator)
        {
            return WaitUntilElementIsDisplayed(how, locator, Timeout);
        }

        public static bool WaitUntilElementIsDisplayed(By byElement, int timeoutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(byElement));
            }
            catch (Exception e)
            {
                Logger.Error("Element " + byElement + "is NOT displayed.Below is exception");
                Logger.Error(e.StackTrace);
                throw;
            }
            Logger.Info("Element " + byElement + " is displayed");
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
            Logger.Info("Maximize Browser window");
        }

        public static void WaitFor(int seconds)
        {
            var miliseconds = seconds * 1000;
            Thread.Sleep(miliseconds);
        }

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
            WaitUntilElementIsInvisibled(SearchingText, timeoutInSeconds);
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
            WaitUntilElementIsInvisibled(SearchingText, timeoutInSeconds);
            PressEnter(byElement);
        }

        public static void SearchAndSelect(By byElement, string textToSearch)
        {
            SearchAndSelect(byElement, textToSearch, Timeout);
        }

        public static void SelectValueFromDropdown(string how, string locator, string value)
        {
            WaitUntilElementIsDisplayed(how, locator, Timeout);
            new SelectElement(GetElement(how, locator)).SelectByText(value);
        }

        

        public static void SelectValueFromDropdown(By byElement, string value)
        {
            WaitUntilElementIsDisplayed(byElement, Timeout);
            Select(byElement);
            WaitUntilElementIsDisplayed(By.XPath("//div[@role='option']"));
            ReadOnlyCollection<IWebElement> options = Driver.FindElements(By.XPath("//div[@role='option']"));
            foreach (IWebElement option in options)
            {
                if (value == option.Text)
                {
                    option.Click();
                    break;
                }
            }

        }
        public static void Initialize()
        {
            InitWebDriver();
            Logger.Info("Browser opened");
        }
    }
}