using TravelAgencyApp.Ultils;
using TravelAgencyApp.ObjectsCollection;

namespace TravelAgencyApp.PagesCollection
{
    public class CreatePage : CreatePageObjects
    {

        public void GoTo()
        {
            Browser.GoToPageWithCredentials("/create");
            Browser.WaitUntilElementIsInvisibled(LoaddingOverlayObject);
        }
         
        public void FakeAuthenTo(string user)
        {
            string currentUser = Browser.GetText(UserMenuButton);
            if (!currentUser.Trim().ToLower().Contains(user.Trim().ToLower()))
            {
                Browser.Select(UserMenuButton);
                Browser.SearchAndSelect(UserMenuSearchField, user);
                Browser.WaitUntilElementIsInvisibled(LoaddingOverlayObject);
            }
        }

        public void FillPlanTrip(
            string travelType,
            string traveller,
            string mainTransportType,
            string startDate,string endDate,
            string fromPlace,string toPlace,
            string additionalServices = null)
        {

            //
            //TODO: inmplement Traveltype selection
            //
            //Browser.WaitFor(10);
            //Browser.SelectValueFromDropdown(TravelTypeDropDown, travelType);
            //Browser.WaitUntilElementIsInvisibled(LoaddingOverlayObject);

            Browser.SearchAndSelect(TravellerSearchField, traveller);
            Browser.WaitUntilElementIsInvisibled(LoaddingOverlayObject);
            
            if (mainTransportType.ToLower().Contains("any"))
            {
                Browser.Select(AnyTransportRadio);
                Browser.Select(AnyTransportFromPlaceField);
                Browser.SearchAndSelect(AnyTransportFromPlaceSearchField,fromPlace);
                Browser.Select(AnyTransportToPlaceField);
                Browser.SearchAndSelect(AnyTransportToPlaceSearchField,toPlace);
            }
            else if (mainTransportType.ToLower().Contains("plane"))
            {
                Browser.Select(PlaneRadio);
                Browser.Select(PlaneFromPlaceField);
                Browser.SearchAndSelect(PlaneFromPlaceSearchField,fromPlace);
                Browser.Select(PlaneToPlaceField);
                Browser.SearchAndSelect(PlaneToPlaceSearchField,toPlace);
            }
            else if (mainTransportType.ToLower().Contains("train"))
            {
                Browser.Select(TrainRadio);
                Browser.Select(TrainFromPlaceField);
                Browser.SearchAndSelect(TrainFromPlaceSearchField,fromPlace);
                Browser.Select(TrainToPlaceField);
                Browser.SearchAndSelect(TrainToPlaceSearchField,toPlace);
            }
            Browser.ClearAndEnterText(StartDateField,startDate);
            Browser.ClearAndEnterText(EndDateField,endDate);

            //
            //TODO : implement additional services
            //

        }
        public void SubmitPlanATripForm(bool isHurry = true)
        {
            Browser.Select(isHurry ? ImInAHurryButton : FirstContinueButton);
        }
        public string GetPopupMessageText()
        {
            return Browser.GetText(PopupMessage);
        }
 
    }
}