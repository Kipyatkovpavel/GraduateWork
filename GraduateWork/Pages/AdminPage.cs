using Allure.NUnit.Attributes;
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
        private static string END_POINT = "/admin/projects";

        // Описание элементов
        private static readonly By ProjectNameInputBy = By.CssSelector("[data-target='name']");
        private static readonly By ProjectSummaryInputBy = By.CssSelector("[data-target='note behavior--maxlength-counter.control']");
        private static readonly By ProjectDefaultAccessInputBy = By.XPath("//div[@class='dropdown__items__row dropdown__items__row--item']");
        private static readonly By AddProjectButtonBy = By.CssSelector("[data-target='home--index.addButton']");//Кнопка +Project
        private static readonly By AdminButtonBy = By.XPath("//a[@data-content='Admin']");//Кнопка Admin
        private static readonly By DropDownDefaultAccessBy = By.ClassName("dropdown__container");//Выпадающее меню DefaultAccess
        private static readonly By CloseWarningMessBy = By.XPath("//button[@data-dismiss='modal']");
        private static readonly By ProjectDialogWindowBy = By.CssSelector("div.dialog__main__content__inner"); //всплывающее сообщение
        private static readonly By CreateProjectButtonBy = By.CssSelector("[data-target='submitButton']"); //Сама кнопка называется Add Project, что бы не было дубликтов
        private static readonly By NameOfCreateProjectBy = By.XPath("//div[@class='page-header__title']");
        private static readonly By ProjectTableBy = By.CssSelector("[data-target='components--table.table']");
        private static readonly By DeleteDialogWindowBy = By.CssSelector("[data-target='title']");
        private static readonly By ProjectButtonBy = By.XPath("//a[@href='https://pavelkipyatkovtest.testmo.net/admin/projects' and @data-content='Projects']");//Кнопка Project после создания проекта
        private static readonly By CheckboxDeleteBy = By.CssSelector("[data-target='confirmationLabel']");                                                                                                                                                            // private static readonly By NameOfCreateProjectBy = By.CssSelector(".page-header__title::text");
        private static readonly By DeleteProjectButtonBy = By.CssSelector("[data-target='deleteButton']");                                                                                                                                                                                                                                                  //        private static readonly By DeleteBasketButtonBy = By.CssSelector("tr[data-name='Test_Delete'] td.table__field__action div[data-action='delete']");
        private static readonly By SummaryOfCreateProjectBy = By.XPath("//div[@class='split-about__note']");
        private static readonly By DeleteIconBy = By.CssSelector("[class='fas fa-ban icon-deleted-entity']");


        public AdminPage(IWebDriver driver) : base(driver)
        {
        }
        public AdminPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
        {

        }
        [AllureStep("Get EndPoint")]
        protected override string GetEndPoint()
        {
            return END_POINT;
        }
        [AllureStep("Checking that page opened")]
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

        public CheckBox CheckboxDelete => new CheckBox(Driver, CheckboxDeleteBy);
        public Button DeleteProjectButton => new Button(Driver, DeleteProjectButtonBy);
        public UIElement ProjectNameInput => new(Driver, ProjectNameInputBy);
        public UIElement ProjectSummaryInput => new(Driver, ProjectSummaryInputBy);
        public UIElement DeleteIcon => new(Driver, DeleteIconBy);
        public IWebElement NameOfCreateProject => WaitsHelper.WaitForExists(NameOfCreateProjectBy);
        public IWebElement SummaryOfCreateProject => WaitsHelper.WaitForExists(SummaryOfCreateProjectBy);

        public UIElement DeleteDialogWindow => new(Driver, DeleteDialogWindowBy); 
 
        public DropDownMenu ProjectDefaultAccessInput => new(Driver, ProjectDefaultAccessInputBy);

        public Table ProjectTable => new(Driver, ProjectTableBy);
        [AllureStep("Click Add Project Button")]
        public void ClickAddProjectButton() => AddProjectButton.Click();
        [AllureStep("Click Add Admin Button")]
        public void ClickAdminButton() => AdminButton.Click();
        [AllureStep("Click Checkbox Delete")]
        public void CheckboxDeleteClick() => CheckboxDelete.Click();
        [AllureStep("Click Delete Project Button")]
        public void DeleteProjectButtonClick() => DeleteProjectButton.Click();
        [AllureStep("Click Project Button")]
        public void ClickProjectButton() => ProjectButton.Click(); //Можно было бы вынести это всё в базовый класс, из ProjectPage и AdminPage...Но времени нет(
        [AllureStep("Click DropDown DefaultAccess Button")]
        public void ClickDropDownDefaultAccess() => DropDownDefaultAccess.Click();
        [AllureStep("Click Create Project Button")]
        public void ClickCreateProjectButton() => CreateProjectButton.Click();

    }
}
