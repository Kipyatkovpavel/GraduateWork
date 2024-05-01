/*using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduateWork.Helpers.Configuration;
using GraduateWork.Helpers;
using OpenQA.Selenium.Interactions;
using System.Drawing;
using System.Collections.ObjectModel;

namespace GraduateWork.Elements
{
    public class Tables : IWebElement
    {
        private UIElement _uiElement;
        private List<string> _columns;
        private List<TableRow> _rows;
        private IWebDriver _webDriver;
        private IWebElement _element;
        private WaitsHelper _waitsHelper;
        private Actions _actions;

        /// <summary>
        /// Локатор данного элемента должен использовать тэг table
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="by"></param>
        public Tables(IWebDriver webDriver)
        {
            _webDriver = webDriver;

        }
        public Tables(IWebDriver webDriver, By by) : this(webDriver)
        {
            _uiElement = new UIElement(webDriver, by);
            _columns = new List<string>();
            _rows = new List<TableRow>();

            UIElement tableHeader = _uiElement.FindElements(By.ClassName("table__header"));
            
            //foreach (var columnElement in tableHeader.FindUIElements(By.TagName("th")))

                // foreach (var columnElement in _uiElement.FindUIElements(By.TagName("th")))
            foreach (var columnElement in tableHeader.FindUIElements(By.TagName("th")))
            {
                _columns.Add(columnElement.Text.Trim());
            }

            foreach (var rowElement in _uiElement.FindUIElements(By.XPath("//tr/following-sibling::tr[position() >= 1]")))
            {
                _rows.Add(new TableRow(rowElement));
            }
        }
        public string Text
        {
            get
            {
                *//*                if (_webElement.Text.Equals(""))
                                    {
                                        if (GetAttribute("value").Equals(""))
                                        {
                                            return GetAttribute("innerText");
                                        }
                                        else
                                        {
                                            return GetAttribute("value");
                                        }
                                    }*//*
                return Text;
            }
        }

        public void Hover()
        {
            _actions.MoveToElement(_uiElement).Build().Perform();
        }

        public bool Enabled => _uiElement.Enabled;

        public bool Selected => _uiElement.Selected;

        public Point Location => _uiElement.Location;

        public Size Size => _uiElement.Size;

        public bool Displayed => _uiElement.Displayed;

        public string TagName => _uiElement.TagName;




        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetColumn"></param>
        /// <param name="uniqueValue"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public TableCell GetCell(string targetColumn, string uniqueValue, string columnName)
        {
            TableRow tableRow = GetRow(targetColumn, uniqueValue);
            return tableRow.GetCell(_columns.IndexOf(columnName));
        }


        public TableCell GetCell(string targetColumn, string uniqueValue, int columnIndex)
        {
            TableRow tableRow = GetRow(targetColumn, uniqueValue);
            if (tableRow != null)
            {
                return tableRow.GetCell(columnIndex);
            }
            else
            {
                return null;
            }
        }



        public TableRow GetRow(string targetColumn, string uniqueValue)
        {
            foreach (var row in _rows)
            {
                if (row.GetCell(_columns.IndexOf(targetColumn)).Text.Equals(uniqueValue))
                {
                    return row;
                }
            }

            return null;
        }

        public IWebElement FindElements(By by)
        {
            return _waitsHelper.WaitChildElement(_uiElement, by);
        }

        public UIElement FindUIElement(By by)
        {
            return new UIElement(_webDriver, FindElements(by));
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return _uiElement.FindElements(by);
        }

        public List<UIElement> FindUIElements(By by)
        {
            var result = new List<UIElement>();
            foreach (var webElement in FindElements(by))
            {
                result.Add(new UIElement(_webDriver, webElement));
            }

            return result;
        }

        public string GetAttribute(string attributeName)
        {
            return _uiElement.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return _uiElement.GetCssValue(propertyName);
        }

        public string GetDomAttribute(string attributeName)
        {
            return _uiElement.GetDomAttribute(attributeName);
        }

        public string GetDomProperty(string propertyName)
        {
            return _uiElement.GetDomProperty(propertyName);
        }

        public ISearchContext GetShadowRoot()
        {
            return _uiElement.GetShadowRoot();
        }

        public void SendKeys(string text)
        {
            _uiElement.SendKeys(text);
        }

        public void Submit()
        {
            _uiElement.Submit();
        }

        public void Clear()
        {
            _uiElement.Clear();
        }

        public void Click()
        {
            try
            {
                _uiElement.Click();

            }
            catch (ElementNotInteractableException)
            {
                try
                {
                    _actions
                         .MoveToElement(_uiElement)
                          .Click()
                            .Build()
                            .Perform();
                }
                catch (Exception)
                {
                    ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].click();", _uiElement);
                }


            }
        }
    }
}
*/