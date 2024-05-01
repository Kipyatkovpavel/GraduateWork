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
            projectPage.ClickAddProjectButton();

            ProjectPage createProject = _navigationSteps.SuccessCreateProject(FirstProject);//Создание проекта
            Assert.Multiple(() =>
            {
                Assert.That(FirstProject.ProjectName.Equals(createProject.NameOfCreateProject.Text));
                Assert.That(FirstProject.ProjectSummary.Equals(createProject.SummaryOfCreateProject.Text));

            });
            AdminPage adminPage = new AdminPage(Driver);
            //           createProject.ClickAdminButton();
            adminPage.ClickAdminButton();
            //            AdminPage adminPage = new AdminPage(Driver);
            adminPage.ClickProjectButton();

            //            Assert.That(adminPage.ProjectTable.Displayed);
            /*            if (UIElement.IsElementPresent(Driver, By.CssSelector("[data-target='components--table.table']")))
                        {
                            Assert.Pass(); //AdminPage tableCell = adminPage.ProjectTable.GetCell("Project", "dsaad", "Project");
                        }
                        else
                        {
                            Assert.Fail();
                        }*/
            /*            if (adminPage.ProjectTable.Displayed())
                        {
                            Assert.Pass();
                        }
                        else
                        {
                            Assert.Fail();
                        }*/

            /*            adminPage.ClickProjectButton();
                        if (adminPage.ProjectButton.Displayed())
                        {
                            Assert.Pass();
                        }
                        else
                        {
                            Assert.Fail();
                        }*/

            //           adminPage.ProjectTable.Displayed();




            //            TableCell tableCell = adminPage.ProjectTable.GetCell("Project", "Project23", 3);/*

            //            adminPage.ProjectTable.Displayed();




            /*            // Найдите значения созданного проекта
                        ProjectsPage projectsPage = new ProjectsPage(Driver, true);
                        TableCell tableCell = projectsPage.Projects*//*Table.GetCell("Project", "Example1", "Project");
                        tableCell.GetLink().Click();*/
        }
    }
}
