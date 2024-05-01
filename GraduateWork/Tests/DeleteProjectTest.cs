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
using GraduateWork.Pages.ProjectPages;
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
        public void AddAndDeleteNewProjectCorrectTest()
        {
            ProjectPage projectPage = _navigationSteps.SuccessAuthorization(Admin);//Авторизация
 //           projectPage.ClickAddProjectButton();

/*            ProjectPage createProject = _navigationSteps.SuccessCreateProject(FirstProject);//Создание проекта
            Assert.Multiple(() =>
               {
                   Assert.That(FirstProject.ProjectName.Equals(createProject.NameOfCreateProject.Text));
                   Assert.That(FirstProject.ProjectSummary.Equals(createProject.SummaryOfCreateProject.Text));

               });*/


            projectPage.ClickAdminButton();
            AdminPage adminPage = new AdminPage(Driver);
            adminPage.ClickProjectButton();

            if (UIElement.IsElementPresent(Driver, By.CssSelector("[data-target='components--table.table']")))
            {
                TableCell tableCell = adminPage.ProjectTable.GetCell("Project", "dsaad", 3);
            }
            else
            {
                // Обработка ситуации, когда элемент не найден
            }
            adminPage.ProjectTable.Displayed();
/*            TableCell tableCell = adminPage.ProjectTable.GetCell("Project", "Project23", 3);

            adminPage.ProjectTable.Displayed();*/




            /*            // Найдите значения созданного проекта
                        ProjectsPage projectsPage = new ProjectsPage(Driver, true);
                        TableCell tableCell = projectsPage.ProjectsTable.GetCell("Project", "Example1", "Project");
                        tableCell.GetLink().Click();*/
        }
    }
}
