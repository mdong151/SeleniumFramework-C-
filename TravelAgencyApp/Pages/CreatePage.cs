using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumFramework;

namespace TravelAgencyApp
{
    public class CreatePage : CreatePageObjects
    {
        #region constant
        private int PAGE_TIME_OUT = 30;
        #endregion
        public void GoTo()
        {
            Browser.GoTo("https://mnguyen3@amaris.com:Amaris2017@inte.amaris.com/TravelAgency/Create", false);
            
        }
         
        public void FakeAuthenTo(string user)
        {
            string currentUser = Browser.GetText("id", "userMenu");
            if (!currentUser.ToLower().Contains(user))
            {
                Browser.Select("id", "userMenu");
                Browser.SearchAndSelect("id", "s2id_autogen18_search", user, PAGE_TIME_OUT);
                Browser.WaitUntilElementIsInvisibled("xpath", "//div[@class='blockUI blockOverlay']", PAGE_TIME_OUT);
            }
        }

        public void FillPlanTrip()
        {
            Browser.SearchAndSelect("id", "s2id_autogen3", "nguyen manh dong", PAGE_TIME_OUT);
            Browser.WaitUntilElementIsInvisibled("xpath", "//div[@class='blockUI blockOverlay']", PAGE_TIME_OUT);
        }
    }
}