using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailFinalTask.Tests.GUI;
using TestRailFinalTask.Core;
using OpenQA.Selenium.Interactions;

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
        private static readonly By DeleteProjectButton = By.ClassName("icon-small-delete");
        private static readonly By DeleteConfirmationCheckbox = By.XPath("//span[@class='dialog-confirm-busy']//following::input");
        private static readonly By ConfirmDeleteProjectButton = By.LinkText("OK");
        private static readonly By RefineButton = By.Id("chart-refine");
        private static readonly By DialogWindow = By.ClassName("ui-dialog");
        private static readonly By CalendarOnDialogWindow = By.ClassName("charts-refine-calendar");
        private static readonly By ProjectLink = By.CssSelector(".grid td:nth-child(3) a");
        private static readonly By AddMilestoneButton = By.LinkText("Add");
        private static readonly By UploadFileButton = By.Id("entityAttachmentListEmptyIcon");
        private static readonly By FileForUploading = By.XPath("//input[@type='file']");
        private static readonly By AttachedFile = By.CssSelector(".attachments-library .attachment-name");      
        private static readonly By SearchInput = By.Id("search_query");
        private static readonly By SearchErrorMessage = By.XPath("//*[@id='messageDialog']/div[2]/p");
        private static readonly By UpdateButton = By.Id("pendo-image-badge-035eb248");
        private static readonly By UpdateButtonPopUp = By.XPath("//*[contains(text(),'streamlining')]");
        private static readonly By CloseIcon = By.ClassName("ui-dialog-titlebar-close");
        private static readonly By NewUploadFileButton = By.Id("entityAttachmentListAdd");

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

        public string CheckAddedProjectMessage()
        {
           return  Driver.FindElement(AddedProjectMessageSuccess).Text;
        }

        public string CheckAddedProjectMessageError()
        {
            return Driver.FindElement(AddedProjectMessageError).Text;
        }

        public void ClickDeleteProjectButton()
        {
            Driver.FindElement(DeleteProjectButton).Click();
        }

        public void ActivateCheckbox()
        {
            Driver.FindElement(DeleteConfirmationCheckbox).Click();
        }

        public void ConfirmDeleteProject()
        {
            Driver.FindElement(ConfirmDeleteProjectButton).Click();
        }

        public DashboardPage DeleteProject()
        {  
            ClickDeleteProjectButton();
            ActivateCheckbox();
            ConfirmDeleteProject();

            return this;
        }

        public DashboardPage ClickRefineButton()
        {
            Driver.FindElement(RefineButton).Click();

            return this;
        }

        public bool CheckDialogWindowDisplayed()
        { 
            return Driver.FindElement(DialogWindow).Displayed;
        }

        public bool CheckCalenderOnDialogWindowDisplayed()
        {
            return Driver.FindElement(CalendarOnDialogWindow).Displayed;
        }
        public void OpenProject() 
        {
            Driver.FindElement(ProjectLink).Click();
        }

        public void AddMilestone()
        {
            Driver.FindElement(AddMilestoneButton).Click();
        }

        public void ClickUploadFileButton()
        {
            Driver.FindElement(UploadFileButton).Click();
        }

        public void ClickNewUploadFileButton()
        {
            Driver.FindElement(NewUploadFileButton).Click();
        }

        public void ClickCloseIcon()
        {
            Driver.FindElement(CloseIcon).Click();
        }

        public void AddFileForUploading(string filePath)
        {
            Driver.FindElement(FileForUploading).SendKeys(filePath);           
        }

        public void WaitUntilUploaded()
        {
            WaitService.GetVisibleElement(AttachedFile);
        }

        public void WaitUntilPopUpDisplayed()
        {
            WaitService.GetVisibleElement(SearchErrorMessage);
        }

        public void WaitUntilAttachedFileDisplayed()
        {
            WaitService.GetVisibleElement(AttachedFile);
        }

        public DashboardPage UploadFile(string filePath)
        {
            OpenProject();
            AddMilestone();
            ClickUploadFileButton();
            AddFileForUploading(filePath);
            WaitUntilAttachedFileDisplayed();
            ClickCloseIcon();
            ClickNewUploadFileButton();
            WaitUntilUploaded();

            return this;
        }

        public string CheckAttachedFileUploaded()
        {
            return Driver.FindElement(AttachedFile).Text;
        }
            
        public DashboardPage SearchFieldInput(string inputText)
        {
            Driver.FindElement(SearchInput).SendKeys(inputText);
            WaitUntilPopUpDisplayed();

            return this;
        }

        public string CheckSearchErrorDisplayed()
        {
            return Driver.FindElement(SearchErrorMessage).Text;
        }

        public IWebElement GetUpdateButton()
        {
            return WaitService.GetVisibleElement(UpdateButton);
        }

        public string CheckPopUpWindowAppeared()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(GetUpdateButton()).Build().Perform();          

            return Driver.FindElement(UpdateButtonPopUp).Text;
        }
    }
}
