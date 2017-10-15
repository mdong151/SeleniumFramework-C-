using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgencyApp.Keywords;

namespace TravelAgencyApp.Tests
{
    [TestClass]
    public class Practice
    {
        [TestMethod]
        public void PracticeTest()
        {
            DataEngine engine = new DataEngine();
            engine.ExecuteScript(@"C:\Users\MNG06\Documents\Visual Studio Code\Amaris\TravelAgencyApp\Data\KeywordDrivenData.xlsx","TC01");
        }
    }
}
