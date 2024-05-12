﻿using GraduateWork.Elements;
using Microsoft.Playwright;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWork.Helpers
{
    public class WaitsHelper(IWebDriver driver, TimeSpan timeout)
    {
        private readonly WebDriverWait _wait = new WebDriverWait(driver, timeout);

        //Видимый элемент
        public IWebElement WaitForVisibilityLocatedBy(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public ReadOnlyCollection<IWebElement> WaitForPresenceOfAllElementsLocatedBy(By locator)
        {
            return _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        }

        //Поиск всех элементов которые будут соответсвевовать локатору(и возвращает коллекцию) 
        public ReadOnlyCollection<IWebElement> WaitForAllVisibleElementsLocatedBy(By locator)
        {
            return _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

        //Присутсвтвие 
        public IWebElement WaitForExists(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public UIElement WaitChildElement(IWebElement webElement, By by)
        {
            return new UIElement(driver, _wait.Until(_ => webElement.FindElement(by)));
        }
        //Невидимый элемент
        public bool WaitForElementInvisible(By locator)
        {
            //return _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
            return _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public bool WaitForElementInvisible(IWebElement webElement)
        {
            try
            {
                // Проверка, видим ли элемент
                return _wait.Until(d => !webElement.Displayed);
            }
            catch (NoSuchElementException)
            {
                // Если элемент не найден, считаем его невидимым
                return true;
            }
            catch (StaleElementReferenceException)
            {
                // Если элемент устарел, считаем его невидимым
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException("Элемент не стал невидимым в течение заданного времени");
            }


        }
        public bool WaitForVisibility(IWebElement element)
        {
            return _wait.Until(_ => element.Displayed);
        }
        public IWebElement FluentWaitForElement(By locator)
        {
            // Инициализация и параметризация FluentWait
            WebDriverWait fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(12))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50)
            };

            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            // Использование
            return fluentWait.Until(_ => driver.FindElement(locator));
        }

        public bool CheckElementExists(By locator)
        {
            try
            {
                // Попытка найти элемент
                return _wait.Until(driver => driver.FindElements(locator).Any());
            }
            catch (NoSuchElementException)
            {
                // Если элемент не найден, возвращаем false
                return false;
            }
        }
    
    }
}
