using GraduateWork.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectSimple.Pages
{
    public class ProductsPage : BasePage
    {
        private static string END_POINT = "index.php?/dashboard";
        //Описание элементов
        private static readonly By TitleLabelBy = By.ClassName("title");

        //инициализация класса + переорпеделения
        public ProductsPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement TitleLabel => Driver.FindElement(TitleLabelBy);

        protected override string GetEndPoint()
        {
            return END_POINT;
        }
        public override bool IsPageOpened()
        {
            throw new NotImplementedException();
        }
    }
}

