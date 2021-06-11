using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }
        public void CreateContact(ContactData contact)
        {
            Click(ContactsPage.NewContactButton);
            FillTheField(ContactsPage.FirstNameField, contact.Name);
            FillTheField(ContactsPage.LastNameField, contact.Surname);
            FillTheField(ContactsPage.AddressField, contact.Address);
            Click(ContactsPage.SubmitContactButton);
        }

        public void EditContact(ContactData editedcontact)
        {
            FillTheField(ContactsPage.FirstNameField, editedcontact.Name);
            FillTheField(ContactsPage.LastNameField, editedcontact.Surname);
            FillTheField(ContactsPage.AddressField, editedcontact.Address);
            Click(ContactsPage.UpdateContactButton);
        }

        public void DeleteContact()
        {
            acceptNextAlert = true;
            Click(ContactsPage.DeleteContactButton);
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
        }
        public void OpenLastCreatedContact() => Click(By.XPath("//a[@href='edit.php?id=" + GetLastAddedElementId() + "']"));
        public void SelectLastCreatedContact() => Click(By.Id(GetLastAddedElementId().ToString()));
        public ContactData GetCreatedContactData()
        {
            string name = driver.FindElement(ContactsPage.FirstNameField).GetAttribute("value");
            string surname = driver.FindElement(ContactsPage.LastNameField).GetAttribute("value");
            string address = driver.FindElement(ContactsPage.AddressField).GetAttribute("value");
            return new ContactData(name, surname);
        }
        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigation.OpenHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
            foreach (var element in elements)
            {
                var entries = element.FindElements(By.TagName("td"));
                contacts.Add(new ContactData(entries[2].Text, entries[1].Text, entries[3].Text)
                {
                    Id = entries[0].FindElement(By.TagName("input")).GetAttribute("value")
                });
            }
            return contacts;
        }
        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }
    }
}
