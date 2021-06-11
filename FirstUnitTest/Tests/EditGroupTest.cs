using NUnit.Framework;
using System.Collections.Generic;

namespace SeleniumTests
{
    [TestFixture]
    public class EditGroupTest : AuthBase
    {
        [Test]
        public void TheChangeGroupTest()
        {
            app.Navigation.OpenGroupsPage();
            if (app.Group.IsElementsListEmpty())
                app.Group.CreateGroup(new GroupData("test", "test", "test"));
            app.Navigation.OpenGroupsPage();
            List<GroupData> oldgroups = app.Group.GetGroupList();
            app.Group.SelectLastCreatedGroup();
            app.Group.OpenGroup();
            GroupData editedgroup = new GroupData("edited", "edited", "edited");
            app.Group.EditGroup(editedgroup);
            app.Navigation.OpenGroupsPage();
            List<GroupData> newgroups = app.Group.GetGroupList();
            oldgroups.Find(x => x.Id == app.Group.GetLastAddedElementId().ToString()).Name = editedgroup.Name;
            app.Group.SelectLastCreatedGroup();
            app.Group.OpenGroup();
            var group = app.Group.GetCreatedGroupData();
            Assert.AreEqual(editedgroup.Name, group.Name);
            Assert.AreEqual(editedgroup.Header, group.Header);
            Assert.AreEqual(editedgroup.Footer, group.Footer);
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);
        }

    }
}

