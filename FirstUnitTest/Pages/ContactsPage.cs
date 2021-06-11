using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumTests
{
    public class ContactsPage
    {
        public By NewContactButton { get { return By.LinkText("add new"); } }
        public By FirstNameField { get { return By.Name("firstname"); } }
        public By LastNameField { get { return By.Name("lastname"); } }
        public By AddressField { get { return By.Name("address"); } }
        public By SubmitContactButton { get { return By.XPath("(//input[@name='submit'])[2]"); } }
        public By UpdateContactButton { get { return By.XPath("(//input[@name='update'])[2]"); } }
        public By DeleteContactButton { get { return By.XPath("//input[@value='Delete']"); } }
        public By ContactOrGroupCheckBox { get { return By.XPath("//input[@name='selected[]']"); } }
    }
}
