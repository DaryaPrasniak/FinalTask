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

        [Test]
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
