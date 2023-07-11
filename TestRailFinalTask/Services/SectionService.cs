using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailFinalTask.Client;
using TestRailFinalTask.Utilities.Configuration;
using static System.Collections.Specialized.BitVector32;

namespace TestRailFinalTask.Services
{
    public class SectionService : BaseService
    {
        public static readonly string GET_SECTION_URL = "index.php?/api/v2/get_section/{section_id}";

        public SectionService(ApiClient apiClient) : base(apiClient)
        {
        }

        public RestResponse GetSection(string sectionId)
        {
            var request = new RestRequest(Endpoints.GET_SECTION_URL)
                .AddUrlSegment("section_id", sectionId);

            return _apiClient.Execute(request);
        }

        public Section GetAsSection(string sectionId)
        {
            var request = new RestRequest(GET_SECTION_URL)
                .AddUrlSegment("section_id", sectionId);

            return _apiClient.Execute<Section>(request);
        }
    }
}
