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

namespace GraduateWork.Services
{
    public class ProjectService : IProjectService, IDisposable
    {
        private readonly RestClientExtended _client;

        public ProjectService(RestClientExtended client)
        {
            _client = client;
        }

        public Task<AuthResponse> GetUser()
        {
            var request = new RestRequest("/api/v1/user");

            return _client.ExecuteAsync<AuthResponse>(request);
        }
        public Task<Project> AddProject(Project project)
        {
            var request = new RestRequest("index.php?/api/v2/add_project", Method.Post)
                .AddJsonBody(project);

            return _client.ExecuteAsync<Project>(request);
        }

        public Task<Projects.ResultContainer> GetProjectsById(string id)
        {
            var request = new RestRequest("/api/v1/projects/{project_id}")
                .AddUrlSegment("project_id", id);

            return _client.ExecuteAsync<Projects.ResultContainer>(request);
        }

        public Task<ResultProjects> GetAllProjects()
        {
            var request = new RestRequest("/api/v1/projects");

           return _client.ExecuteAsync<ResultProjects>(request);
        }

 
        public HttpStatusCode DeleteProject(string id)
        {
            var request = new RestRequest("index.php?/api/v2/delete_project/{project_id}", Method.Post)
                .AddUrlSegment("project_id", id)
                .AddJsonBody("{}");

            return _client.ExecuteAsync(request).Result.StatusCode;
        }
        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }

        public Task<Project> UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }


    }
}