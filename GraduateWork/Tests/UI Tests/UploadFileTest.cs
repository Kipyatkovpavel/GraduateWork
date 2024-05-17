using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace GraduateWork.Tests
{
    public class UploadFileTes : BaseTest
    {
        [Test]
        [Description("Проверка создания проекта с загрузкой своего файла, а так же проверка на созданном проекте")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Positive")]
        public void UploadFileCorrectTest()
        {
            ProjectPage projectPage = _navigationSteps.SuccessAuthorization(Admin);//Авторизация
            projectPage.ClickAddProjectButton();

            ProjectPage createProject = _navigationSteps.SuccessCreateProjectNotEnd(FirstProject);//Заполнение всех полей для создания проекта, но не нажатие кнопки создания проекта
            createProject.ClickSelectFileButton();//нажатие кнопка Select для выбора файла на добавление
            createProject.FileInput.SendKeys(filePath);//Вставка нашего файла в поле
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
            else Assert.Fail("Проверьте загружаемый файл");
        }
    }
}
