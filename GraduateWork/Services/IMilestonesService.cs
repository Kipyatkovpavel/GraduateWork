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
    public interface IMilestonesService
    {
        [AllureStep("Get Miltestones by Incorrect ID")]
        Task<ErrorResponseDetails> GetMilestonesIncorrectById(string milestoneid);
        [AllureStep("Get Miltestones by ID")]
        Task<Milestones.ResultContainer> GetMilestonesById(string milestoneid);
    }
}