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
    public class ProjectService : IProjectService, IDisposable
    {
        private readonly RestClientExtended _client;

        public ProjectService(RestClientExtended client)
        {
            _client = client;
        }
        [AllureStep("Get user")]
        public Task<AuthResponse> GetUser()
        {
            var request = new RestRequest("/api/v1/user");

            return _client.ExecuteAsync<AuthResponse>(request);
        }
        [AllureStep("Get Project by ID")]
        public Task<Projects.ResultContainer> GetProjectById(string projectid)
        {
            var request = new RestRequest("/api/v1/projects/{project_id}")
                .AddUrlSegment("project_id", projectid);

            return _client.ExecuteAsync<Projects.ResultContainer>(request);
        }
        [AllureStep("Get Project by IncorrectId")]
        public Task<ErrorResponseDetails> GetProjectByIncorrectId(string projectid)
        {
            var request = new RestRequest("/api/v1/projects/{project_id}")
                .AddUrlSegment("project_id", projectid);

            return _client.ExecuteAsync<ErrorResponseDetails>(request);
        }
        [AllureStep("Get All Project of user")]
        public Task<ResultProjects> GetAllProjects()
        {
            var request = new RestRequest("/api/v1/projects");

           return _client.ExecuteAsync<ResultProjects>(request);
        }
        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}