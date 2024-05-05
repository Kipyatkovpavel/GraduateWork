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

namespace GraduateWork.Tests
{
    [AllureEpic("Web Interface")]
    [AllureFeature("Delete Project")]
    public class DeleteProjectTest : BaseTest
    {
        [Test]
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

/*        [Test]
 //       [Repeat(5)]
        public void DeleteExcessCorrectTest()//Тест для удаления мешающих проектов
        {
            ProjectPage projectPage = _navigationSteps.SuccessAuthorization(Admin);//Авторизация

            AdminPage deleteProject = _navigationSteps.DeleteExcessProject(""); //Удаление проекта
*/

        
    }
}
