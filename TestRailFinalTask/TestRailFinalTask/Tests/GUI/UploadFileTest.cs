using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailFinalTask.Pages;

namespace TestRailFinalTask.Tests.GUI
{
    public class UploadFileTest : BaseGUITest
    {
        [Test]
        public void UploadFile()
        {
            string projectName = "New test";
            string email = "dashapr@mail.ru";
            string password = "!Qwertyu123";
            string filePath = "C:/Users/DaryaPrasniak/TMSTests/TestDoc.docx";

            var dashboardPage = new LoginPage(Driver, true)
                .SuccessfulLogin(email, password)
                .UploadFile(filePath);

            var expectedFileName = "TestDoc.docx";

            Assert.That(dashboardPage.CheckAttachedFileUploaded, Is.EqualTo(expectedFileName));
        }
    }
}
