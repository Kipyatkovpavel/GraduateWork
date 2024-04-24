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


namespace GraduateWork.Tests
{
    [AllureEpic("Web Interface")]
    [AllureFeature("Login feature")]
    public class LoginTest : BaseTest
    {
        [Test(Description = "Проверка ввода правильного Логина/Пароля")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Story1")]
        public void SuccesfullLoginTest()
        {

            UserSteps userSteps = new UserSteps(Driver);
            LoginPage loginPage = userSteps.SuccessFulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            Assert.That(loginPage.IsPageOpened);

        }

        [Test(Description = "Проверка неправильного Логина и сравнение с ошибкой")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Story2")]
        public void InvalidUserNameLoginTest()
        {
            //Проверка
            Assert.That(
                new UserSteps(Driver)
                .IncorrectLogin("pykipyao@mts.ru", Configurator.AppSettings.Password)
                .ErrorLabel.Text.Trim(),
                Is.EqualTo("These credentials do not match our records or the user account is not allowed to log in."));
        }
    }
}
