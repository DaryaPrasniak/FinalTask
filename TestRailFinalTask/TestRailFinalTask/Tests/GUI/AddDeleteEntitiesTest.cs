using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailFinalTask.Pages;

namespace TestRailFinalTask.Tests.GUI
{
    public class AddDeleteEntitiesTest : BaseGUITest
    {
        [Test]
        public void AddAProject()
        {
            string projectName = "New test";
            string email = "dashapr@mail.ru";
            string password = "!Qwertyu123";

            var dashboardPage = new LoginPage(Driver, true)
                .SuccessfulLogin(email, password)
                .NewelyAddedProject(projectName);

            var expectedMessage = "Successfully added the new project.";

            Assert.That(dashboardPage.CheckAddedProjectMessage, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void DeleteProject()
        {
            string projectName = "New test for delete";
            string email = "dashapr@mail.ru";
            string password = "!Qwertyu123";

            var dashboardPage = new LoginPage(Driver, true)
                .SuccessfulLogin(email, password)
                .NewelyAddedProject(projectName)
                .DeleteProject();

            var expectedMessage = "Successfully deleted the project.";

            Assert.That(dashboardPage.CheckAddedProjectMessage, Is.EqualTo(expectedMessage));
        }
    }
}
