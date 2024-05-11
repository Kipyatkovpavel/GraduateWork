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
    public interface IAutomationRunsService
    {
        Task<AutomationRunResponse> PostAutomationRuns(int projectId, AutomationRunRequest requestBody);
        Task<AllAutomationRuns> GetAllAutomationRunsID(string projectId);
    }
}
