using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailFinalTask.Models;
using TestRailFinalTask.Utilities.Helpers;

namespace TestRailFinalTask.Tests.API
{
    public class MilestoneTest : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        protected Milestone expectedMilestoneResponse = TestDataHelper.GetTestMilestone("GetMilestone.json");
        protected Milestone expectedInvalidMilestoneResponse = TestDataHelper.GetTestMilestone("GetMilestoneInvalid.json");
        protected Milestone expectedAddedMilestoneResponse = TestDataHelper.GetTestMilestone("AddMilestone.json");

        [Test]
        public void GetMilestoneTest()
        {
            var actualMilestone = _milestoneService.GetAsMilestone("1");

            Assert.AreEqual(actualMilestone.Name, expectedMilestoneResponse.Name);
        }

        [Test]
        public void GetMilestoneTestInvalid()
        {
            var actualMilestone = _milestoneService.GetAsMilestone("1");

            Assert.AreEqual(actualMilestone.Name, expectedInvalidMilestoneResponse.Name);
        }

        [Test]
        public void AddMilestoneTest()
        {
            var actualMilestone = _milestoneService.AddMilestone(expectedAddedMilestoneResponse.ProjectId, expectedAddedMilestoneResponse);

            Assert.AreEqual(actualMilestone.Name, "July Test");
        }
    }
}
