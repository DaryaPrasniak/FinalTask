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
        public static readonly string GET_SECTION = "index.php?/api/v2/get_section/{section_id}";

        public SectionService(ApiClient apiClient) : base(apiClient)
        {
        }

        public RestResponse GetSection(string sectionId)
        {
            var request = new RestRequest(Endpoints.GET_SECTION)
                .AddUrlSegment("section_id", sectionId);

            return _apiClient.Execute(request);
        }

        public Section GetAsSection(string sectionId)
        {
            var request = new RestRequest(GET_SECTION)
                .AddUrlSegment("section_id", sectionId);

            return _apiClient.Execute<Section>(request);
        }

        public Task<RestResponse> GetSectionAsync(string sectionId)
        {
            var request = new RestRequest("index.php?/api/v2/get_section/{section_id}")
                .AddUrlSegment("section_id", sectionId);

            return _apiClient.ExecuteAsync(request);
        }

        public Section GetAsSectionAsync(string sectionId)
        {
            var request = new RestRequest("index.php?/api/v2/get_section/{section_id}")
                .AddUrlSegment("section_id", sectionId);

            return _apiClient.ExecuteAsync<Section>(request).Result;
        }

        public Task<Section> AddSectionAsync(Section section)
        {
            var request = new RestRequest("index.php?/api/v2/add_section/{section_id}", Method.Post)
            .AddHeader("Content-Type", "application/json")
                .AddBody(section);

            return _apiClient.ExecuteAsync<Section>(request);
        }

        public RestResponse UpdateSection(string sectionId, Section section)
        {
            return null;
        }

        public RestResponse DeleteSection(string sectionId)
        {
            return null;
        }

    }
}
