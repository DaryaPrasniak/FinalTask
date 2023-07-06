using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailFinalTask.Client;
using TestRailFinalTask.Models;
using TestRailFinalTask.Utilities.Configuration;

namespace TestRailFinalTask.Services
{
    public class MilestoneService : BaseService
    {
        public MilestoneService(ApiClient apiClient) : base(apiClient)
        {
        }

        public RestResponse GetMilestone(int milestoneId)
        {
            var request = new RestRequest(Endpoints.GET_MILESTONE)
                .AddUrlSegment("milestone_id", milestoneId);

            return _apiClient.Execute(request);
        }

        public Milestone GetAsMilestone(string milestoneId)
        {
            var request = new RestRequest(Endpoints.GET_MILESTONE);
            request.AddUrlSegment("milestone_id", milestoneId);

            return _apiClient.Execute<Milestone>(request);
        }

        public Milestone GetMilestoneInvalid(string milestoneId)
        {
            var request = new RestRequest(Endpoints.POST_MILESTONE);
            request.AddUrlSegment("milestone_id", milestoneId);

            return _apiClient.Execute<Milestone>(request);
        }

        public Milestone AddMilestone(int projectId, Milestone newMilestone)
        {
            var request = new RestRequest(Endpoints.POST_MILESTONE, Method.Post)
                .AddUrlSegment("project_id", projectId)
                .AddHeader("Content-Type", "application/json")
                .AddBody(newMilestone);

            return _apiClient.Execute<Milestone>(request);
        }
    }
}
