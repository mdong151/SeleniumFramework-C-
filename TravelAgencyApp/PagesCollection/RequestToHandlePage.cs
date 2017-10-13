using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyApp.ObjectsCollection;
using TravelAgencyApp.Ultilities;

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
