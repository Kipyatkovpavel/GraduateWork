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

    public class BoundaryValuesTest : BaseTest
    {
        [Test]
        [Description("Тест на проверку поля Summary для ввода на корректные граничные значения от (0-80)")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Positive")]
        public void BoundaryValuesTestCorrectTest()
        {

            ProjectPage projectPage = _navigationSteps.SuccessAuthorization(Admin);//Авторизация
            projectPage.ClickAddProjectButton();

            AllureApi.Step("Checking 1/80");
            ProjectPage Summary1Characters = _navigationSteps.InputSummaryField(BoundaryValues1Сharacters);//Внесение summary = 1 знак.
            Assert.That(Summary1Characters.NumberOfCharacters.Text.Equals("1/80"));
            Summary1Characters.ClearSummaryField();//Очистка поля

            AllureApi.Step("Checking 0/80");
            ProjectPage Summary0Characters = _navigationSteps.InputSummaryField(BoundaryValues0Сharacters);//Внесение summary = 0 знаков.
            Assert.That(Summary0Characters.NumberOfCharacters.Text.Equals("0/80"));
            Summary0Characters.ClearSummaryField();//Очистка поля

            AllureApi.Step("Checking 40/80");
            ProjectPage Summary40Characters = _navigationSteps.InputSummaryField(BoundaryValues40Сharacters);//Внесение summary = 40 знаков.
            Assert.That(Summary40Characters.NumberOfCharacters.Text.Equals("40/80"));
            Summary40Characters.ClearSummaryField();//Очистка поля

            AllureApi.Step("Checking 79/80");
            ProjectPage Summary79Characters = _navigationSteps.InputSummaryField(BoundaryValues79Сharacters);//Внесение summary = 79 знаков.
            Assert.That(Summary79Characters.NumberOfCharacters.Text.Equals("79/80"));
            Summary79Characters.ClearSummaryField();//Очистка поля

            AllureApi.Step("Checking 80/80");
            ProjectPage Summary80Characters = _navigationSteps.InputSummaryField(BoundaryValues80Сharacters);//Внесение summary = 80 знаков.
            Assert.That(Summary80Characters.NumberOfCharacters.Text.Equals("80/80"));
            Summary80Characters.ClearSummaryField();//Очистка поля
        }

        [Test]
        [Description("Тест на проверку поля Summary для ввода на некорректные граничные значения от (80+)")]
        [AllureFeature("Negative")]
        public void BoundaryValuesTestIncorrectTest()
        {
            ProjectPage projectPage = _navigationSteps.SuccessAuthorization(Admin);//Авторизация
            projectPage.ClickAddProjectButton();//Очистка поля

            AllureApi.Step("Checking 81/80");
            ProjectPage Summary81Characters = _navigationSteps.InputSummaryField(BoundaryValues81Сharacters);//Внесение summary = 81 знако.
            Assert.That(Summary81Characters.NumberOfCharacters.Text.Equals("80/80"));
            Summary81Characters.ClearSummaryField();//Очистка поля

            AllureApi.Step("Checking 100/80");
            ProjectPage Summary100Characters = _navigationSteps.InputSummaryField(BoundaryValues100Сharacters);//Внесение summary = 100 знаков.
            Assert.That(Summary100Characters.NumberOfCharacters.Text.Equals("80/80"));
            Summary100Characters.ClearSummaryField();//Очистка поля

            //не стал делать тут 10.000 проверок различных.Суть не меняется.

        }
    }
}
