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

        public RestRequest Authorization(string key, string token) //только для проверки корректной  и некорректной авторизации.В остальных апи тестах не используется
        {
            var request = new RestRequest("api/v1/user")
             .AddHeader(key, $"Bearer {token}");

            return request;
/*            return new RestRequest()
    .AddHeader("Authorization", $"Bearer {token}");*/

        }
        public Task<Project> AddProject(Project project)
        {
            var request = new RestRequest("index.php?/api/v2/add_project", Method.Post)
                .AddJsonBody(project);

            return _client.ExecuteAsync<Project>(request);
        }

        /*        public Task<Projects> GetProject(string projectId)
                {
                    var request = new RestRequest("index.php?/api/v2/get_project/{project_id}")
                            .AddUrlSegment("project_id", projectId);

                   return _client.ExecuteAsync<Project>(request);
                }*/

        public async Task<Result> GetAllProjects(string key, string token)
        {
            var request = new RestRequest("api/v1/projects")
                .AddHeader(key, $"Bearer {token}");
            var response = await _client.ExecuteAsync<Result>(request);

            return response;
        }

/*        public Task<Result> GetAllProjects(string key, string token, )
        {
            var request = new RestRequest("api/v1/{user}")
             .AddUrlSegment("user", id)
             .AddHeader(key, $"Bearer {token}");

            var request1 = new RestRequest("index.php?/api/v1/projects/");
            var response = _client.ExecuteAsync<Result>(request1);

            return response;
        }*/

        /*        public Task<Project> UpdateProject(Project project)
                {
                    var request = new RestRequest("index.php?/api/v2/update_project/{project_id}", Method.Post)
                        .AddUrlSegment("project_id", project.Id)
                        .AddJsonBody(project);

                    return _client.ExecuteAsync<Project>(request);
                }*/

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
