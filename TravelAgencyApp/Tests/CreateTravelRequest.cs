using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgencyApp.PagesCollection;

namespace TravelAgencyApp.Tests
{
    [TestClass]
    public class CreateTravelRequest : TestBase
    {
       [TestMethod]
       public void TravelAgentCanCreateTravelRequest()
        {
            Pages.CreatePage.GoTo();
            Pages.CreatePage.FakeAuthenTo("Bach Phuong Chi");
            Pages.CreatePage.FillPlanTrip("plane", "nguyen manh dong", "plane", "20/10/2017", "25/10/2017", "Hong Kong", "Singapore");
            Pages.CreatePage.submitPlanATripForm();
            Assert.IsTrue(Pages.CreatePage.getPopupMessage().Contains("successfully"));
        }
    }
}
