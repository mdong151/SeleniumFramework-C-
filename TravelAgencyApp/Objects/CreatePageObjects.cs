using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyApp.Objects
{
    public class CreatePageObjects
    {
        public CreatePageObjects()
        {
            PageFactory.InitElements(Browser.Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='blockUI blockOverlay']")]
        public IWebElement LoaddingOverlayObject { get; set; }
    }
}
