using NUnit.Framework;
using System.Collections.Generic;

namespace SeleniumTests
{
    [TestFixture]
    public class DeleteGroupTest : AuthBase
    {

        [Test]
        public void TheDeleteGroupTest()
        {
            app.Navigation.OpenGroupsPage();
            if (app.Group.IsElementsListEmpty())
                app.Group.CreateGroup(new GroupData("test", "test", "test"));
            List<GroupData> oldgroups = app.Group.GetGroupList();
            app.Navigation.OpenGroupsPage();
            app.Group.SelectLastCreatedGroup();
            int id = app.Group.GetLastAddedElementId();
            app.Group.DeleteGroup();
            app.Navigation.OpenGroupsPage();
            List<GroupData> newgroups = app.Group.GetGroupList();
            var deletedGroup = oldgroups.Find(x => x.Id == id.ToString());
            oldgroups.Remove(deletedGroup);
            Assert.IsFalse(app.Group.IsElementIdPresent(id));
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);
        }

       
    }
}
