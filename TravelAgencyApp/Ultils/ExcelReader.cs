using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace TravelAgencyApp.Ultils
{
    public class ExcelReader
    {
        private static IDictionary<string, IExcelDataReader> _cache;
        private static FileStream _stream;
        private static IExcelDataReader _reader;

        static ExcelReader()
        {
            _cache = new Dictionary<string, IExcelDataReader>();
        }

        public static object GetCellData(string excelPath, string sheetName, int row, int column)
        {
            if (_cache.ContainsKey(sheetName))
            {
                _reader = _cache[sheetName];
            }
            else
            {
                _stream = new FileStream(excelPath, FileMode.Open, FileAccess.Read);
                _reader = ExcelReaderFactory.CreateOpenXmlReader(_stream);
                _cache.Add(sheetName, _reader);
            }
            DataTable table = _reader.AsDataSet().Tables[sheetName];
            return GetData(table.Rows[row][column].GetType(),table.Rows[row][column]);
        }

        private static object GetData(Type type,object data)
        {
            switch (type.Name)
            {
                case "String":
                    return data.ToString();
                case "Double":
                    return Convert.ToDouble (data);
                case "DateTime":
                    return Convert.ToDateTime(data);
                default:
                    return data.ToString();
            }
        }
    }
}
