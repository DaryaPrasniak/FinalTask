using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailFinalTask.Pages;

namespace TestRailFinalTask.Tests.GUI
{
    public class PopUpWindowTest : BaseGUITest
    {
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
