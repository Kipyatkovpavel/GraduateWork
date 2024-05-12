using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Allure.NUnit.Attributes;
using GraduateWork.Models;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace GraduateWork.Services
{
    public interface IProjectService
    {
        [AllureStep("Get All Project of user")]
        Task<ResultProjects> GetAllProjects();
        [AllureStep("Get Project by ID")]
        Task<Projects.ResultContainer> GetProjectById(string projectid);
        [AllureStep("Get Project by IncorrectId")]
        Task<ErrorResponseDetails> GetProjectByIncorrectId(string projectid);
        [AllureStep("Get user")]
        Task<AuthResponse> GetUser();

    }
}
