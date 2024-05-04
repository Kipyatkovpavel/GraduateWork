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
using OpenQA.Selenium.Interactions;

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

        protected Actions actions { get; set; }

        protected string assemblyPath { get; set; }

        protected string  filePath { get; set; }

        Random random = new Random();

        protected Project FirstProject { get; set; }


        protected string BoundaryValues0Сharacters { get; set; }

        protected string BoundaryValues1Сharacters { get; set; }
        protected string BoundaryValues40Сharacters { get; set; }

        protected string BoundaryValues79Сharacters { get; set; }
        protected string BoundaryValues80Сharacters { get; set; }

        protected string BoundaryValues81Сharacters { get; set; }

        protected string BoundaryValues200Сharacters { get; set; }
        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;
            WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));

            _navigationSteps = new NavigationSteps(Driver);

            actions = new Actions(Driver);

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



            BoundaryValues0Сharacters = "";

            BoundaryValues1Сharacters = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 1)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            BoundaryValues40Сharacters = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 40)
        .Select(s => s[random.Next(s.Length)]).ToArray());

            BoundaryValues79Сharacters = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 79)
        .Select(s => s[random.Next(s.Length)]).ToArray());

            BoundaryValues80Сharacters = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 80)
        .Select(s => s[random.Next(s.Length)]).ToArray());

            BoundaryValues81Сharacters = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 81)
        .Select(s => s[random.Next(s.Length)]).ToArray());

            BoundaryValues200Сharacters = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 999999)
        .Select(s => s[random.Next(s.Length)]).ToArray());


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
