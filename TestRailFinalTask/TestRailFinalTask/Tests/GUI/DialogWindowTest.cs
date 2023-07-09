using Allure.Commons;
using NUnit.Allure.Attributes;
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
        [Test(Description = "DialogWindowOpened")]
        [Description("Verify the dialog window is displayed if click 'Refine' button on the Dashboard page")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("GUI")]
        [AllureIssue(name: "TMS-12")]
        [AllureTms(name: "TMS-13")]
        [AllureTag("Smoke")]
        [AllureLink("https://daryaprasniak1.testrail.io/")]
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
