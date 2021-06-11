using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace SeleniumTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected bool acceptNextAlert = true;
        protected WebDriverWait wait;
        protected LoginPage loginPage;
        protected GroupsPage groupsPage;
        protected ContactsPage contactsPage;
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }
        protected LoginPage LoginPage
        {
            get
            {
                if (loginPage == null)
                {
                    loginPage = new LoginPage();
                }
                return loginPage;
            }
        }
        protected GroupsPage GroupsPage
        {
            get
            {
                if (groupsPage == null)
                    groupsPage = new GroupsPage();
                return groupsPage;
            }
        }
        protected ContactsPage ContactsPage
        {
            get
            {
                if (contactsPage == null)
                {
                    contactsPage = new ContactsPage();
                }
                return contactsPage;
            }
        }
        public void WaitUntilVisible(By locator)
        {
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Message = "Element with locator '" + locator + "' was not visible in 10 seconds";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }
        public void WaitUntilClickable(By locator)
        {
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Message = "Element with locator '" + locator + "'was not visible in 10 seconds";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
        public static Func<IWebDriver, IWebElement> Condition(By locator)
        {
            return (driver) =>
            {
                var element = driver.FindElements(locator).FirstOrDefault();
                return element != null && element.Displayed && element.Enabled ? element : null;
            };
        }
        public void Click(By locator)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(Condition(locator)).Click();
        }
        public void FillTheField(By locator, string text)
        {
            driver.FindElement(locator).Click();
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
        }
        public bool IsElementIdPresent(int id)
        {
            return IsElementPresent(By.XPath("(//input[@value='" + id + "'])"));
        }
        public bool IsElementsListEmpty() => !IsElementPresent(ContactsPage.ContactOrGroupCheckBox);


        public int GetLastAddedElementId()
        {
            var elements = driver.FindElements(ContactsPage.ContactOrGroupCheckBox);
            int max = 0;
            foreach (var element in elements)
            {
                int currentId = Convert.ToInt32(element.GetAttribute("value"));
                if (currentId > max)
                    max = currentId;
            }

            return max;
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
