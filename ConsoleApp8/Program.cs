
using ConsoleApp8;
using ConsoleApp8.Excel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using excel = Microsoft.Office.Interop.Excel;

namespace Module1
{
    public class Module1_TestCases
    {
        public static IWebDriver driver = new FirefoxDriver();
        public static void Main()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.nammregister.org.uk/test.asp");
            IWebElement element = driver.FindElement(By.XPath("//input[@id='captchacode']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.promptResponse=prompt('Please enter the security code')");
            IAlert alert = ExpectedConditions.AlertIsPresent().Invoke(driver);
            //return (alert != null);
            if (alert != null)
            {
                // switch to alert
                IAlert alert1 = driver.SwitchTo().Alert();

                // sleep to allow user to input text
                Thread.Sleep(20000);
                alert1.Accept();
                var code = (String)js.ExecuteScript("return window.promptResponse");
                element.SendKeys(code);
            }    // this doesn't seem to work 
              //var code = js.ExecuteScript("return window.promptResponse");
              //  IWebElement element = driver.FindElement(By.XPath("//div[@class='FPdoLc tfB0Bf']/center[1]/input[@class='RNmpXc' and 2]"));
            var filename = @"C:\Users\LENOVO\Desktop\Snapshot\image1.jpeg";
            //ReadCaptchaImg read = new ReadCaptchaImg();
            //read.takescreenshot(@"C:\Users\LENOVO\Desktop\Snapshot\pic1.jpeg", @"C:\Users\LENOVO\Desktop\Snapshot\pic2.jpeg");
            Byte[] byteArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            Bitmap screenshot = new Bitmap(new System.IO.MemoryStream(byteArray));
            Rectangle croppedimage = new Rectangle(element.Location.X, element.Location.Y, element.Size.Width, element.Size.Height);
            screenshot = screenshot.Clone(croppedimage, screenshot.PixelFormat);
            screenshot.Save(string.Format(filename,ImageFormat.Jpeg));
        }
     //***************************************************************
        public static IEnumerable<TestCaseData> exdata;
     //***************************************************************

        public static IEnumerable<TestCaseData> Test_Login()
        {
            exdata = ReadAllFromExcel.ReadFromExcel("DataFile.xlsx", "Module1");
            return GetTest_TestData.GetTestData(exdata, "Login","Module1");
        }
        public static IEnumerable<TestCaseData> Test_Register()
        {
            return GetTest_TestData.GetTestData(exdata, "Register","Module1");
        }


        [TestCaseSource("Test_Login")]
        public void Login(string First_No,string Second_No,string Result)//, string Second_No,string Result)
        {
            Console.WriteLine("{0} {1} {2}",First_No,Second_No,Result);//,Second_No,Result);
        }

        [TestCaseSource("Test_Register")]
        public void Register(string First_No, string Second_No, string Result)//, string Second_No,string Result)
        {
            Console.WriteLine("{0} {1} {2}",First_No, Second_No, Result);//,Second_No,Result);
        }

        
    }
    class Module2TestCases
    {
        public static IEnumerable<TestCaseData> exdata;

        public static IEnumerable<TestCaseData> Test_CreateProject()
        {
            exdata = ReadAllFromExcel.ReadFromExcel("DataFile.xlsx", "Module2");
            return GetTest_TestData.GetTestData(exdata, "CreateProject", "Module2");
        }

        public static IEnumerable<TestCaseData> Test_GenerateProject()
        {
            return GetTest_TestData.GetTestData(exdata, "GenerateProject", "Module2");
        }

        [TestCaseSource("Test_CreateProject")]
        public void CreateProject(string First_No, string Second_No, string Result)//, string Second_No,string Result)
        {
            Console.WriteLine("{0} {1} {2}", First_No, Second_No, Result);//,Second_No,Result);
        }

        [TestCaseSource("Test_GenerateProject")]
        public void GenerateProject(string First_No, string Second_No, string Result)//, string Second_No,string Result)
        {
            Console.WriteLine("{0} {1} {2}", First_No, Second_No, Result);//,Second_No,Result);
        }
    }
}

    








