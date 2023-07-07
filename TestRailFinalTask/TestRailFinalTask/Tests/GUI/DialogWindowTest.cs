using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailFinalTask.Pages;
using TestRailFinalTask.Tests.API;

namespace TestRailFinalTask.Tests.GUI
{
    public class DialogWindowTest : BaseGUITest
    {
        [Test]
        public void DialogWindowOpened()
        {
            string email = "dashapr@mail.ru";
            string password = "!Qwertyu123";

            var dashboardPage = new LoginPage(Driver, true)
                .SuccessfulLogin(email, password)
                .ClickRefineButton();
                
            Assert.Multiple(() =>
            {
                Assert.IsTrue(dashboardPage.CheckDialogWindowDisplayed());
                Assert.IsTrue(dashboardPage.CheckCalenderOnDialogWindowDisplayed());
            });          
        }
    }
}
