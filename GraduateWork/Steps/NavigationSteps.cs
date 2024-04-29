﻿using GraduateWork.Models;
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

        public LoginPage SuccessFulLogin(User user)
        {
            return Login<LoginPage>(user);

        }

        public LoginPage IncorrectLogin(User user)
        {
            return Login<LoginPage>(user);
        }

        public ProjectPage SuccessAuthorization(User user)
        {
            return Login<ProjectPage>(user);
        }

        public ProjectPage SuccessCreateProject(Project project)
        {
            return CreateProject<ProjectPage>(project);
        }

        public T CreateProject<T>(Project project) where T : BasePage
        {
            ProjectPage = new ProjectPage(Driver);
            ProjectPage.ProjectNameInput.SendKeys(project.ProjectName);
            ProjectPage.ProjectSummaryInput.SendKeys(project.ProjectSummary);
            ProjectPage.ClickDropDownDefaultAccess();
            ProjectPage.ProjectDefaultAccessInput.SelectByIndex(project.ProjectDefaultAccess);
            ProjectPage.ClickCloseWarningMess();

            return (T)Activator.CreateInstance(typeof(T), Driver, false);


        }

        public T Login<T>(User user) where T : BasePage
        {
            LoginPage = new LoginPage(Driver);
            LoginPage.EmailInput.SendKeys(user.Username);
            LoginPage.PswInput.SendKeys(user.Password);
            LoginPage.LoginInButton.Click();

            return (T)Activator.CreateInstance(typeof(T), Driver, false);
        }
    }
}
