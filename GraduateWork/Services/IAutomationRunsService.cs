using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Allure.NUnit.Attributes;
using GraduateWork.Models;
using Newtonsoft.Json.Linq;

namespace GraduateWork.Services
{
    public interface IAutomationRunsService
    {
        [AllureStep("Create Automation Runs on definite project")]
        Task<AutomationRunResponse> PostAutomationRuns(string projectId, AutomationRunRequest requestBody);
        [AllureStep("Get All AutomationRuns on definite project")]
        Task<AllAutomationRuns> GetAllAutomationRunsID(string projectId);
    }
}
