//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using SeleniumFramework;
using System;
using TravelAgencyApp.Pages;
using TravelAgencyApp.Tests;

namespace TravelAgencyApp.Test 
{
    
    public class TravellerCanCreateTravelRequest : TestBase
    {
       [Test]
       public void CreateTravelRequest()
        {
            TravelAgencyPages.CreatePage.GoTo();
            TravelAgencyPages.CreatePage.FakeAuthenTo("bach phuong chi");
            TravelAgencyPages.CreatePage.FillPlanTrip(); 
        }
    }
}
