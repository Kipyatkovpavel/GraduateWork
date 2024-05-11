using GraduateWork.Helpers.Configuration;
using GraduateWork.Models;
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
    public class GetApiTest : BaseApiTest
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [Test]
        [Order(1)]
        public void GetUserApiTest()
        {
            var result = ProjectService!.GetUser();


            _logger.Info(result.Result);
            Assert.Multiple(() =>
            {
                Assert.That(result.Result.Id, Is.EqualTo(1));
                Assert.That(result.Result.Name, Is.EqualTo(NameForTest));

            });
        }

        [Test]
        [Order(2)]
        public void GetAllProjectsApiTest()
        {
            var result = ProjectService!.GetAllProjects();
            
            _logger.Info(result.Result);

            Assert.Multiple(() =>
            {
                Assert.That(result.Result.Page, Is.EqualTo(1));
                Assert.That(result.Result.PerPage, Is.EqualTo(100));
                Assert.That(result.Result.Total, Is.EqualTo(result.Result.Result.Length));
            });
        }
        [Test]
        [Order(3)]
        public void GetCorrectProjectByIdApiTest()
        {
            var result = ProjectService!.GetProjectById("1");

            _logger.Info(result.Result.Result);
            Assert.Multiple(() =>
            {
                Assert.That(result.Result.Result.Name, Is.EqualTo("Test"));
                Assert.That(result.Result.Result.Note, Is.EqualTo("53453"));
                Assert.That(result.Result.Result.IsCompleted == false);
            });
        }

        [Test]
        [Order(4)]
        public void GetIncorrectProjectByIdApiTest()
        {
            var result = ProjectService!.GetProjectByIncorrectId("545");

            _logger.Info(result.Result.Message);
            Assert.Multiple(() =>
            {
                Assert.That(result.Result.Message, Is.EqualTo("The project does not exist or you do not have the permissions to access it."));
            });
        }

        [Test]
        [Order(5)]
        public void GetCorrectMilestonesApiTest()
        {
            var result = MilestonesService!.GetMilestonesById("2");

            _logger.Info(result.Result.Result);
            Assert.Multiple(() =>
            {
                Assert.That(result.Result.Result.Name, Is.EqualTo(TestNameMilestones));
                Assert.That(result.Result.Result.Note, Is.EqualTo(TestSummaryMilestones));
            });
        }

        [Test]
        [Order(6)]
        public void GetInCorrectMilestonesApiTest()
        {
            var result = MilestonesService!.GetMilestonesIncorrectById("545");

            _logger.Info(result.Result.Message);
            Assert.Multiple(() =>
            {
                Assert.That(result.Result.Message, Is.EqualTo("The milestone does not exist or was deleted or belongs to a different project."));
            });
        }

    }
}
