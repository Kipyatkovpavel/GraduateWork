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
        private static readonly By ProjectNameInputBy = By.CssSelector("[data-target='name']");
        private static readonly By ProjectSummaryInputBy = By.CssSelector("[data-target='note behavior--maxlength-counter.control']");
        private static readonly By ProjectDefaultAccessInputBy = By.XPath("//div[@class='dropdown__items__row dropdown__items__row--item']");
        //private static readonly By ProjectDefaultAccessInputBy = By.XPath("//div[@class='dropdown__items']");
        private static readonly By AddProjectButtonBy = By.CssSelector("[data-target='home--index.addButton']");//Кнопка +Project
        private static readonly By DropDownDefaultAccessBy = By.ClassName("dropdown__container");//Выпадающее меню DefaultAccess
        private static readonly By CloseWarningMessBy = By.XPath("//button[@data-dismiss='modal']");
        private static readonly By ProjectDialogWindowBy = By.CssSelector("div.dialog__main__content__inner"); //всплывающее сообщение


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

        public Table ProjectDialogWindow => new(Driver, ProjectDialogWindowBy);  //всплывающее окно
        public UIElement EmailInput => new(Driver, EmailInputBy);
        public UIElement PswInput => new(Driver, PswInputBy);
        public Button LoginInButton => new(Driver, LoginInButtonBy);
        public UIElement PageTitle => new(Driver, pageTitle);
        public Button AddProjectButton => new(Driver, AddProjectButtonBy);

        public Button DropDownDefaultAccess => new(Driver, DropDownDefaultAccessBy);
        public Button CloseWarningMess => new(Driver, CloseWarningMessBy);


        public UIElement ProjectNameInput => new(Driver, ProjectNameInputBy);
        public UIElement ProjectSummaryInput => new(Driver, ProjectSummaryInputBy);

        public DropDownMenu ProjectDefaultAccessInput => new(Driver, ProjectDefaultAccessInputBy);


        public void ClickAddProjectButton() => AddProjectButton.Click();

        public void ClickDropDownDefaultAccess() => DropDownDefaultAccess.Click();
        public void ClickCloseWarningMess() => CloseWarningMess.Click();
        public bool DialogWindowDisplayed()
        {
            return ProjectDialogWindow.Displayed;
        }

        public bool NameWindowDisplayed()
        {
            return ProjectNameInput.Displayed;
        }

        public bool SummaryWindowDisplayed()
        {
            return ProjectSummaryInput.Displayed;
        }

        public bool DefaultAccessWindowDisplayed()
        {
            return ProjectDialogWindow.Displayed;
        }

    }
}
