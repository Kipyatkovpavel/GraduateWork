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
using GraduateWork.Steps;
using GraduateWork.Tests;
using OpenQA.Selenium;

namespace GraduateWork.Tests
{
    [AllureEpic("Web Interface")]
    [AllureFeature("Delete Project")]
    public class BoundaryValuesTest : BaseTest
    {
        [Test]
        public void BoundaryValuesTestCorrectTest()
        {
            ProjectPage projectPage = _navigationSteps.SuccessAuthorization(Admin);//Авторизация
            projectPage.ClickAddProjectButton();

            ProjectPage Summary1Characters = _navigationSteps.InputSummaryField(BoundaryValues1Сharacters);//Внесение summary = 1 знак.
            Assert.That(Summary1Characters.NumberOfCharacters.Text.Equals("1/80"));
            Summary1Characters.ClearSummaryField();//Очистка поля

            ProjectPage Summary0Characters = _navigationSteps.InputSummaryField(BoundaryValues0Сharacters);//Внесение summary = 0 знаков.
            Assert.That(Summary0Characters.NumberOfCharacters.Text.Equals("0/80"));
            Summary0Characters.ClearSummaryField();//Очистка поля

            ProjectPage Summary40Characters = _navigationSteps.InputSummaryField(BoundaryValues40Сharacters);//Внесение summary = 40 знаков.
            Assert.That(Summary40Characters.NumberOfCharacters.Text.Equals("40/80"));
            Summary40Characters.ClearSummaryField();//Очистка поля

            ProjectPage Summary79Characters = _navigationSteps.InputSummaryField(BoundaryValues79Сharacters);//Внесение summary = 79 знаков.
            Assert.That(Summary79Characters.NumberOfCharacters.Text.Equals("79/80"));
            Summary79Characters.ClearSummaryField();//Очистка поля

            ProjectPage Summary80Characters = _navigationSteps.InputSummaryField(BoundaryValues80Сharacters);//Внесение summary = 80 знаков.
            Assert.That(Summary80Characters.NumberOfCharacters.Text.Equals("80/80"));
            Summary80Characters.ClearSummaryField();//Очистка поля
        }

        [Test]
        public void BoundaryValuesTestIncorrectTest()
        {
            ProjectPage projectPage = _navigationSteps.SuccessAuthorization(Admin);//Авторизация
            projectPage.ClickAddProjectButton();//Очистка поля

            ProjectPage Summary81Characters = _navigationSteps.InputSummaryField(BoundaryValues81Сharacters);//Внесение summary = 81 знако.
            Assert.That(Summary81Characters.NumberOfCharacters.Text.Equals("80/80"));
            Summary81Characters.ClearSummaryField();//Очистка поля

            ProjectPage Summary100Characters = _navigationSteps.InputSummaryField(BoundaryValues100Сharacters);//Внесение summary = 100 знаков.
            Assert.That(Summary100Characters.NumberOfCharacters.Text.Equals("80/80"));
            Summary100Characters.ClearSummaryField();//Очистка поля

            //не стал делать тут 10.000 проверок различных.Суть не меняется.



        }
    }
}
