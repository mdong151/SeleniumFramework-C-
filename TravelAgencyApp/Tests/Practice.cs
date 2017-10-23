using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgencyApp.Ultils;

namespace TravelAgencyApp.Tests
{
    [TestClass]
    public class Practice
    {
        [TestMethod]
        public void PracticeTest()
        {
            ILog logger = Log4Net.GetLogger(typeof(Practice));
            logger.Warn("warning message!");
            logger.Debug("Debug message!");
        }
    }
}
