using NUnit.Framework;
using NUnit.Task130.pages;
using Allure.NUnit.Attributes;
using Allure.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace NUnit.Task130
{
    [TestFixture]
    [Parallelizable]
    public class LogoutCheck : AllureReport
    {
        protected RemoteWebDriver driver;
        string username = "seleniumtests@tut.by";
        string pw = "123456789zxcvbn";
        string undefined = "Войти";

        [SetUp]
        public void SetUp()
        {
            DriverOptions capabilities = new ChromeOptions();
            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capabilities.ToCapabilities());

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://tut.by");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }

        [Test(Description = "Logout")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Normal)]
        [AllureOwner("Olga Naumik")]
        [AllureSubSuite("Logout")]
        public void VerifyLogout()
        {
            Login login = new Login(driver);
            login.LoginAs(username, pw);
            login.Logout();
            Thread.Sleep(4000);
            Assert.AreEqual(undefined, login.LogoutResult.Text, "Expected result is not displayed");
        }
    }
}