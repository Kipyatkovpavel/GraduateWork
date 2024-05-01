using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWork.Elements
{
    public class CheckBox
    {
        private UIElement _uiElement;

        public CheckBox(IWebDriver webDriver, By by)
        {
            _uiElement = new UIElement(webDriver, by);
        }

        public CheckBox(IWebDriver webDriver, IWebElement webElement)
        {
            _uiElement = new UIElement(webDriver, webElement);
        }

        private void Click()
        {
            _uiElement.Click();
        }

        public void SetCheckbox()
        {
            ToggleCheckbox(true);
        }

        public void RemoveCheckbox()
        {
            SetCheckbox();
            ToggleCheckbox(false);
        }

        private void ToggleCheckbox(bool flag)
        {
            if (IsSelected() == flag)
            {
                _uiElement.Click();
            }
        }

//        public bool Displayed() => _uiElement.Displayed;

        public bool Enabled => _uiElement.Enabled;

        public bool IsSelected()
        {
            string afterAttributeValue = _uiElement.GetAttribute("::after");
            return string.IsNullOrEmpty(afterAttributeValue);
        }
    }
}
