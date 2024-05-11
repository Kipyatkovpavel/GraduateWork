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
        public void PostAddProjectApiTest()
        {
            AddProjectRequest requestBody = new AddProjectRequest()
            {
                Name = "TestApiCreate",
                Note = "TestSummaryApi",
                IsCompleted = false,
                Access = [],
                AvatarId = 18,
                AvatarIndex = null,
                DefaultAccess = 2,
                DefaultRoleId = null
            };
            _logger.Info(requestBody.ToString());
            var response = ProjectService!.AddProject(requestBody);

            _logger.Info(response.Result.ToString());

        }
    }
}
