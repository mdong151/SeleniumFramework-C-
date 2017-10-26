
using TechTalk.SpecFlow;
using TravelAgencyApp.PagesCollection;

namespace TravelAgencyApp.BDD.StepDefinitionFiles
{
    [Binding]
    public sealed class CreateTravelRequest
    {
        [Given(@"Traveller is Login")]
        public void GivenTravellerIsLogin()
        {
            Pages.HomePage.GoToPageWithCredentials();
        }

    }
}
