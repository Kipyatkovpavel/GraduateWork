﻿using System;
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
        protected MilestonesService? MilestonesService;
        protected string NameForTest { get; set; }
        protected string TestNameMilestones { get; set; }
        protected string TestSummaryMilestones { get; set; }

        [OneTimeSetUp]
        public void SetupApi()
        {
            var restClient = new RestClientExtended();

            ProjectService = new ProjectService(restClient);
            MilestonesService = new MilestonesService(restClient);

            NameForTest = "Kipyatkov Pavel";

            TestNameMilestones = "TestNameMilestones";

            TestSummaryMilestones = "TestSummaryMilestonesl";
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            ProjectService?.Dispose();
            MilestonesService?.Dispose();
        }
    }
}
