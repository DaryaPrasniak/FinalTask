using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailFinalTask.Tests.GUI;
using TestRailFinalTask.Core;

namespace TestRailFinalTask.Pages
{
    public class DashboardPage : BasePage
    {

        private static string END_POINT = "index.php?/dashboard";

        private static readonly By NavigationDashboard = By.Id("navigation-dashboard");
        private static readonly By AddProjectButton = By.Id("sidebar-projects-add");
        private static readonly By ProjectNameInput = By.XPath("//input[@name='name']");
        private static readonly By AcceptProjectButton = By.Id("accept");
        private static readonly By AddedProjectMessageSuccess = By.ClassName("message");
        private static readonly By AddedProjectMessageError = By.XPath("//*[contains(text(),'Field')]");

        public DashboardPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public DashboardPage(IWebDriver? driver) : base(driver, false)
        {
        }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(NavigationDashboard) != null;
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public IWebElement SidebarProjectsAddButton => Driver.FindElement(NavigationDashboard);

        public bool CheckDashboardOpened()
        {
            return Driver.FindElement(NavigationDashboard).Displayed;
        }

        public void ClickAddProjectButton()
        {
            Driver.FindElement(AddProjectButton).Click();
        }

        public void ProjectInput(string projectName)
        {
            Driver.FindElement(ProjectNameInput).SendKeys(projectName);
        }

        public void ClickAcceptProjectButton()
        {
            Driver.FindElement(AcceptProjectButton).Click();
        }

        public void AddProject(string projectName)
        {
            ClickAddProjectButton();
            ProjectInput(projectName);
            ClickAcceptProjectButton();
        }

        public DashboardPage NewelyAddedProject(string projectName)
        {
            AddProject(projectName);
            return this;
        }

        //public DashboardPage UnsuccessfullyAddedProject(string projectName)
        //{
        //    AddProject(projectName);
        //    return this;
        //    //return new DashboardPage(Driver);
        //}

        public string CheckAddedProjectMessage()
        {
           return  Driver.FindElement(AddedProjectMessageSuccess).Text;
        }

        public string CheckAddedProjectMessageError()
        {
            return Driver.FindElement(AddedProjectMessageError).Text;
        }
    }
}
