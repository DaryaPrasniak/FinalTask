using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailFinalTask.Core;

namespace TestRailFinalTask.Tests.GUI
{
    public class BaseGUITest
    {
        protected IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
