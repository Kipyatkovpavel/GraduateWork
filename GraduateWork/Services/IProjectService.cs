using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GraduateWork.Models;
using Newtonsoft.Json.Linq;

namespace GraduateWork.Services
{
    public interface IProjectService
    {
        Task<ResultProject> GetAllProjects();
        Task<Project> AddProject(Project project);
        Task<Project> UpdateProject(Project project);
        HttpStatusCode DeleteProject(string id);
    }
}
