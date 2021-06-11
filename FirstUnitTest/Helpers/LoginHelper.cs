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
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        { }
        public void Login(AccountData user)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(user.Username))
                    return;
                Logout();
            }
            FillTheField(LoginPage.UserTextField, user.Username);
            FillTheField(LoginPage.PasswordTextField, user.Password);
            Click(LoginPage.SubmitLoginButton);
        }
        public void Logout()
        {
            if (IsLoggedIn())
                driver.FindElement(LoginPage.LogoutLink).Click();
        }
        public bool IsLoggedIn()
        {
            //WaitUntilVisible(LoginPage.LogoutLink);
            if (IsElementPresent(LoginPage.LogoutLink))
                return true;
            else return false;
        }
        public bool IsLoggedIn(string username)
        {
            if (IsLoggedIn())
            {
                if (IsElementPresent(By.XPath("//b[text()='(" + username + ")']")))
                    return true;
            }
            return false;
        }
    }
}
