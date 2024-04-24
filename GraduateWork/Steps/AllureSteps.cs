using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWork.Steps
{
    public class AllureSteps : BaseSteps
    {
        public AllureSteps(IWebDriver driver) : base(driver)
        {
        }

        [AllureStep("Test {url}")]
        public void TestDomain([Name("Webpage URL")] string url)
        {
            // Добавление дополнительной информации
            AllureLifecycle.Instance.UpdateStep(stepResult =>
                stepResult.parameters.Add(
                    new Parameter
                    {
                        name = "Started at",
                        value = DateTime.Now.ToString()
                    }
                )
            );

            OpenBrowser();
            GoToWebpage(url);
            CloseBrowser();
        }

        [AllureStep("Open web browser")]
        private void OpenBrowser()
        {
            Assert.That(true);
        }

        [AllureStep("Visit {url}")]
        private void GoToWebpage([Skip] string url)
        {
            Assert.That(true);
        }

        [AllureStep("Close web browser")]
        private void CloseBrowser()
        {
            Assert.That(true);
        }
    }
}
