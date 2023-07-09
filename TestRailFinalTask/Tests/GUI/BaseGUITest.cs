using Allure.Commons;
using NLog;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailFinalTask.Core;

namespace TestRailFinalTask.Tests.GUI
{
    [AllureNUnit]
    public class BaseGUITest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private AllureLifecycle _allure;

        protected IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            _logger.Trace(message: "Message level Trace");
            _logger.Debug(message: "Message level Debug");
            _logger.Info(message: "Message level Information");
            _logger.Warn(message: "Message level Warning");
            _logger.Error(message: "Message level Error");
            _logger.Fatal(message: "Message level Fatal");

            Driver = new Browser().Driver;

            _allure = AllureLifecycle.Instance;
        }

        [TearDown]
        public void TearDown()
        {
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                _allure.AddAttachment("Screenshot", "image/png", screenshotBytes);
            }

            Driver.Quit();
            Driver.Dispose();
        }
    }
}
