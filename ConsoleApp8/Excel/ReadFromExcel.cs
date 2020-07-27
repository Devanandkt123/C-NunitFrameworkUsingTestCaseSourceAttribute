using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8.Excel
{
    public class ReadAllFromExcel
    {
        public static IEnumerable<TestCaseData> ReadFromExcel(string excelFileName, string excelsheetTabName)
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string xslLocation = Path.Combine(executableLocation, "Excel" + "\\" + excelFileName);

            string cmdText = "SELECT * FROM [" + excelsheetTabName + "$]";

            if (!File.Exists(xslLocation))
                throw new Exception(string.Format("File name: {0}", xslLocation), new FileNotFoundException());

            string connectionStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";", xslLocation);
            var testCases = new List<TestCaseData>();
            using (var connection = new OleDbConnection(connectionStr))
            {
                connection.Open();
                var command = new OleDbCommand(cmdText, connection);
                var reader = command.ExecuteReader();
                if (reader == null)
                    throw new Exception(string.Format("No data return from file, file name:{0}", xslLocation));
                while (reader.Read())
                {
                    var row = new List<string>();
                    var feildCnt = reader.FieldCount;
                    var flag_validdata = 0;
                    for (var i = 0; i < feildCnt; i++)
                    {
                        if (reader.GetValue(reader.GetOrdinal("Execute")).ToString() == "Yes")
                        {
                            if (reader.GetValue(i).ToString() != "")
                            {
                                flag_validdata = 1;
                                row.Add(reader.GetValue(i).ToString());
                            }
                        }
                    }
                    if (flag_validdata == 1)
                        testCases.Add(new TestCaseData(row.ToArray()));
                }
            }

            //if (testCases != null)
            //    foreach (TestCaseData testCaseData in testCases)
            //        yield return testCaseData;
            return testCases;
        }
    }
}
