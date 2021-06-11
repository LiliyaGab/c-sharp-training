using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SeleniumTests
{
    [TestFixture]
    public class CreateGroupTest : AuthBase
    {
        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>)new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));
        }

        [Test, TestCaseSource("GroupDataFromXmlFile")]
        public void TheCreateGroupTest(GroupData group)
        {
            //GroupData group = new GroupData("new_group", "header", "footer");
            List<GroupData> oldgroups = app.Group.GetGroupList();
            app.Navigation.OpenGroupsPage();
            app.Group.CreateGroup(group);
            Assert.AreEqual(oldgroups.Count+1, app.Group.GetGroupList().Count) ;
            List<GroupData> newgroups = app.Group.GetGroupList();
            oldgroups.Add(new GroupData(group.Name) { Id = app.Group.GetLastAddedElementId().ToString() });
            app.Navigation.OpenGroupsPage();
            app.Group.SelectLastCreatedGroup();
            app.Group.OpenGroup();
            GroupData newgroup = app.Group.GetCreatedGroupData();
            Assert.AreEqual(group.Name, newgroup.Name);
            Assert.AreEqual(group.Header, newgroup.Header);
            Assert.AreEqual(group.Footer, newgroup.Footer);           
            oldgroups.Sort(); 
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);

        }

       
    }
}
