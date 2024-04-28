using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GraduateWork.Elements;

namespace GraduateWork.Pages
{
    public class ProjectsPage : BasePage
    {
        private static string END_POINT = "index.php?/admin/projects/overview";

        // Описание элементов
        private static readonly By TitleLabelBy = By.ClassName("page_title");
        private static readonly By AddProjectButtonBy = By.XPath("//*[contains(text(), 'Add Project')]");
        private static readonly By ProjectsTableBy = By.CssSelector("table.grid");


        // Инициализация класса
        public ProjectsPage(IWebDriver driver) : base(driver)
        {
        }

        public ProjectsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        protected override string GetEndPoint()
        {
            return END_POINT;
        }

        public override bool IsPageOpened()
        {
            return TitleLabel.Text.Trim().Equals("Projects");
        }

        // Атомарные Методы
        public UIElement TitleLabel => new(Driver, TitleLabelBy);
        public Button AddProjectButton => new(Driver, AddProjectButtonBy);
        public Table ProjectsTable => new(Driver, ProjectsTableBy);
    }
}
