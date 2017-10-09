using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumFramework
{
    
    public class CreatePage
    {
        
        public void GoTo()
        {
            Browser.GoTo("https://mnguyen3@amaris.com:Amaris2017@inte.amaris.com/TravelAgency/Create", false);
            Assert.IsTrue(Browser.WaitUntilElementIsInvisibled("xpath", "//div[@class='blockUI blockOverlay']", 30));
        }

        public void FakeAuthenTo(string user)
        {
            string currentUser = Browser.GetText("id", "userMenu");
            if (!currentUser.ToLower().Contains(user))
            {
                Browser.Select("id", "userMenu");
                Browser.SearchAndSelect("id", "s2id_autogen18_search", user, 30);
            }
        }

        public void FillPlanTrip()
        {
            Browser.SearchAndSelect("id", "s2id_autogen3", "nguyen manh dong", 30);
            Browser.WaitUntilElementIsInvisibled("xpath", "//div[@class='blockUI blockOverlay']", 30);
        }
    }
}