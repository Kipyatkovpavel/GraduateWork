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
using Allure.NUnit.Attributes;

namespace GraduateWork.Services
{
    public class AutomationRunsService : IAutomationRunsService, IDisposable
    {
        private readonly RestClientExtended _client;

        public AutomationRunsService(RestClientExtended client)
        {
            _client = client;
        }

        [AllureStep("Create Automation Runs on definite project")]
        public Task<AutomationRunResponse> PostAutomationRuns(string projectId, AutomationRunRequest requestBody)
        {
            var request = new RestRequest("/api/v1/projects/{project_id}/automation/runs", Method.Post)
                .AddUrlSegment("project_id", projectId)
                .AddJsonBody(requestBody);

            return _client.ExecuteAsync<AutomationRunResponse>(request);
        }
        [AllureStep("Get All AutomationRuns on definite project")]
        public Task<AllAutomationRuns> GetAllAutomationRunsID(string projectId)
        {
            var request = new RestRequest("/api/v1/projects/{project_id}/automation/runs")
                .AddUrlSegment("project_id", projectId);

            return _client.ExecuteAsync<AllAutomationRuns>(request);
        }
        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}