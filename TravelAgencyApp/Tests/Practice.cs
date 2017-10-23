using log4net;
using log4net.Repository.Hierarchy;
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
            //ILog logger = Log4Net.GetLogger(typeof(Practice));
            //logger.Warn("warning message!");
            //logger.Debug("Debug message!");
            ILog logger = Log4Net.GetXmlLogger(typeof(Practice));
            logger.Debug("Debug message!");
        }
    }
}
