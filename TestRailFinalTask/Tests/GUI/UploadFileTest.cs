using Allure.Commons;
using NUnit.Allure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestRailFinalTask.Pages;

namespace TestRailFinalTask.Tests.GUI
{
    public class UploadFileTest : BaseGUITest
    {
        [Test(Description = "UploadFile")]
        [Description("Verify user can upload a file in the milestones tab")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("GUI")]
        [AllureIssue(name: "TMS-12")]
        [AllureTms(name: "TMS-13")]
        [AllureTag("Regression")]
        [AllureLink("https://daryaprasniak1.testrail.io/")]
        public void UploadFile()
        {
            string fileName = "TestDoc.docx";
            string projectName = "New test";
            string email = "dashapr@mail.ru";
            string password = "!Qwertyu123";
            string directoryName = "/TestData/";

            var fullFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + directoryName + fileName;

            var dashboardPage = new LoginPage(Driver, true)
                .SuccessfulLogin(email, password)
                .UploadFile(fullFilePath);

            Assert.That(dashboardPage.CheckAttachedFileUploaded, Is.EqualTo(fileName));
        }
    }
}
