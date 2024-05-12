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
    public class ProjectPage : BasePage
    {
        private static string END_POINT = "";

        // Описание элементов
        private static readonly By ProjectNameInputBy = By.CssSelector("[data-target='name']");
        private static readonly By ProjectSummaryInputBy = By.CssSelector("[data-target='note behavior--maxlength-counter.control']");
        private static readonly By ProjectDefaultAccessInputBy = By.XPath("//div[@class='dropdown__items__row dropdown__items__row--item']");
        private static readonly By AddProjectButtonBy = By.CssSelector("[data-target='home--index.addButton']");//Кнопка +Project
        private static readonly By AdminButtonBy = By.XPath("//a[@data-content='Admin']");//Кнопка Admin
        private static readonly By DropDownDefaultAccessBy = By.ClassName("dropdown__container");//Выпадающее меню DefaultAccess
        private static readonly By ProjectDialogWindowBy = By.CssSelector("div.dialog__main__content__inner"); //всплывающее сообщение
        private static readonly By CreateProjectButtonBy = By.CssSelector("[data-target='submitButton']"); //Сама кнопка называется Add Project, что бы не было дубликтов
        private static readonly By NameOfCreateProjectBy = By.XPath("//div[@class='page-header__title']");
        private static readonly By ProjectButtonBy = By.XPath("//a[@href='https://pavelkipyatkovtest.testmo.net/admin/projects' and @data-content='Projects']");//Кнопка Project после создания проекта
        private static readonly By SelectFileButtonBy = By.CssSelector("[data-action='click->doSelectAvatar']");
        private static readonly By FileInputBy = By.CssSelector("[data-target='fileInput']");
        private static readonly By ProjectIconBy = By.XPath("//img[starts-with(@src,'https://pavelkipyatkovtest.testmo.net/attachments/view/')]");
        private static readonly By SummaryOfCreateProjectBy = By.XPath("//div[@class='split-about__note']");
        private static readonly By NumberOfCharactersBy = By.CssSelector("div.maxlength-counter__counter");
        private static readonly By ContributorsIconBy = By.CssSelector("div.split-about__section-header");
        private static readonly By ErrorSelectedFileBy = By.XPath("//div[contains(@class, 'admin-projects-select-avatar__error') and contains(@class, 'admin-projects-select-avatar__error--visible')]");

        public ProjectPage(IWebDriver driver) : base(driver)
        {
        }
        public ProjectPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
        {

        }
        [AllureStep("Checking Get EndPoint")]
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
        public UIElement ProjectNameInput => new(Driver, ProjectNameInputBy);
        public UIElement ProjectSummaryInput => new(Driver, ProjectSummaryInputBy);
        public IWebElement NameOfCreateProject => WaitsHelper.WaitForExists(NameOfCreateProjectBy);
        public IWebElement SummaryOfCreateProject => WaitsHelper.WaitForExists(SummaryOfCreateProjectBy);
        public DropDownMenu ProjectDefaultAccessInput => new(Driver, ProjectDefaultAccessInputBy);
        public UIElement ProjectIcon => new(Driver, ProjectIconBy);
        public Button SelectFileButton => new(Driver, SelectFileButtonBy);
        public UIElement FileInput => new(Driver, FileInputBy);
        public UIElement ContributorsIcon => new(Driver, ContributorsIconBy);

        public UIElement NumberOfCharacters => new(Driver, NumberOfCharactersBy);

        [AllureStep("Click Add Project Button")]
        public void ClickAddProjectButton() => AddProjectButton.Click();
        [AllureStep("Click Admin Button")]
        public void ClickAdminButton() => AdminButton.Click();
        [AllureStep("Click Project Button")]
        public void ClickProjectButton() => ProjectButton.Click();
        [AllureStep("Click DropDown Default Access")]
        public void ClickDropDownDefaultAccess() => DropDownDefaultAccess.Click(); //Можно было бы вынести это всё в базовый класс, из ProjectPage и AdminPage...Но времени нет(
        [AllureStep("Click Create Project Button")]
        public void ClickCreateProjectButton() => CreateProjectButton.Click();
        [AllureStep("Click Select File Button")]
        public void ClickSelectFileButton() => SelectFileButton.Click();
        [AllureStep("Check that Error of Upload file is Displayed")]
        public bool ErrorSelectedFileDisplayed()
        {
            return UIElement.IsElementPresent(Driver, ErrorSelectedFileBy);
        }
        [AllureStep("Check that Project Icon Displayed")]
        public bool CheckThatProjectIconDisplayed()
        {
            return ProjectIcon.Displayed;
        }
        [AllureStep("Check that Dialog Window Displayed")]
        public bool DialogWindowDisplayed()
        {
            return ProjectDialogWindow.Displayed;
        }
        [AllureStep("Check that Contributors Icon Displayed")]
        public bool ContributorsIconDisplayed()
        {
            return ContributorsIcon.Displayed;
        }
        [AllureStep("Clear Field Summary")]
        public void ClearSummaryField()
        {
            ProjectSummaryInput.Clear();
        }

    }
}
