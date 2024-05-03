using OpenQA.Selenium;
using GraduateWork.Helpers;
using GraduateWork.Helpers.Configuration;
using GraduateWork.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduateWork.Steps;
using GraduateWork.Models;
using GraduateWork.Pages;
using System.Reflection;

namespace GraduateWork.Tests
{
    [Parallelizable(scope: ParallelScope.All)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class BaseTest
    {
        protected IWebDriver Driver { get; private set; }
        protected WaitsHelper WaitsHelper { get; private set; }

        protected NavigationSteps _navigationSteps;
        protected User Admin { get; set; }

        protected string assemblyPath { get; set; }

        protected string  filePath { get; set; }

        Random random = new Random();

        protected Project FirstProject { get; set; }


        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;
            WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));

            _navigationSteps = new NavigationSteps(Driver);

            Admin = new User()
            {
                Username = Configurator.AppSettings.Username,
                Password = Configurator.AppSettings.Password
            };

            Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);

            FirstProject = new Project()
            {
                ProjectName = $"ExampleName{new Random().Next(1, 100000)}",
                ProjectSummary = $"ExampleSummary{new Random().Next(1, 100000)}",
                ProjectDefaultAccess = 3,
            };

            assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            filePath = Path.Combine(assemblyPath, "Resources", "ProjectIcon.png");
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
