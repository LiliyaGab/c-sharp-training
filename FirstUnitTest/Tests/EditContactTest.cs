using NUnit.Framework;
using System.Collections.Generic;

namespace SeleniumTests
{
    [TestFixture]
    public class EditContactTest : AuthBase
    {
       
        [Test]
        public void TheEditContactTest()
        {
            if (app.Contact.IsElementsListEmpty())
                app.Contact.CreateContact(new ContactData("test", "test", "test"));
            app.Navigation.OpenHomePage();
            List<ContactData> oldcontacts = app.Contact.GetContactList();
            app.Contact.OpenLastCreatedContact();
            var editedcontact = new ContactData("edited", "edited", "edited");
            app.Contact.EditContact(editedcontact);
            app.Navigation.OpenHomePage();
            List<ContactData> newcontacts = app.Contact.GetContactList();
            var findcontact = oldcontacts.Find(x => x.Id == app.Contact.GetLastAddedElementId().ToString());
            findcontact.Name = editedcontact.Name;
            findcontact.Surname = editedcontact.Surname;
            findcontact.Address = editedcontact.Address;
            app.Contact.OpenLastCreatedContact();
            var contact = app.Contact.GetCreatedContactData();
            Assert.AreEqual(editedcontact.Name, contact.Name);
            Assert.AreEqual(editedcontact.Surname, editedcontact.Surname);
            oldcontacts.Sort();
            newcontacts.Sort();
            Assert.AreEqual(oldcontacts, newcontacts);
        }

        
    }
}

