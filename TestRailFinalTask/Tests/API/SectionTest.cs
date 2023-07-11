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
        protected Section getSectionResponse = TestDataHelper.GetTestSection("GetSection.json");

        [Test]
        public void GetSectionTest()
        {
            var request = new RestRequest(Endpoints.GET_SECTION_URL)
                .AddUrlSegment("section_id", "1");
            var response = _apiClient.Execute(request);

            var json = response.Content;
            var jsonObject = JsonHelper.FromJson(json);

            Assert.AreEqual(getSectionResponse.Name, "Prerequisites");
        }
    }
}
