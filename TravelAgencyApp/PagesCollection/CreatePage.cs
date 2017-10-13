using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgencyApp.Ultilities;
using TravelAgencyApp.Objects;

namespace TravelAgencyApp.PagesCollection
{
    public class CreatePage : CreatePageObjects
    {
        #region constant
        private int PAGE_TIME_OUT = 30;
        #endregion
        public void GoTo()
        {
            Browser.GoTo("https://mnguyen3@amaris.com:Amaris2017@inte.amaris.com/TravelAgency/Create", false);
            Browser.WaitUntilElementIsInvisibled(LoaddingOverlayObject, PAGE_TIME_OUT);
        }
         
        public void FakeAuthenTo(string user)
        {
            string currentUser = UserMenuButton.GetText();
            if (!currentUser.Trim().ToLower().Contains(user.Trim().ToLower()))
            {
                UserMenuButton.Select();
                Browser.SearchAndSelect(UserMenuSearchField, user, PAGE_TIME_OUT);
                Browser.WaitUntilElementIsInvisibled(LoaddingOverlayObject, PAGE_TIME_OUT);
            }
        }

        public void FillPlanTrip(
            string travelType,string traveller,
            string mainTransportType,
            string startDate,string endDate,
            string fromPlace,string toPlace,
            string additionalServices = null
            )
        {
            //
            //TODO: inmplement Traveltype selection
            //
            Browser.SearchAndSelect(TravellerSearchField, traveller, PAGE_TIME_OUT);
            Browser.WaitUntilElementIsInvisibled(LoaddingOverlayObject, PAGE_TIME_OUT);
            
            if (mainTransportType.ToLower().Contains("any"))
            {
                AnyTransportRadio.Select();
                AnyTransportFromPlaceField.Select();
                AnyTransportFromPlaceSearchField.SearchAndSelect(fromPlace);
                AnyTransportToPlaceField.Select();
                AnyTransportToPlaceSearchField.SearchAndSelect(toPlace);

            }
            else if (mainTransportType.ToLower().Contains("plane"))
            {
                PlaneRadio.Select();
                PlaneFromPlaceField.Select();
                PlaneFromPlaceSearchField.SearchAndSelect(fromPlace);
                PlaneToPlaceField.Select();
                PlaneToPlaceSearchField.SearchAndSelect(toPlace);
            }
            else if (mainTransportType.ToLower().Contains("train"))
            {
                TrainRadio.Select();
                TrainFromPlaceField.Select();
                TrainFromPlaceSearchField.SearchAndSelect(fromPlace);
                TrainToPlaceField.Select();
                TrainToPlaceSearchField.SearchAndSelect(toPlace);
            }

            StartDateField.ClearAndEnterText(startDate);
            EndDateField.ClearAndEnterText(endDate);

            //
            //TODO : implement additional services
            //

            

        }
        public void submitPlanATripForm(bool isHurry = true)
        {
            if (isHurry == true)
            {
                ImInAHurryButton.Select();
            }
            else if (isHurry == false)
            {
                FirstContinueButton.Select();
            }
        }
        public string getPopupMessage()
        {
            string message = PopupMessage.GetText();
            return message;
        }
 
    }
}