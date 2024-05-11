using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduateWork.Clients;
using GraduateWork.Models;
using GraduateWork.Services;

namespace GraduateWork.Tests
{
    public class BaseApiTest
    {
        protected ProjectService? ProjectService;
        protected string NameForTest { get; set; }

        [OneTimeSetUp]
        public void SetupApi()
        {
            var restClient = new RestClientExtended();

            ProjectService = new ProjectService(restClient);

            NameForTest = "Kipyatkov Pavel";
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            ProjectService?.Dispose();
        }
    }
}
