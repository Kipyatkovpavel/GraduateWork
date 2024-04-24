using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduateWork.Elements;
using GraduateWork.Pages;

namespace GraduateWork.Pages.ProjectPages
{
    public class ProjectBasePage : BasePage
    {
        private static string END_POINT = "index.php?/admin/projects/add";

        private static readonly By NameInputBy = By.Id("name");
        private static readonly By ProjectTypeRadioButtonBy = By.Name("suite_mode");
        public ProjectBasePage(IWebDriver driver) : base(driver)
        {
        }

        public ProjectBasePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public override bool IsPageOpened()
        {
            throw new NotImplementedException();
        }

        protected override string GetEndPoint()
        {
            throw new NotImplementedException();
        }
        // Атомарные Методы
        public RadioButton ProjectTypeRadioButton => new RadioButton(Driver, ProjectTypeRadioButtonBy);
    }
}
