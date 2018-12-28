using System;
using Allure.Commons;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework.Interfaces;

namespace NUnit.Task130
{
    public class TestBase : AllureReport
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://tut.by");
            //add implicit waiter
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile(@"D:\training\Selenium\allure-reports\test.png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment(@"D:\training\Selenium\allure-reports\test.png", "Fail");
            }
            driver.Quit();
        }
    }
}
