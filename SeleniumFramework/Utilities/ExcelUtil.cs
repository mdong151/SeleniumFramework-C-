using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework
{
    class ExcelUtil
    {
        public DataTable ExcelToDataTable(string fileName)
        {
            var file = new FileInfo(fileName);
            //open file and return as Stream
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

            //Create openxmlreader via Excel Reader Factory
            IExcelDataReader excelReader;
            if (file.Extension.Equals(".xls"))
            {
                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            else if (file.Extension.Equals(".xlsx"))
            {
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }
            else
            {
                throw new Exception("Invalid FileName");
            }

            //Set the first Row as Comlumn Name 
            //reader.IsFirstRowAsColumnNames
            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            };
            //Return as DataSet
            DataSet result = excelReader.AsDataSet();
            //Get all the tables
            DataTableCollection table = result.Tables;
            //Store it in DataTable
            DataTable resultTable = table["Sheet1"];
            //return
            return resultTable;
        }


    }
}
