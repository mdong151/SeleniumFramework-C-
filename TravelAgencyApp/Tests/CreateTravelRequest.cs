
using NUnit.Framework;
using SeleniumFramework;
using System;

namespace TravelAgencyApp 
{    
    public class CreateTravelRequest : TestBase
    {
       [Test]
       public void TravelAgentCanCreateTravelRequest()
        {
            TravelAgencyPages.CreatePage.GoTo();
            TravelAgencyPages.CreatePage.FakeAuthenTo("bach phuong chi");
            TravelAgencyPages.CreatePage.FillPlanTrip(); 
        }
    }
}
