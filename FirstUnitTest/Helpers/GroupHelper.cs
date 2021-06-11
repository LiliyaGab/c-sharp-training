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
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }
        public void CreateGroup(GroupData group)
        {
            Click(GroupsPage.NewGroupButton);
            FillTheField(GroupsPage.GroupNameField, group.Name);
            if (group.Header != null)
                FillTheField(GroupsPage.GroupHeaderField, group.Header);
            if (group.Footer != null)
                FillTheField(GroupsPage.GroupFooterField, group.Footer);
            Click(GroupsPage.SubmitGroupButton);
        }
        public void EditGroup(GroupData editedgroup)
        {
            FillTheField(GroupsPage.GroupNameField, editedgroup.Name);
            FillTheField(GroupsPage.GroupHeaderField, editedgroup.Header);
            FillTheField(GroupsPage.GroupFooterField, editedgroup.Footer);
            Click(GroupsPage.UpdateGroupButton);
        }

        public void DeleteGroup()
        {
            Click(GroupsPage.DeleteGroupButton);
        }

        public void SelectLastCreatedGroup() => Click(By.XPath("(//input[@value='" + GetLastAddedElementId() + "'])"));
        public void OpenGroup() => Click(GroupsPage.EditGroupButton);
        public GroupData GetCreatedGroupData()
        {
            string groupName = driver.FindElement(GroupsPage.GroupNameField).GetAttribute("value");
            string header = driver.FindElement(GroupsPage.GroupHeaderField).Text;
            string footer = driver.FindElement(GroupsPage.GroupFooterField).Text;
            return new GroupData(groupName) { Header = header, Footer = footer };
        }
        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigation.OpenGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (var element in elements)
            {
                groups.Add(new GroupData(element.Text)
                {
                    Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                });
            }
            return groups;
        }
        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}
