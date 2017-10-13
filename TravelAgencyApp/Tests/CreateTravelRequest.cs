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
            
        }
    }
}
