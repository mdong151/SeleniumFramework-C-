using OpenQA.Selenium;
using TravelAgencyApp.Ultilities;

namespace TravelAgencyApp.Objects
{
    public class CreatePageObjects
    {

        //[FindsBy(How = How.XPath, Using = "//div[@class='blockUI blockOverlay']")]
        //public IWebElement loaddingOverlayObject { get; set; }

        //public By LoaddingOverlayObject { get { return By.XPath("//div[@class='blockUI blockOverlay']"); } }

        public By LoaddingOverlayObject = Browser.GetElementBy("xpath", "//div[@class='blockUI blockOverlay']");

        public By PlaneRadio = Browser.GetElementBy("xpath", "//input[@id='radio_Flight']/following-sibling::div");

        public By UserMenuButton { get { return By.Id("userMenu"); } }

        public By UserMenuSearchField { get { return By.Id("s2id_autogen18_search"); } }

        public By SearchingLabel { get { return By.XPath("//li[.='Searching…']"); } }

        public By TravellerSearchField { get { return By.Id("s2id_autogen3"); }  }

        public By AnyTransportRadio { get { return By.XPath("//input[@id='radio_any_Transport']/following-sibling::div"); } }

        public By TrainRadio { get { return By.XPath("//input[@id='radio_Train']/following-sibling::div"); } }

        public By CarRentalCheckbox { get { return By.XPath("//input[@id='checkBox_CarRental']/following-sibling::div"); } }

        public By TaxiCheckbox { get { return By.XPath("//input[@id='checkBox_Taxi']/following-sibling::div"); } }

        public By HotelCheckbox { get { return By.XPath("//input[@id='checkBox_Hotel']/following-sibling::div"); } }

        public By StartDateField { get { return By.XPath("//div[@id='FromDateTimeAllModule']/input[@class='datepickerinput form-control']"); } }

        public By EndDateField { get { return By.XPath("//div[@id='ToDateTimeAllModule']/input[@class='datepickerinput form-control']"); } }

        public By PlaneFromPlaceField { get { return By.Id("select2-chosen-4"); } }
        public By PlaneFromPlaceSearchField { get { return By.Id("s2id_autogen4_search"); } }

        public By PlaneToPlaceField { get { return By.Id("select2-chosen-5"); } }
        public By PlaneToPlaceSearchField { get { return By.Id("s2id_autogen5_search"); } }

        public By AnyTransportFromPlaceField = Browser.GetElementBy("id", "select2-chosen-6");
        public By AnyTransportFromPlaceSearchField = Browser.GetElementBy("id", "s2id_autogen6_search");

        public By AnyTransportToPlaceField = Browser.GetElementBy("id", "select2-chosen-7");
        public By AnyTransportToPlaceSearchField = Browser.GetElementBy("id", "s2id_autogen7_search");

        public By TrainFromPlaceField = Browser.GetElementBy("id", "select2-chosen-6");
        public By TrainFromPlaceSearchField = Browser.GetElementBy("id", "s2id_autogen6_search");

        public By TrainToPlaceField = Browser.GetElementBy("id", "select2-chosen-7");
        public By TrainToPlaceSearchField = Browser.GetElementBy("id", "s2id_autogen7_search");

        public By FirstContinueButton { get { return By.Id("btnNextFirstPage"); } }

        public By ImInAHurryButton = Browser.GetElementBy("id", "btnSubmitWithoutInformation");

        public By PopupMessage = Browser.GetElementBy("xpath", "//p[@class='content']");
    }
}
