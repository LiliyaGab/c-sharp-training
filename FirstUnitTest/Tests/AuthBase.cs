using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTests
{
    public class AuthBase : TestBase
    {
        [SetUp]
        public void Setup()
        {
            AccountData user = new AccountData(Settings.Login, Settings.Password);
            app = ApplicationManager.GetInstance();
            app.Navigation.OpenHomePage();
            app.Auth.Login(user);
        }
    }
}
