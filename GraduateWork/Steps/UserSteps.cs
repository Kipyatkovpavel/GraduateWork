using Allure.NUnit.Attributes;
using GraduateWork.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWork.Steps
{
    public class UserSteps : BaseSteps
    {
        private ProjectPage _projectPage;
        private LoginPage _loginPage;
        public UserSteps(IWebDriver driver) : base(driver)
        {
            _loginPage = new LoginPage(driver);
            _projectPage = new ProjectPage(driver);
        }

        //Complex Методы
//        [AllureStep]
        public LoginPage SuccessFulLogin(string username, string password)
        {
            _loginPage.EmailInput.SendKeys(username);
            _loginPage.PswInput.SendKeys(password);
            _loginPage.LoginInButton.Click();

            return _loginPage;
            //return new LoginPage(Driver);
        }

        public ProjectPage SuccessAuthorization(string username, string password)
        {
            _projectPage.EmailInput.SendKeys(username);
            _projectPage.PswInput.SendKeys(password);
            _projectPage.LoginInButton.Click();

            return _projectPage;
            //return new LoginPage(Driver);
        }

        public LoginPage IncorrectLogin(string username, string password)
        {
            _loginPage.EmailInput.SendKeys(username);
            _loginPage.PswInput.SendKeys(password);
            _loginPage.LoginInButton.Click();

            return _loginPage;
        }
    }
}
