using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWork.Elements
{
    public class TableCell //ячейка
    {
        private UIElement _uiElement;

        public TableCell(UIElement uiElement)
        {
            _uiElement = uiElement;
        }

        public UIElement GetLink() => _uiElement.FindUIElement(By.TagName("a"));
        public string Text => _uiElement.Text;
    }
}
