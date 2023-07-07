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
    }
}
