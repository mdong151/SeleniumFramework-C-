using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyApp.Configurations;
using TravelAgencyApp.Utilities;

namespace TravelAgencyApp.Tests
{
    [TestClass]
    public class Practice
    {
        [TestMethod]
        public void PracticeTest()
        {
            var value = ExcelReader.GetCellData(@"C:\Users\MNG06\Documents\Visual Studio Code\Amaris\TravelAgencyApp\Data\Data.xlsx", "Sheet1", 1, 0);
            Console.WriteLine(value);
        }
    }
}
