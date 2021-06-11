using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace SeleniumTests
{
    [TestFixture]
    public class DeleteContactTest : AuthBase
    {

        [Test]
        public void TheDeleteContactTest()
        {
            if (app.Contact.IsElementsListEmpty())
                app.Contact.CreateContact(new ContactData("test", "test"));
            List<ContactData> oldcontacts = app.Contact.GetContactList();
            app.Navigation.OpenHomePage();
            app.Contact.SelectLastCreatedContact();
            int id = app.Contact.GetLastAddedElementId();
            app.Contact.DeleteContact();
            app.Navigation.OpenHomePage();
            List<ContactData> newcontacts = app.Contact.GetContactList();
            var deletecontact = oldcontacts.Find(x => x.Id == id.ToString());
            oldcontacts.Remove(deletecontact);            
            Assert.IsFalse(app.Contact.IsElementIdPresent(id));
            oldcontacts.Sort();
            newcontacts.Sort();
            Assert.AreEqual(oldcontacts, newcontacts);
        }

        
    }
}
