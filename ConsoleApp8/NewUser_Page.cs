using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class NewUser_Page
    {
        public NewUser_Page()
        {
            PageFactory.InitElements(Browser.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'First Name']")]
        public static IWebElement Txt_FirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'Last Name']")]
        public static IWebElement Txt_LastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'UserName']")]
        public static IWebElement Txt_UserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'Password']")]
        public static IWebElement Txt_Password { get; set; }

    }
}
