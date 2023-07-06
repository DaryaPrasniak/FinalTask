using AngleSharp.Text;
using Newtonsoft.Json.Linq;
using NLog;
using NUnit.Framework.Internal;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailFinalTask.Models;
using TestRailFinalTask.Services;
using TestRailFinalTask.Utilities.Configuration;
using TestRailFinalTask.Utilities.Helpers;
using Logger = NLog.Logger;

namespace TestRailFinalTask.Tests.API
{
    public class SectionTest : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        protected Section getSectionResponse = TestDataHelper.GetTestSection("GetSection.json");

        [Test]
        public void GetSectionTest()
        {
            var request = new RestRequest(Endpoints.GET_SECTION)
                .AddUrlSegment("section_id", "1");
            var response = _apiClient.Execute(request);
            _logger.Info(response.Content.NormalizeLineEndings());

            var json = response.Content;

            var jsonObject = JsonHelper.FromJson(json);

            var value = jsonObject.SelectToken("$.name");
            _logger.Info("jsonObject1 -> name: " + value);

            Assert.AreEqual(getSectionResponse.Name, "Prerequisites");
        }
    }
}
