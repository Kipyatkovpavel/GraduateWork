using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using GraduateWork.Elements;
using GraduateWork.Helpers.Configuration;
using GraduateWork.Models;
using GraduateWork.Pages;
using GraduateWork.Steps;
using GraduateWork.Tests;
using OpenQA.Selenium;

namespace GraduateWork.Tests
{
    public class DeleteProjectTest : BaseTest
    {
        [Test]
        [Description("Тест на удаление создание и удаление созданого Проекта")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Positive")]
        public void DeleteProjectCorrectTest()
        {
            ProjectPage projectPage = _navigationSteps.SuccessAuthorization(Admin);//Авторизация
            projectPage.ClickAddProjectButton();

            ProjectPage createProject = _navigationSteps.SuccessCreateProject(FirstProject);//Создание проекта
            Assert.Multiple(() =>
            {
                Assert.That(FirstProject.ProjectName.Equals(createProject.NameOfCreateProject.Text));
                Assert.That(FirstProject.ProjectSummary.Equals(createProject.SummaryOfCreateProject.Text));
            });
            AdminPage deleteProject = _navigationSteps.SuccessDeleteProject(FirstProject); //Удаление проекта
            Assert.That(deleteProject.DeleteIcon.Displayed);

        }

        [Test]
        [Description("Тест на удаление Проекта(дополнительный тест, позволяющий почистить проекты)")]
        [AllureSeverity(SeverityLevel.trivial)]
        [AllureFeature("Positive")]
        public void DeleteExcessCorrectTest()//Тест для удаления мешающих проектов( Для запуска апи тестов требуется прогнать все UI тесты)
        {
            ProjectPage projectPage = _navigationSteps.SuccessAuthorization(Admin);//Авторизация
            Thread.Sleep(10000);
            AdminPage deleteProject = _navigationSteps.DeleteExcessProject(""); //Удаление проекта
        }
    }
}
