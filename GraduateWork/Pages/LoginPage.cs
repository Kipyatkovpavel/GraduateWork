using NUnit.Framework.Internal;
using OpenQA.Selenium;
using GraduateWork.Helpers.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using GraduateWork.Elements;

namespace GraduateWork.Pages
{
    public class LoginPage : BasePage
    {
        private static string END_POINT = "";
        //Описание элементов

        //Вынесены в базовый класс для уменьшения кол-ва кода.
        private static readonly By IconProfileBy = By.CssSelector("div.navbar__user__avatar");
        private static readonly By PopUpProfileNameOfIconProfileBy = By.CssSelector(".navbar__user__avatar__profile__description__header");
        private static readonly By PopUpInformationOfIconProfileBy = By.XPath("//div[@class='navbar__user__avatar__profile__description']/p[contains(text(), 'My profile & settings')]");

        //инициализация класса + переорпеделения
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public LoginPage(IWebDriver driver, bool openByUrl) : base(driver)
        {

        }


        //Атомарные методы
        public IWebElement EmailInput => WaitsHelper.WaitForExists(EmailInputBy);
        public IWebElement ErrorLabel => WaitsHelper.WaitForExists(ErrorLabelBy);
        public IWebElement PswInput => WaitsHelper.WaitForExists(PswInputBy);
        public Button LoginInButton => new(Driver, LoginInButtonBy);
        public IWebElement PageTitle => WaitsHelper.WaitForExists(pageTitle);

/*        public UIElement IconProfile => new(Driver, IconProfileBy);
        public UIElement PopUpProfileNameOfIconProfile => new(Driver, PopUpProfileNameOfIconProfileBy);
        public UIElement PopUpInformationOfIconProfile => new(Driver, PopUpInformationOfIconProfileBy);*/

        public IWebElement IconProfile => WaitsHelper.WaitForExists(IconProfileBy);
        public IWebElement PopUpProfileNameOfIconProfile => WaitsHelper.WaitForExists(PopUpProfileNameOfIconProfileBy);
        public IWebElement PopUpInformationOfIconProfile => WaitsHelper.WaitForExists(PopUpInformationOfIconProfileBy);


        //Complex Методы

        protected override string GetEndPoint()
        {
            return END_POINT;
        }
        public override bool IsPageOpened()
        {
            try
            {
                return PageTitle.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
