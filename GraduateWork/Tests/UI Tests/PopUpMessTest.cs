using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allure.NUnit.Attributes;
using GraduateWork.Elements;
using GraduateWork.Helpers.Configuration;
using GraduateWork.Models;
using GraduateWork.Pages;
using GraduateWork.Steps;
using GraduateWork.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace GraduateWork.Tests
{
    [AllureEpic("Web Interface")]
    [AllureFeature("Delete Project")]
    public class PopUpMessTest : BaseTest
    {
        [Test]
        public void PopUpMessCorrectTest()
        {
            LoginPage loginPage = _navigationSteps.SuccessFulLogin(Admin); ;//Авторизация

            actions
                .MoveToElement(loginPage.IconProfile)
                .Build()
                .Perform();

            Assert.Multiple(() =>
            {
                Assert.That(loginPage.PopUpProfileNameOfIconProfile.Text.Equals("Kipyatkov Pavel"));
                Assert.That(loginPage.PopUpInformationOfIconProfile.Text.Equals("My profile & settings"));
            });

        }
    }
}
