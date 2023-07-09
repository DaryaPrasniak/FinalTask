using Allure.Commons;
using NUnit.Allure.Attributes;
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
        [Test(Description = "SuccessfulLogin")]
        [Description("Verify user can login with valid credentials")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("GUI")]
        [AllureIssue("TMS-12")]
        [AllureTms("TMS-13")]
        [AllureTag("Smoke")]
        [AllureLink("https://daryaprasniak1.testrail.io/")]       
        public void SuccessLoginTest()
        {
            string email = "dashapr@mail.ru";
            string password = "!Qwertyu123";

            LoginPage loginPage = new LoginPage(Driver, true);

            var dashboardPage = loginPage.SuccessfulLogin(email, password);

            Assert.IsTrue(dashboardPage.CheckDashboardOpened());
        }

        [Test(Description = "IncorrectLogin")]
        [Description("Verify user cannot login with invalid credentials(blank password field)")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("GUI")]
        [AllureIssue("TMS-12")]
        [AllureTms("TMS-13")]
        [AllureTag("Smoke")]
        [AllureLink("https://daryaprasniak1.testrail.io/")]
        public void IncorrectLoginTest()
        {
            string email = "dashapr@mail.ru";

            LoginPage loginPage = new LoginPage(Driver, true);
                      loginPage.IncorrectLogin(email);

            var expectedErrorMessage = "Password is required.";

            Assert.That(loginPage.CheckLoginErrorMessage, Is.EqualTo(expectedErrorMessage));
        }

        [Test(Description = "SuccessLoginTestForScreenshot")]
        [Description("Verify user can login with valid credentials")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("FailedSuite")]
        [AllureSubSuite("GUI")]
        [AllureIssue("TMS-12")]
        [AllureTms("TMS-13")]
        [AllureTag("Smoke")]
        [AllureLink("https://daryaprasniak1.testrail.io/")]
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
