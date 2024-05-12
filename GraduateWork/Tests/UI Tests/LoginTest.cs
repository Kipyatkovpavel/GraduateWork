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
using System.ComponentModel.DataAnnotations;
using GraduateWork.Models;


namespace GraduateWork.Tests
{

    public class LoginTest : BaseTest
    {
        [Test]
        [Description("Проверка авторизации ")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Positive")]
        public void SuccesfullLoginTest()
        {


            LoginPage loginPage = _navigationSteps.SuccessFulLogin(Admin);
            Assert.That(loginPage.IsPageOpened);

        }

        [Test]
        [Description("Проверка некорректной авторизации,указание неправильного логина и проверка ошибки)")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Negative")]
        public void InvalidUserNameLoginTest()
        {
            //Проверка
            Assert.That(
                _navigationSteps
                .IncorrectLogin(new User
                {
                    Username = "pykipyao@mts.ru",
                    Password = Configurator.AppSettingsUI.Password
                })
                .ErrorLabel.Text.Trim(),
                Is.EqualTo("These credentials do not match our records or the user account is not allowed to log in."));
        }
    }
}
