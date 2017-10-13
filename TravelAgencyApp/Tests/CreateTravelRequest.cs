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
            Pages.CreatePage.FakeAuthenTo("roxana");
            Pages.CreatePage.FillPlanTrip("plane", "tran hai linh", "train", "20/10/2017", "25/10/2017", "Ho Chi Minh", "new zealand");
            Pages.CreatePage.submitPlanATripForm();
            Assert.IsTrue(Pages.CreatePage.getPopupMessage().Contains("successfully"));
        }
    }
}
