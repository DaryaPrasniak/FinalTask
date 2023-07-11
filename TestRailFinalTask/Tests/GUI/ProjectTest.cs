using Allure.Commons;
using NUnit.Allure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailFinalTask.Pages;

namespace TestRailFinalTask.Tests.GUI
{
    public class ProjectTest : BaseGUITest
    {
        [TestCase("positive test case 100500")]
        [TestCase("A")]
        [Test(Description = "AddAProject")]
        [Description("Verify user can add a project name (20 characters)")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("GUI")]
        [AllureIssue(name: "TMS-12")]
        [AllureTms(name: "TMS-13")]
        [AllureTag("Smoke")]
        [AllureLink("https://daryaprasniak1.testrail.io/")]
        public void AddAProject(string projectName)
        {
            string email = "dashapr@mail.ru";
            string password = "!Qwertyu123";

            var dashboardPage = new LoginPage(Driver, true)
                .SuccessfulLogin(email, password)
                .NewelyAddedProject(projectName);

            var expectedMessage = "Successfully added the new project.";

            Assert.That(dashboardPage.CheckAddedProjectMessage, Is.EqualTo(expectedMessage));
        }

        [TestCase("")]
        [Test(Description = "AddNullProject")]
        [Description("Verify user cannot add a project with blank name field")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("GUI")]
        [AllureIssue(name: "TMS-12")]
        [AllureTms(name: "TMS-13")]
        [AllureTag("Smoke")]
        [AllureLink("https://daryaprasniak1.testrail.io/")]
        public void AddNullProject(string projectName)
        {
            string email = "dashapr@mail.ru";
            string password = "!Qwertyu123";

            var dashboardPage = new LoginPage(Driver, true)
                .SuccessfulLogin(email, password)
                .NewelyAddedProject(projectName);

            var expectedMessage = "Field Name is a required field.";

            Assert.That(dashboardPage.CheckAddedProjectMessageError, Is.EqualTo(expectedMessage));
        }

        [Test(Description = "SearchFieldCharactersLimit")]
        [Description("Verify user cannot input more than 250 characters to search field")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("GUI")]
        [AllureIssue(name: "TMS-12")]
        [AllureTms(name: "TMS-13")]
        [AllureTag("Regression")]
        [AllureLink("https://daryaprasniak1.testrail.io/")]
        public void SearchField()
        {
            string email = "dashapr@mail.ru";
            string password = "!Qwertyu123";
            string inputText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Lorem ipsum dolor sit amet";

            var dashboardPage = new LoginPage(Driver, true)
                .SuccessfulLogin(email, password)
                .SearchFieldInput(inputText);

            var expectedMessage = "Field Query is too long (250 characters at most).";

            Assert.That(dashboardPage.CheckSearchErrorDisplayed, Is.EqualTo(expectedMessage));
        }
    }
}
