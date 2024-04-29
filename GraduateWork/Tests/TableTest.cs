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

namespace GraduateWork.Tests
{
    [AllureEpic("Web Interface")]
    [AllureFeature("Create Project")]
    public class TableTest : BaseTest
    {
        [Test]
        public void AddProjectCorrectTest()
        {
            ProjectPage projectPage = _navigationSteps.SuccessAuthorization(Admin);
            projectPage.ClickAddProjectButton();


            ProjectPage addproject = _navigationSteps.SuccessCreateProject(FirstProject);

            /*            Assert.Multiple(() =>
                         {
                             Assert.That(projectPage.DialogWindowDisplayed);
                             Assert.That(projectPage.NameWindowDisplayed);
                             Assert.That(projectPage.SummaryWindowDisplayed);
                             Assert.That(projectPage.DefaultAccessWindowDisplayed);

                         });*/



            /*            ProjectsPage projectsPage = new ProjectsPage(Driver, true);
                        TableCell tableCell = projectsPage.ProjectsTable.GetCell("Project", "Example1", "Project");
                        tableCell.GetLink().Click();*/
        }
    }
}
