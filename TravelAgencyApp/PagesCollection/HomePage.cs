
using TravelAgencyApp.ObjectsCollection;
using TravelAgencyApp.Ultils;

namespace TravelAgencyApp.PagesCollection
{
    public class HomePage : HomePageObjects
    {
        public void GoToPageWithCredentials()
        {
            Browser.GoToPageWithCredentials("");
        }
    }
}
