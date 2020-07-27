using Module1;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class ForumEntryForm
    {
        public ForumEntryForm()
        {
            PageFactory.InitElements(Browser.driver, this);
        }
        [FindsBy(How = How.XPath,Using = "//button[@id='newUser']") ]
        public static IWebElement Btn_NewUser{ get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='UserName']")]
        public static IWebElement Txt_UserName{ get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Password']")]
        public static IWebElement Txt_Password{ get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='login']")]
        public static IWebElement Btn_Login{ get; set; }

        //Enter UserName and Password and Click Login button
        public void Login(string UN,string PWD)
        {
            Txt_UserName.SendKeys(UN);
            Txt_Password.SendKeys(PWD);
            Btn_Login.Click();
        }
        //Click on NewUser btn
        public void NewUser_Click()
        {
            Btn_NewUser.Click();
        }
    }
}
