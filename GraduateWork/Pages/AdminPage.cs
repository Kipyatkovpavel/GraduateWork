using GraduateWork.Elements;
using GraduateWork.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GraduateWork.Pages
{
    public class AdminPage : BasePage
    {
        private static string END_POINT = "index.php?/admin";
        //https://pavelkipyatkov.testmo.net/admin/projects
        // Описание элементов
        private static readonly By ProjectNameInputBy = By.CssSelector("[data-target='name']");
        private static readonly By ProjectSummaryInputBy = By.CssSelector("[data-target='note behavior--maxlength-counter.control']");
        private static readonly By ProjectDefaultAccessInputBy = By.XPath("//div[@class='dropdown__items__row dropdown__items__row--item']");
        //private static readonly By ProjectDefaultAccessInputBy = By.XPath("//div[@class='dropdown__items']");
        private static readonly By AddProjectButtonBy = By.CssSelector("[data-target='home--index.addButton']");//Кнопка +Project
        private static readonly By AdminButtonBy = By.XPath("//a[@data-content='Admin']");//Кнопка Admin
        private static readonly By DropDownDefaultAccessBy = By.ClassName("dropdown__container");//Выпадающее меню DefaultAccess
        private static readonly By CloseWarningMessBy = By.XPath("//button[@data-dismiss='modal']");
        private static readonly By ProjectDialogWindowBy = By.CssSelector("div.dialog__main__content__inner"); //всплывающее сообщение
        private static readonly By CreateProjectButtonBy = By.CssSelector("[data-target='submitButton']"); //Сама кнопка называется Add Project, что бы не было дубликтов
        private static readonly By NameOfCreateProjectBy = By.XPath("//div[@class='page-header__title']");
        private static readonly By ProjectTableBy = By.CssSelector("[data-target='components--table.table']");
        private static readonly By ProjectButtonBy = By.XPath("//a[@href='https://pavelkipyatkov.testmo.net/admin/projects' and @data-content='Projects']");//Кнопка Project после создания проекта
        // private static readonly By NameOfCreateProjectBy = By.CssSelector(".page-header__title::text");

        //private static readonly By NameOfCreateProjectBy = By.XPath("//div[@class='page-header__title' and contains(text(), '')]");

        //private static readonly By NameOfCreateProjectBy = By.Id("name-field");
        private static readonly By SummaryOfCreateProjectBy = By.XPath("//div[@class='split-about__note']");
 //       private static readonly By SummaryOfCreateProjectBy = By.CssSelector(".split-about__note::text");
       // private static readonly By SummaryOfCreateProjectBy = By.XPath("//div[@class='split-about__note' and contains(text(), '')]");
        //private static readonly By SummaryOfCreateProjectBy = By.Id("summary-field");


        public AdminPage(IWebDriver driver) : base(driver)
        {
        }
        public AdminPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
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

        public UIElement ProjectDialogWindow => new(Driver, ProjectDialogWindowBy);  //всплывающее окно
        public UIElement EmailInput => new(Driver, EmailInputBy);
        public UIElement PswInput => new(Driver, PswInputBy);
        public Button LoginInButton => new(Driver, LoginInButtonBy);
           public UIElement PageTitle => new(Driver, pageTitle);
        public Button AddProjectButton => new(Driver, AddProjectButtonBy);
        public Button AdminButton => new(Driver, AdminButtonBy);
        public Button ProjectButton => new(Driver, ProjectButtonBy);
        public Button CreateProjectButton => new(Driver, CreateProjectButtonBy);

        public Button DropDownDefaultAccess => new(Driver, DropDownDefaultAccessBy);
        // public Button CloseWarningMess => new(Driver, CloseWarningMessBy);


        public UIElement ProjectNameInput => new(Driver, ProjectNameInputBy);
        public UIElement ProjectSummaryInput => new(Driver, ProjectSummaryInputBy);
        public IWebElement NameOfCreateProject => WaitsHelper.WaitForExists(NameOfCreateProjectBy);
        public IWebElement SummaryOfCreateProject => WaitsHelper.WaitForExists(SummaryOfCreateProjectBy);

        public DropDownMenu ProjectDefaultAccessInput => new(Driver, ProjectDefaultAccessInputBy);

        public Table ProjectTable => new(Driver, ProjectTableBy);
        


        public void ClickAddProjectButton() => AddProjectButton.Click();

        public void ClickAdminButton() => AdminButton.Click();
        public void ClickProjectButton() => ProjectButton.Click();

        public void ClickDropDownDefaultAccess() => DropDownDefaultAccess.Click();
        public void ClickCreateProjectButton() => CreateProjectButton.Click();

        public bool ProjectTableDisplayed()
        {
            return ProjectTable.Displayed();
        }
        public bool NameProjectDisplayed()
        {
            return ProjectDialogWindow.Displayed;
        }


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
