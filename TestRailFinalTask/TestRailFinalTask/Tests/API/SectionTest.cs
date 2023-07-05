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
using TestRailFinalTask.Utilities.Helpers;
using Logger = NLog.Logger;

namespace TestRailFinalTask.Tests.API
{
    public class SectionTest : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        protected Section expectedSectionResponse = TestDataHelper.GetTestSection("GetSection.json");

        [Test]
        public void GetSectionTest_1()
        {
            var request = new RestRequest("index.php?/api/v2/get_section/{section_id}")
                .AddUrlSegment("section_id", "1");
            var response = _apiClient.Execute(request);
            _logger.Info(response.Content.NormalizeLineEndings());

            var json = response.Content;

            // Выполним десериализацию JSON-строки в объект JObject
            var jsonObject = JsonHelper.FromJson(json);

            // Использование JsonPath для извлечения занчения из объекта
            var value = jsonObject.SelectToken("$.name");
            _logger.Info("jsonObject1 -> name: " + value);
        }

        [Test]
        public void GetSectionTest()
        {
            var actualSection = _sectionService.GetAsSection("1");
            _logger.Info("Actual Section: " + actualSection.ToString());

        }
    }
}
