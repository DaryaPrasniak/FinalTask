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
        public void PopUpWindow()
        {
            string email = "dashapr@mail.ru";
            string password = "!Qwertyu123";

            var dashboardPagePopUp = new LoginPage(Driver, true)
                .SuccessfulLogin(email, password)
                .CheckPopUpWindowAppeared();
               
            var expectedMessage = "Upgrade your account to start streamlining your testing!";

            Assert.That(dashboardPagePopUp, Is.EqualTo(expectedMessage));
        }
    }
}
