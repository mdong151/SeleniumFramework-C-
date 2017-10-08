using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumFramework;

namespace TravelAgencyApp 
{
    [TestClass]
    public class TravellerCanCreateTravelRequest : TestBase
    {
       [TestMethod]
       public void CreateTravelRequest()
        {
            //Pages.CreatePage.GoTo();
            //Pages.CreatePage.FakeAuthenTo("bach phuong chi");
            //Pages.CreatePage.FillPlanTrip();
            TravelAgencyPages.CreatePage.GoTo();
            TravelAgencyPages.CreatePage.FakeAuthenTo("bach phuong chi");
            TravelAgencyPages.CreatePage.FillPlanTrip();
            
            
        }
    }
}
