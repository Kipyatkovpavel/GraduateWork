using GraduateWork.Helpers.Configuration;
using GraduateWork.Models;
using GraduateWork.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NLog;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GraduateWork.Tests.Api_Tests
{
    public class PostApiTest : BaseApiTest
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [Test]
        [Order(1)]
        public void PostAutomationRunsApiTest()
        {
            AutomationRunRequest requestBody = new AutomationRunRequest()
            {
                Name = "test",
                Source = "frontend",
            };
            _logger.Info(requestBody.ToString());
            var response = AutomationRunsService!.PostAutomationRuns(1, requestBody);
            Thread.Sleep(3000);
            var AllAutomationRuns = AutomationRunsService.GetAllAutomationRunsID("1");

            _logger.Info(response.Result.ToString());
            Assert.That(response.Result.Id, Is.EqualTo(AllAutomationRuns.Result.Total));
        }
    }
}