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
