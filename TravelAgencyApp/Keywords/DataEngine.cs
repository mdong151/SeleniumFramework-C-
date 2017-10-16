
using TravelAgencyApp.CustomExceptions;
using TravelAgencyApp.Ultils;

namespace TravelAgencyApp.Keywords
{
    public class DataEngine
    {
        private readonly int _keywordColumn;
        private readonly int _locatorTypeColumn;
        private readonly int _locatorValueColumn;
        private readonly int _parameterColumn;

        public DataEngine(int keywordColumn = 2, int locatorTypeColumn = 3, int locatorValueColumn = 4,int parameterColumn = 5)
        {
            _keywordColumn = keywordColumn;
            _locatorTypeColumn = locatorTypeColumn;
            _locatorValueColumn = locatorValueColumn;
            _parameterColumn = parameterColumn;
        }
        public void PerformAction(string keyword, string locatorType, string locatorValue,params string[] argStrings)
        {
            switch (keyword)
            {
                case "Select":
                    Browser.Select(Browser.GetElementBy(locatorType,locatorValue));
                    break;
                case "EnterText":
                    Browser.EnterText(Browser.GetElementBy(locatorType,locatorValue),argStrings[0]);
                    break;
                case "ClearAndEnterText":
                    Browser.ClearAndEnterText(Browser.GetElementBy(locatorType, locatorValue),argStrings[0]);
                    break;
                case "SearchAndSelect":
                    Browser.SearchAndSelect(Browser.GetElementBy(locatorType, locatorValue),argStrings[0]);
                    break;
                case "WaitUntilElementIsDisplayedWithTime":
                    Browser.WaitUntilElementIsDisplayed(Browser.GetElementBy(locatorType, locatorValue), int.Parse(argStrings[0]));
                    break;
                case "WaitUntilElementIsDisplayed":
                    Browser.WaitUntilElementIsDisplayed(Browser.GetElementBy(locatorType, locatorValue));
                    break;
                case "GoToPage":
                    Browser.GoToPage(argStrings[0],false);
                    break;
                case "WaitUntilElementIsInvisibled":
                    Browser.WaitUntilElementIsInvisibled(Browser.GetElementBy(locatorType, locatorValue));
                    break;
                case "WaitUntilElementIsInvisibledWithTime":
                    Browser.WaitUntilElementIsInvisibled(Browser.GetElementBy(locatorType, locatorValue),int.Parse(argStrings[0]));
                    break;
                case "":
                    break;
                default:
                    throw new NoKeywordFoundException("Keyword Not Found: "+ keyword);
            }
        }
        public void ExecuteScript(string excelPath,string sheetName)
        {
            int totalRows = ExcelReader.GetTotalRows(excelPath, sheetName);
            for (int i = 1; i < totalRows; i++)
            {
                var locatorType = ExcelReader.GetCellData(excelPath, sheetName, i, _locatorTypeColumn).ToString();
                var locatorValue = ExcelReader.GetCellData(excelPath, sheetName, i, _locatorValueColumn).ToString();
                var keyword = ExcelReader.GetCellData(excelPath, sheetName, i, _keywordColumn).ToString();
                var parameter = ExcelReader.GetCellData(excelPath, sheetName, i, _parameterColumn).ToString();
                PerformAction(keyword,locatorType,locatorValue,parameter);
            }
        }
    }
}
