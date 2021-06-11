using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SeleniumTests
{
    [TestFixture]
    public class CreateContactTest : AuthBase
    {
        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void TheCreateContactTest(ContactData contact)
        {
            //var contact = new ContactData("name", "surname", "company");
            List<ContactData> oldcontacts = app.Contact.GetContactList();
            app.Contact.CreateContact(contact);
            app.Navigation.OpenHomePage();
            Assert.AreEqual(oldcontacts.Count + 1, app.Contact.GetContactCount());
            List<ContactData> newcontacts = app.Contact.GetContactList();
            oldcontacts.Add(new ContactData(contact.Name, contact.Surname, contact.Address) { Id = app.Contact.GetLastAddedElementId().ToString() });
            app.Contact.OpenLastCreatedContact();
            ContactData newcontact = app.Contact.GetCreatedContactData();
            Assert.AreEqual(contact.Name, newcontact.Name);
            Assert.AreEqual(contact.Surname, newcontact.Surname);
            oldcontacts.Sort();
            newcontacts.Sort();
            Assert.AreEqual(oldcontacts, newcontacts);
        }

       
    }
}
