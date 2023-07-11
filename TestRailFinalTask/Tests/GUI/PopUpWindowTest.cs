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
    public class PopUpWindowTest : BaseGUITest
    {
        [Test(Description = "PopUpWindowOpened")]
        [Description("Verify the pop up is displayed if hover over 'Upgrade' button on the Dashboard page")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("GUI")]
        [AllureIssue(name: "TMS-12")]
        [AllureTms(name: "TMS-13")]
        [AllureTag("Smoke")]
        [AllureLink("https://daryaprasniak1.testrail.io/")]
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
