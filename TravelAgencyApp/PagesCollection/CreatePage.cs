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
            if (!currentUser.ToLower().Contains(user))
            {
                UserMenuButton.Select();
                Browser.SearchAndSelect(UserMenuSearchField, user, PAGE_TIME_OUT);
                Browser.WaitUntilElementIsInvisibled(LoaddingOverlayObject, PAGE_TIME_OUT);
            }
        }

        public void FillPlanTrip()
        {
            Browser.SearchAndSelect(TravellerSearchField, "nguyen manh dong", PAGE_TIME_OUT);
            Browser.WaitUntilElementIsInvisibled(LoaddingOverlayObject, PAGE_TIME_OUT);
        }
    }
}