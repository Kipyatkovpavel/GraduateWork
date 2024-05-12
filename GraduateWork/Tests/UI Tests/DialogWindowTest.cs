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
    public class DialogWindowTest : BaseTest
    {
        [Test]
        [Description("Проверка на отображения диалогового окна (окна создания проекта)")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Positive")]
        public void SuccesfullLoginAndAddProjectTest()
        {

            ProjectPage projectPage = _navigationSteps.SuccessAuthorization(Admin);
            projectPage.ClickAddProjectButton();
            
            Assert.That(projectPage.DialogWindowDisplayed);

        }
    }
}
