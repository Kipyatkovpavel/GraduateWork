using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWork.Pages.ProjectPages
{
    public class AddProjectPage : ProjectBasePage
    {
        private static string END_POINT = "index.php?/admin/projects/add";

        // Описание элементов
        private static readonly By AddButtonBy = By.Id("name");



        // Инициализация класса
        public AddProjectPage(IWebDriver driver) : base(driver)
        {
        }

        protected override string GetEndPoint()
        {
            return END_POINT;
        }

        // Атомарные Методы
        public IWebElement AddButton => WaitsHelper.WaitForExists(AddButtonBy);


        public override bool IsPageOpened()
        {
            throw new NotImplementedException();
        }
    }
}


