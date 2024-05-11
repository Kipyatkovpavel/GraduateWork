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
        Task<ResultProjects> GetAllProjects();
        Task<Projects.ResultContainer> GetProjectById(string projectid);
        Task<ErrorResponseDetails> GetProjectByIncorrectId(string projectid);
        Task<AuthResponse> GetUser();

    }
}
