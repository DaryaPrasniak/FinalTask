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

        protected Milestone getMilestoneResponse = TestDataHelper.GetTestMilestone("GetMilestone.json");
        protected Milestone getInvalidMilestoneResponse = TestDataHelper.GetTestMilestone("GetMilestoneInvalid.json");
        protected Milestone addedMilestoneResponse = TestDataHelper.GetTestMilestone("AddMilestone.json");

        [Test]
        public void GetMilestoneTest()
        {
            var actualMilestone = _milestoneService.GetAsMilestone("1");

            Assert.AreEqual(actualMilestone.Name, getMilestoneResponse.Name);
        }

        [Test]
        public void GetMilestoneTestInvalid()
        {
            var actualMilestone = _milestoneService.GetAsMilestone("1");

            Assert.AreEqual(actualMilestone.Name, getInvalidMilestoneResponse.Name);
        }

        [Test]
        public void GetMilestoneTestInvalidEndpoint()
        {
            var actualMilestone = _milestoneService.GetMilestoneInvalid("1");

            Assert.AreEqual(actualMilestone.Name, getMilestoneResponse.Name);
        }

        [Test]
        public void AddMilestoneTest()
        {
            var actualMilestone = _milestoneService.AddMilestone(addedMilestoneResponse.ProjectId, addedMilestoneResponse);

            Assert.AreEqual(actualMilestone.Name, "July Test");
        }
    }
}
