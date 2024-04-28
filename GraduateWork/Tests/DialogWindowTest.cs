using AngleSharp;
using GraduateWork.Helpers.Configuration;
using GraduateWork.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduateWork.Steps;
using GraduateWork.Tests;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;


namespace GraduateWork.Tests
{
    [AllureEpic("Web Interface")]
    [AllureFeature("Login feature")]
    public class DialogWindowTest : BaseTest
    {
        [Test(Description = "Проверка на отображения диалогового окна (окна создания проекта)")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Story2")]
        public void SuccesfullLoginAndAddProjectTest()
        {

            // NavigationSteps navigationSteps = new NavigationSteps(Driver);
            ProjectPage projectPage = _navigationSteps.SuccessAuthorization(Admin);
            projectPage.ClickAddProjectButton();
            
            Assert.That(projectPage.DialogWindowDisplayed);

        }
    }
}
