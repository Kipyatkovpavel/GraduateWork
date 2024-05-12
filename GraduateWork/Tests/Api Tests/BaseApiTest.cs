using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allure.NUnit.Attributes;
using Allure.NUnit;
using GraduateWork.Clients;
using GraduateWork.Models;
using GraduateWork.Services;
using Allure.Net.Commons;

namespace GraduateWork.Tests
{
    [Parallelizable(scope: ParallelScope.All)]
    [AllureSuite("API Tests")]
    [AllureNUnit]
    public class BaseApiTest
    {
        protected ProjectService? ProjectService;
        protected MilestonesService? MilestonesService;
        protected AutomationRunsService? AutomationRunsService;
        protected string NameForTest { get; set; }
        protected string TestNameMilestones { get; set; }
        protected string TestSummaryMilestones { get; set; }

        [OneTimeSetUp]
        public void SetupApi()
        {
            var restClient = new RestClientExtended();

            ProjectService = new ProjectService(restClient);
            MilestonesService = new MilestonesService(restClient);
            AutomationRunsService = new AutomationRunsService(restClient);

            NameForTest = "Kipyatkov Pavel";

            TestNameMilestones = "TestNameMilestones";

            TestSummaryMilestones = "TestSummaryMilestones";

            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            ProjectService?.Dispose();
            MilestonesService?.Dispose();
            AutomationRunsService?.Dispose();
        }
    }
}
