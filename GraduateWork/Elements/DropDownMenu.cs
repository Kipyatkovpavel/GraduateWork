using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWork.Elements
{
    public class DropDownMenu
    {
        private UIElement _uiElement;
        private List<UIElement> _options;

        private By _locatorOptions = By.XPath("//div[@class='dropdown__items__row dropdown__items__row--item']");
        private By _locator2 = By.CssSelector("[data-type='item']");
       

        public DropDownMenu(IWebDriver webDriver, By locator)
        {
            _uiElement = new UIElement(webDriver, locator);
            _options = _uiElement.FindUIElements(_locatorOptions);

        }

        public void SelectByIndex(int index)
        {
            if (index < 0 || index >= _options.Count)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            _options[index].Click();
        }



        public List<string> GetValues()
        {
            var values = new List<string>();
            var options = _uiElement.FindElements(By.XPath(".//div[@class='dropdown__item']"));
            foreach (var option in options)
            {
                values.Add(option.Text);
            }
            return values;
        }

        public bool Displayed => _uiElement.Displayed;



        public UIElement SelectedOption
        {
            get
            {
                try
                {
                    return _uiElement.FindUIElement(By.CssSelector("[data-type='item']"));
                }
                catch
                {
                    throw new NoSuchElementException("No option is selected");
                }
            }
        }

        public string GetCssValue(string propertyName) => _uiElement.GetCssValue(propertyName);

        private void Click() => _uiElement.Click();

        public List<string> GetOptions()
        {
            var result = new List<string>();
            foreach (UIElement element in _options)
            {
                result.Add(element.Text);
            }
            return result;
        }

        public void SelectByText(string text)
        {
            foreach (UIElement option in _options)
            {
                if (option.Text == text)
                {
                    option.Click();
                    return;
                }
            }

            throw new NoSuchElementException("Element with the specified text not found.");
        }

    }
}
