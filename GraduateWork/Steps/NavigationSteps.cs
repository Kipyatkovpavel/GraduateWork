using Allure.NUnit.Attributes;
using GraduateWork.Elements;
using GraduateWork.Models;
using GraduateWork.Pages;
using GraduateWork.Steps;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWork.Steps
{
    public class NavigationSteps : BaseSteps
    {
        public NavigationSteps(IWebDriver driver) : base(driver)
        {
        }
        [AllureStep]
        public LoginPage SuccessFulLogin(User user)
        {
            return Login<LoginPage>(user);

        }
        [AllureStep("Incorrect Login")]
        public LoginPage IncorrectLogin(User user)
        {
            return Login<LoginPage>(user);
        }
        [AllureStep("Success Authorization")]
        public ProjectPage SuccessAuthorization(User user)
        {
            return Login<ProjectPage>(user);
        }
        [AllureStep("Success Create Project")]
        public ProjectPage SuccessCreateProject(Project project)
        {
            return CreateProject<ProjectPage>(project);
        }
        [AllureStep("Success Delete Project")]
        public AdminPage SuccessDeleteProject(Project project)
        {
            return DeleteProject<AdminPage>(project);
        }

        [AllureStep("Create Project but not click Add Project")]
        public ProjectPage SuccessCreateProjectNotEnd(Project project)
        {
            return CreateProjectNotEnd<ProjectPage>(project);
        }

        [AllureStep("Create Project")]
        public T CreateProject<T>(Project project) where T : BasePage
        {
            ProjectPage = new ProjectPage(Driver);
            ProjectPage.ProjectNameInput.SendKeys(project.ProjectName);
            ProjectPage.ProjectSummaryInput.SendKeys(project.ProjectSummary);
            ProjectPage.ClickDropDownDefaultAccess();
            ProjectPage.ProjectDefaultAccessInput.SelectByIndex(project.ProjectDefaultAccess);
            ProjectPage.ClickCreateProjectButton();

            return (T)Activator.CreateInstance(typeof(T), Driver, false);
        }
        [AllureStep("Delete Project")]
        public T DeleteProject<T>(Project project) where T : BasePage
        {
            AdminPage adminPage = new AdminPage(Driver);
            adminPage.ClickAdminButton();
            adminPage.ClickProjectButton();
            TableCell tableCell = adminPage.ProjectTable.GetCell("Project", project.ProjectName, 3);
            tableCell.DeleteAction().Click();
            adminPage.CheckboxDeleteClick();
            adminPage.DeleteProjectButtonClick();

            return (T)Activator.CreateInstance(typeof(T), Driver, false);
        }
        [AllureStep("Delete Excess Project")]
        public AdminPage DeleteExcessProject (string Delete) 
        {
            AdminPage adminPage = new AdminPage(Driver);
            adminPage.ClickAdminButton();
            adminPage.ClickProjectButton();
            TableCell tableCell = adminPage.ProjectTable.GetCell("", Delete, 3);
            tableCell.DeleteAction().Click();
            adminPage.CheckboxDeleteClick();
            adminPage.DeleteProjectButtonClick();

            return AdminPage;
        }
        [AllureStep("Authorization")]
        public T Login<T>(User user) where T : BasePage
        {
            LoginPage = new LoginPage(Driver);
            LoginPage.EmailInput.SendKeys(user.Username);
            LoginPage.PswInput.SendKeys(user.Password);
            LoginPage.LoginInButton.Click();

            return (T)Activator.CreateInstance(typeof(T), Driver, false);
        }
        [AllureStep("Create Project but not click Add Project")]
        public T CreateProjectNotEnd<T>(Project project) where T : BasePage
        {
            ProjectPage = new ProjectPage(Driver);
            ProjectPage.ProjectNameInput.SendKeys(project.ProjectName);
            ProjectPage.ProjectSummaryInput.SendKeys(project.ProjectSummary);
            ProjectPage.ClickDropDownDefaultAccess();
            ProjectPage.ProjectDefaultAccessInput.SelectByIndex(project.ProjectDefaultAccess);

            return (T)Activator.CreateInstance(typeof(T), Driver, false);
        }
        [AllureStep("Input Summary Field")]
        public ProjectPage InputSummaryField(string count)
        {
            ProjectPage = new ProjectPage(Driver);
            ProjectPage.ProjectSummaryInput.SendKeys(count);
            return ProjectPage;
        }

    }
}
