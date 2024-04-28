using GraduateWork.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWork.Pages
{
    public class ProjectPage : BasePage
    {
        private static string END_POINT = "";

        // Описание элементов

        /*        private static readonly By EmailInputBy = By.Name("email");
                private static readonly By PswInputBy = By.CssSelector("[type='password']");
                private static readonly By LoginInButtonBy = By.CssSelector("[type='submit']");*/
        private static readonly By AddProjectButtonBy = By.CssSelector("[data-target='home--index.addButton']");//Кнопка +Project
        private static readonly By DialogWindowBy = By.CssSelector("div.dialog__main__content__inner"); //всплывающее сообщение


        public ProjectPage(IWebDriver driver) : base(driver)
        {
        }
        public ProjectPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
        {

        }

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

        // Атомарные Методы

        public UIElement DialogWindow => new(Driver,DialogWindowBy);  //всплывающее окно
        public UIElement EmailInput => new(Driver, EmailInputBy);
        public UIElement PswInput => new(Driver, PswInputBy);
        public Button LoginInButton => new(Driver, LoginInButtonBy);
        public UIElement PageTitle => new(Driver, pageTitle);
        public Button AddProjectButton => new(Driver, AddProjectButtonBy);

        public void ClickAddProjectButton() => AddProjectButton.Click();

        public bool DialogWindowDisplayed()
        {
            return DialogWindow.Displayed;
        }

    }
}
