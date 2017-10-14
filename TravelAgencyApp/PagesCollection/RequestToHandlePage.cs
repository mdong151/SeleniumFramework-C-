using TravelAgencyApp.ObjectsCollection;
using TravelAgencyApp.Ultils;

namespace TravelAgencyApp.PagesCollection
{
    public class RequestToHandlePage : RequestToHandlePageObjects
    {
        public void GoTo()
        {
            Browser.GoToPage("https://inte.amaris.com/TravelAgency/RequestToHandle");
        }

        public bool IsAt()
        {
            return Browser.IsAt("Request To Handle - TravelAgency");
        }
    }
}
