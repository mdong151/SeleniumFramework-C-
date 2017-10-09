using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyApp
{
    public class CreatePageObjects
    {
        public CreatePageObjects()
        {
            PageFactory.InitElements(Browser.Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='blockUI blockOverlay']")]
        public IWebElement loaddingOverlayObject { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='radio_Flight']/following-sibling::div")]
        public IWebElement planeRadio { get; set; }

        [FindsBy(How = How.Id,Using = "userMenu")]
        public IWebElement userMenuButton { get; set; }

        [FindsBy(How = How.Id, Using = "s2id_autogen18_search")]
        public IWebElement userMenuSearchField { get; set; }

        [FindsBy(How = How.XPath,Using = "//li[.='Searching…']")]
        public IWebElement searchingLabel { get; set; }

        [FindsBy(How = How.Id, Using = "s2id_autogen3")]
        public IWebElement travellerSearchField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='radio_any_Transport']/following-sibling::div")]
        public IWebElement anyTransportRadio { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='radio_Train']/following-sibling::div")]
        public IWebElement trainRadio { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='checkBox_CarRental']/following-sibling::div")]
        public IWebElement carRentalCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='checkBox_Taxi']/following-sibling::div")]
        public IWebElement taxiCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='checkBox_Hotel']/following-sibling::div")]
        public IWebElement hotelCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "FromDateTimeAllModule")]
        public IWebElement startDateField { get; set; }

        [FindsBy(How = How.Id, Using = "ToDateTimeAllModule")]
        public IWebElement endDateField { get; set; }
    }
}
