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

        //[FindsBy(How = How.XPath, Using = "//div[@class='blockUI blockOverlay']")]
        //public IWebElement loaddingOverlayObject { get; set; }

        public By LoaddingOverlayObject { get { return By.XPath("//div[@class='blockUI blockOverlay']"); } }

        public By PlaneRadio { get { return By.XPath("//input[@id='radio_Flight']/following-sibling::div"); } }

        public By UserMenuButton { get { return By.Id("userMenu"); } }

        public By UserMenuSearchField { get { return By.Id("s2id_autogen18_search"); } }

        public By SearchingLabel { get { return By.XPath("//li[.='Searching…']"); } }

        public By TravellerSearchField { get { return By.Id("s2id_autogen3"); }  }

        public By AnyTransportRadio { get { return By.XPath("//input[@id='radio_any_Transport']/following-sibling::div"); } }

        public By TrainRadio { get { return By.XPath("//input[@id='radio_Train']/following-sibling::div"); } }

        public By CarRentalCheckbox { get { return By.XPath("//input[@id='checkBox_CarRental']/following-sibling::div"); } }

        public By TaxiCheckbox { get { return By.XPath("//input[@id='checkBox_Taxi']/following-sibling::div"); } }

        public By HotelCheckbox { get { return By.XPath("//input[@id='checkBox_Hotel']/following-sibling::div"); } }

        public By StartDateField { get { return By.Id("FromDateTimeAllModule"); } }

        public By EndDateField { get { return By.Id("ToDateTimeAllModule"); } }

        public By FromField { get { return By.Id("select2-chosen-4"); } }

        public By ToField { get { return By.Id("select2-chosen-5"); } }

        public By FirstContinueButton { get { return By.Id("btnNextFirstPage"); } }

    }
}
