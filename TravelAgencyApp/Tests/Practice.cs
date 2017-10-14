using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
