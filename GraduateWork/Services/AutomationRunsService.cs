using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GraduateWork.Clients;
using GraduateWork.Models;
using GraduateWork.Helpers.Configuration;
using System.Reflection.Metadata;

namespace GraduateWork.Services
{
    public class AutomationRunsService : IAutomationRunsService, IDisposable
    {
        private readonly RestClientExtended _client;

        public AutomationRunsService(RestClientExtended client)
        {
            _client = client;
        }


       public Task<AutomationRunResponse> PostAutomationRuns(int projectId, AutomationRunRequest requestBody)
        {
            var request = new RestRequest("/api/v1/projects/1/automation/runs", Method.Post)
                .AddUrlSegment("project_id", projectId)
                .AddJsonBody(requestBody);

            return _client.ExecuteAsync<AutomationRunResponse>(request);
        }


 
        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}