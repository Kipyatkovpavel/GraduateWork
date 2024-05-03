using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
    [AllureFeature("UploadFile Project")]
    public class UploadFileTes : BaseTest
    {
        [Test]
        public void UploadFileCorrectTest()
        {
            ProjectPage projectPage = _navigationSteps.SuccessAuthorization(Admin);//Авторизация
            projectPage.ClickAddProjectButton();

            ProjectPage createProject = _navigationSteps.SuccessCreateProjectNotEnd(FirstProject);//Заполнение всех полей для создания проекта, но не нажатие кнопки создания проекта
            createProject.ClickSelectFileButton();//нажатие кнопка Select для выбора файла на добавление
            createProject.FileInput.SendKeys(filePath);//Вставка нашего файла в поле
            createProject.ClickCreateProjectButton();//Завершение создание проекта
            
            Thread.Sleep(3000);//Быстро бежит не всегда успевает прогрузиться

            Assert.That(createProject.CheckThatProjectIconDisplayed);//Проверка отображения нашего изображения на странице созданного проекта
        }
    }
}
