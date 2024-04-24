using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduateWork.Helpers;

namespace GraduateWork.Pages.ProjectPages
{
    public class UpdateProjectPage : ProjectBasePage
    {
        private static string END_POINT = "index.php?/admin/projects/add";

        // Описание элементов
        private static readonly By SaveButtonBy = By.Id("name");


        public UpdateProjectPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        protected override string GetEndPoint()
        {
            return END_POINT;
        }

        public override bool IsPageOpened()
        {
            throw new NotImplementedException();
        }

        // Атомарные Методы
        public IWebElement SaveButton => WaitsHelper.WaitForExists(SaveButtonBy);
    }
}
