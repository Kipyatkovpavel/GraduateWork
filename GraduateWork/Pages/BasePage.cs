using Allure.NUnit.Attributes;
using GraduateWork.Helpers;
using GraduateWork.Helpers.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWork.Pages
{
    public abstract class BasePage
    {
        //Элементы относящиеся к Начальному окну с Авторизацией
        protected static readonly By EmailInputBy = By.Name("email");//Окно ввода email
        protected static readonly By PswInputBy = By.CssSelector("[type='password']");//Окно ввода password
        protected static readonly By LoginInButtonBy = By.CssSelector("[type='submit']");//Кнопка для продолжения аутентификации
        protected static readonly By ErrorLabelBy = By.CssSelector(".message-block");//Ошибка при неверном вводе логина/пароля
        protected static readonly By pageTitle = By.ClassName("page-title__title");//вкладка Project


        //Элементы относящиеся к Созданию проекта
        private static readonly By AddProjectButtonBy = By.CssSelector("[data-target='home--index.addButton']");//Кнопка добавления проекта = +Project

        protected IWebDriver Driver { get; private set; }
        protected WaitsHelper WaitsHelper { get; private set; }

        protected abstract string GetEndPoint();
        public abstract bool IsPageOpened();

        [AllureStep("Открыта страница")]
        protected void OpenPageByURL()
        {
            Driver.Navigate().GoToUrl(Configurator.AppSettingsUI.URL + GetEndPoint());
        }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));
        }

        public BasePage(IWebDriver driver, bool openPageByUrl = false)
        {
            Driver = driver;
            WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));

            if (openPageByUrl)
            {
                OpenPageByURL();
            }
        }
    }
}
