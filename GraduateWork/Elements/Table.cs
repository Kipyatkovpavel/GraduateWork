/*
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduateWork.Helpers.Configuration;
using GraduateWork.Helpers;
using OpenQA.Selenium.Support.UI;
using GraduateWork.Elements;
using NUnit.Framework;

namespace GraduateWork.Elements
{
    public class Table
    {
        private UIElement _uiElement;
        private List<string> _columns;
        List<IWebElement> _columnsName;
        private List<TableRow> _rows;

        private List<string> ConvertToStringList(List<IWebElement> elements)
        {
            List<string> stringList = new List<string>();
            foreach (IWebElement element in elements)
            {
                stringList.Add(element.Text);
            }
            return stringList;
        }
        /// <summary>
        /// Локатор данного элемента должен использовать тэг table
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="by"></param>
        public Table(IWebDriver webDriver, By by)
        {
            _uiElement = new UIElement(webDriver, by);
            _columnsName = new List<IWebElement>();
            _rows = new List<TableRow>();
            _columns = new List<string>();

            *//*            foreach (var columnElement in _uiElement.FindUIElements(By.XPath("//th[starts-with(@class,'table__header__')] | //th[contains(@class,'table__header__action')]")))
                        {
                            _columns.Add(columnElement.Text.Trim() != null ? columnElement.Text.Trim() : "");
                        }*/
/*            foreach (var columnElement in _uiElement.FindUIElements(By.XPath("//th[starts-with(@class,'table__header__')] | //th[contains(@class,'table__header__action')]")))
            {
                string columnText = columnElement.Text.Trim();
                Console.WriteLine($"Text of column element: '{columnText}'");
                _columns.Add(columnText);
            }*//*
foreach (var columnElement in _uiElement.FindUIElements(By.XPath("//th[starts-with(@class,'table__header__')] | //th[contains(@class,'table__header__action')]")))
{
    _columnsName.Add(columnElement);

}
//                int index = _columnsName.IndexOf(columnElement);
// By.XPath("//th[starts-with(@class,'table__header__')]")))
*//*            foreach (var columnElement in _uiElement.FindUIElements(By.TagName("th")))
            {
                _columns.Add(columnElement.Text.Trim());
            }*/

/*            _columns = _columnsName
            .Select(columnElement => columnElement.Text.Trim())
            .ToList();*//*

            foreach (var rowElement in _uiElement.FindUIElements(By.XPath("//tr/following-sibling::tr[position() >= 1]")))
            {
                _rows.Add(new TableRow(rowElement));
            }

        }
        public bool Displayed() => _uiElement.Displayed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetColumn"></param>
        /// <param name="uniqueValue"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public TableCell GetCell(string targetColumn, string uniqueValue, string columnName)
        {
            List<string> ConvertToStringList(List<IWebElement> elements)
            {
                List<string> stringList = new List<string>();
                foreach (IWebElement element in elements)
                {
                    stringList.Add(element.Text);
                }
                return stringList;
            }
            _columns = ConvertToStringList(_columnsName);
            TableRow tableRow = GetRow(targetColumn, uniqueValue);
            return tableRow.GetCell(_columns.IndexOf(columnName));
        }



        public TableCell GetCell(string targetColumn, string uniqueValue, int columnIndex)
        {
*//*            TableRow tableRow = GetRow(targetColumn, uniqueValue);
            if (tableRow != null)
            {
                return tableRow.GetCell(columnIndex);
            }
            else
            {
                return null;
            }
*//*
            TableRow tableRow = GetRow(targetColumn, uniqueValue);
            return tableRow.GetCell(columnIndex);
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
    }
}


*/


/*using System.Collections.Generic;
using OpenQA.Selenium;
using GraduateWork.Elements;

namespace GraduateWork.Elements
{
    public class Table
    {
        private UIElement _uiElement;
        private List<string> _columns;
        private List<IWebElement> _columnsName;
        private List<TableRow> _rows;

        private List<string> ConvertToStringList(List<IWebElement> elements)
        {
            List<string> stringList = new List<string>();
            foreach (IWebElement element in elements)
            {
                string text = element.Text != null ? element.Text : "";
                stringList.Add(text);
            }
            return stringList;
        }

        public Table(IWebDriver webDriver, By by)
        {
            _uiElement = new UIElement(webDriver, by);
            _columnsName = new List<IWebElement>();
            _rows = new List<TableRow>();
            _columns = new List<string>();

            foreach (var columnElement in _uiElement.FindUIElements(By.XPath("//th[starts-with(@class,'table__header__')] | //th[contains(@class,'table__header__action')]")))
            {
                _columnsName.Add(columnElement);
            }

            foreach (var rowElement in _uiElement.FindUIElements(By.XPath("//tr/following-sibling::tr[position() >= 1]")))
            {
                _rows.Add(new TableRow(rowElement));
            }

            _columns = ConvertToStringList(_columnsName);
        }

        public bool Displayed() => _uiElement.Displayed;

        public TableCell GetCell(string targetColumn, string uniqueValue, string columnName)
        {
            TableRow tableRow = GetRow(targetColumn, uniqueValue);
            int columnIndex = _columns.IndexOf(columnName);
            if (columnIndex != -1 && tableRow != null)
            {
                return tableRow.GetCell(columnIndex);
            }
            else
            {
                return null;
            }
        }

        public TableCell GetCell(string targetColumn, string uniqueValue, int columnIndex)
        {
            TableRow tableRow = GetRow(targetColumn, uniqueValue);
            return tableRow?.GetCell(columnIndex);
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
    }
}*/



using System.Collections.Generic;
using OpenQA.Selenium;
using GraduateWork.Elements;

namespace GraduateWork.Elements
{
    public class Table
    {
        private UIElement _uiElement;
        private List<string> _columns;
        private List<IWebElement> _columnsName;
        private List<TableRow> _rows;

/*        private List<string> ConvertToStringList(List<IWebElement> elements)
        {
            List<string> stringList = new List<string>();
            foreach (IWebElement element in elements)
            {
                string text = element.Text != null ? element.Text : "";
                stringList.Add(text);
            }
            return stringList;
        }*/

        public Table(IWebDriver webDriver, By by)
        {
            _uiElement = new UIElement(webDriver, by);
            _columnsName = new List<IWebElement>();
            _rows = new List<TableRow>();
            _columns = new List<string>();

            foreach (var columnElement in _uiElement.FindUIElements(By.XPath("//th[starts-with(@class,'table__header__')] | //th[contains(@class,'table__header__action')]")))
            {
                _columnsName.Add(columnElement);
            }

            foreach (var rowElement in _uiElement.FindUIElements(By.XPath("//tr/following-sibling::tr[position() >= 1]")))
            {
                _rows.Add(new TableRow(rowElement));
            }

/*            _columns = ConvertToStringList(_columnsName);*/
        }

        public bool Displayed() => _uiElement.Displayed;

        public TableCell GetCell(int rowIndex, int columnIndex)
        {
            if (rowIndex < 0 || rowIndex >= _rows.Count || columnIndex < 0 || columnIndex >= _columns.Count)
                return null;

            return _rows[rowIndex].GetCell(columnIndex);
        }

        public TableCell GetCell(string uniqueValue, int columnIndex)
        {
            foreach (var row in _rows)
            {
                if (row.GetCell(0).Text.Equals(uniqueValue))
                {
                    return row.GetCell(columnIndex);
                }
            }

            return null;
        }

        // Keeping the method with targetColumn parameter for backward compatibility
        public TableCell GetCell(string targetColumn, string uniqueValue, int columnIndex)
        {
            // Always using the first column index
            return GetCell(uniqueValue, columnIndex);
        }
    }
}