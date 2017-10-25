
using System.CodeDom;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using TravelAgencyApp.Configurations;
using TravelAgencyApp.CustomExceptions;
using static TravelAgencyApp.Configurations.Types;

namespace TravelAgencyApp.Ultils
{
    [TestClass]
    public class BrowserBase
    {
        #region Property
        private static IWebDriver _driver;
        internal static readonly ILog Logger = Log4Net.GetXmlLogger(typeof(Browser));
        private static readonly BrowserTypes BrowserType = AppConfigReader.GetBrowser();
        public static IWebDriver Driver { get { return _driver; } }
        #endregion
        

        #region Private
        private static IWebDriver GetInternetExplorerDriver()
        {
            IWebDriver driver = new InternetExplorerDriver(@"C:\Users\MNG06\Documents\Visual Studio Code\Amaris\SeleniumFramework\Drivers", GetInternetExplorerOption());
            return driver;
        }
        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\MNG06\Documents\Visual Studio Code\Amaris\SeleniumFramework\Drivers");
            return driver;
        }
        private static IWebDriver GetFirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver();
            return driver;
        }
        private static InternetExplorerOptions GetInternetExplorerOption()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.RequireWindowFocus = true;
            return options;
            
        }
        #endregion

        #region Public
        [AssemblyInitialize]
        public static void InitWebDriver(TestContext tc)
        {
            switch (BrowserType)
            {
                case BrowserTypes.InternetExplorer:
                    _driver = GetInternetExplorerDriver();
                    Logger.Info("(AssemblyInitialize) InternetExplorer browser");
                    break;
                case BrowserTypes.Chrome:
                    _driver = GetChromeDriver();
                    Logger.Info("(AssemblyInitialize) Chrome browser");
                    break;
                case BrowserTypes.Firefox:
                    _driver = GetFirefoxDriver();
                    Logger.Info("(AssemblyInitialize) Firefox browser");
                    break;
                default:
                    Logger.Error("(AssemblyInitialize) Cannot Initialized browser");
                    throw new NoSuitableDriverFoundException("Browser not supported"+ BrowserType);
            }
        }
        public static void InitWebDriver()
        {
            switch (BrowserType)
            {
                case BrowserTypes.InternetExplorer:
                    _driver = GetInternetExplorerDriver();
                    break;
                case BrowserTypes.Chrome:
                    _driver = GetChromeDriver();
                    break;
                case BrowserTypes.Firefox:
                    _driver = GetFirefoxDriver();
                    break;
            }
        }
        #endregion

    }
}
