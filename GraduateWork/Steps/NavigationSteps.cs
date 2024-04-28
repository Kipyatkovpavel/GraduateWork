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
