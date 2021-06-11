using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumTests
{
    public class GroupsPage
    {
        public By GroupsPageButton { get { return By.LinkText("groups"); } }
        public By GroupNameField { get { return By.Name("group_name"); } }
        public By GroupHeaderField { get { return By.Name("group_header"); } }
        public By GroupFooterField { get { return By.Name("group_footer"); } }
        public By UpdateGroupButton { get { return By.Name("update"); } }
        public By DeleteGroupButton { get { return By.Name("delete"); } }
        public By SubmitGroupButton { get { return By.Name("submit"); } }
        public By NewGroupButton { get { return By.XPath("(//input[@name='new'])[2]"); } }
        public By EditGroupButton { get { return By.Name("edit"); } }

    }
}
