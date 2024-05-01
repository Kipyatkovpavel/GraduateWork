using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWork.Elements
{
    public class TableCell
    {
        private UIElement _uiElement;
        private IWebDriver _webDriver;
        public TableCell(UIElement uiElement)
        {
            _uiElement = uiElement;
        }

        public UIElement DeleteAction() => _uiElement.FindUIElement(By.TagName("div"));
        //       public UIElement DeleteAction() => _uiElement.FindUIElement(By.XPath("//div[@data-action='delete']"));
        public string Text => _uiElement.Text;
        public bool Displayed() => _uiElement.Displayed;


    }
}
