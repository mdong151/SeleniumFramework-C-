using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    [TestClass]
    public class TestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            Browser.Initialize();
            Browser.Maximize();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Browser.Close();
        }
    }
}
