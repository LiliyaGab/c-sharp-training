using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace SeleniumTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void OpenHomePage() => driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        public void OpenGroupsPage()
        {
            //driver.FindElement(By.Id("content")).Click();
            Click(GroupsPage.GroupsPageButton);
        }
    }
}
