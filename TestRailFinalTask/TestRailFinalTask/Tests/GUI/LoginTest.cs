using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailFinalTask.Pages;
using TestRailFinalTask.Utilities.Configuration;

namespace TestRailFinalTask.Tests.GUI
{
    public class LoginTest : BaseGUITest
    {
        [Test]
        public void SuccessLoginTest()
        {
            string email = "dashapr@mail.ru";
            string password = "!Qwertyu123";

            LoginPage loginPage = new LoginPage(Driver, true);

            var dashboardPage = loginPage.SuccessfulLogin(email, password);

            Assert.IsTrue(dashboardPage.CheckDashboardOpened());
        }

        [Test]
        public void IncorrectLoginTest()
        {
            string email = "dashapr@mail.ru";

            LoginPage loginPage = new LoginPage(Driver, true);
                      loginPage.IncorrectLogin(email);

            var expectedErrorMessage = "Password is required.";

            Assert.That(loginPage.CheckLoginErrorMessage, Is.EqualTo(expectedErrorMessage));
        }

        [Test]
        public void SuccessLoginTestForScreenshot()
        {
            string email = "dashapr@mail.ru";
            string password = "!Qwert  yu123";

            LoginPage loginPage = new LoginPage(Driver, true);

            var dashboardPage = loginPage.SuccessfulLogin(email, password);

            Assert.IsTrue(dashboardPage.CheckDashboardOpened());
        }
    }
}
