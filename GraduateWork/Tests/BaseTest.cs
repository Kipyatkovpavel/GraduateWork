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
            
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
