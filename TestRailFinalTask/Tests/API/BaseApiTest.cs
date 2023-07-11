using NUnit.Allure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailFinalTask.Client;
using TestRailFinalTask.Services;

namespace TestRailFinalTask.Tests.API
{
    [AllureNUnit]
    public class BaseApiTest
    {
        protected ApiClient _apiClient;
        protected SectionService _sectionService;
        protected MilestoneService _milestoneService;

        [OneTimeSetUp]
        public void InitApiClient()
        {
            _apiClient = new ApiClient();
            _sectionService = new SectionService(_apiClient);
            _milestoneService = new MilestoneService(_apiClient);
        }
    }
}
