using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8.Excel
{
    public class GetTest_TestData
    {
        
        public static IEnumerable<TestCaseData> Exceldata;
        //private static string FILENAME = "DataFile.xlsx";
        public static IEnumerable<TestCaseData> GetTestData(IEnumerable<TestCaseData> data, string testname, string sheetname)
        {
            //IEnumerable IEnuColl = Exceldata;
            IEnumerable IEnuColl = data;//ReadAllFromExcel.ReadFromExcel(FILENAME, sheetname);
            var testCases1 = new List<TestCaseData>();
            foreach (TestCaseData coll in IEnuColl)
            {
                List<string> filterTestcases = new List<string>();
                if (coll.Arguments.GetValue(1).ToString() == testname)
                {
                    foreach (string str in coll.Arguments)
                    {
                        if (coll.Arguments[0].ToString() != str)
                        {
                            if (coll.Arguments[1].ToString() != str)
                            {
                                filterTestcases.Add(str);
                            }
                        }
                    }
                    //testCases1.Add(coll);
                    testCases1.Add(new TestCaseData(filterTestcases.ToArray()));
                }
            }
            if (testCases1 != null)
                foreach (TestCaseData testCaseData in testCases1)
                    yield return testCaseData;
        }
    }
}
