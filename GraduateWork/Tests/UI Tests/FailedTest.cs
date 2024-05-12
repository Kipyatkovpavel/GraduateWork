using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allure.Net.Commons;
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
    [AllureFeature("Create Project")]
    public class FailedTest : BaseTest
    {
        [Test]
        [Description("Проверка на загрузку некорректного файла при создании проекта")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Negative")]
        public void FailedCreateTest()
        {
            ProjectPage projectPage = _navigationSteps.SuccessAuthorization(Admin);//Авторизация
            projectPage.ClickAddProjectButton();

            ProjectPage createProject = _navigationSteps.SuccessCreateProjectNotEnd(FirstProject);//Заполнение всех полей для создания проекта, но не нажатие кнопки создания проекта
            createProject.ClickSelectFileButton();//нажатие кнопка Select для выбора файла на добавление
            createProject.FileInput.SendKeys(failedfilePath);//Вставка неподходящего файла в поле
            Thread.Sleep(3000);//Быстро бежит не всегда успевает прогрузиться

            if (!createProject.ErrorSelectedFileDisplayed())
            {
                Assert.Multiple(() =>
                {
                    createProject.ClickCreateProjectButton();
                    Thread.Sleep(3000);//Быстро бежит не всегда успевает прогрузиться
                    Assert.That(createProject.ContributorsIconDisplayed());//уникальная иконка -убеждаемся, что находимся на нужной нам странице
                    Assert.That(createProject.CheckThatProjectIconDisplayed);//Проверка отображения нашего изображения на странице созданного проекта
                });

            }
            else { Assert.Fail("Проверьте загружаемый файл"); }
        }
    }
}
