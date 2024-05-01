using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduateWork.Pages;
using GraduateWork.Pages.ProjectPages;

namespace GraduateWork.Steps
{
    public class BaseSteps(IWebDriver driver)
    {
        protected readonly IWebDriver Driver = driver;

        protected LoginPage? LoginPage { get; set; }
        protected ProjectPage? ProjectPage { get; set; }
        protected AdminPage? AdminPage { get; set; }


    }
}
