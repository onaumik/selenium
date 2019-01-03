using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Task130.pages;
using Allure.NUnit.Attributes;
using Allure.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace NUnit.Task130
{
    [TestFixture]
    [Parallelizable]
    public class LoginCheck : AllureReport
    {
        protected RemoteWebDriver driver;
        string username = "seleniumtests@tut.by";
        string pw = "123456789zxcvbn";
        string name = "Selenium Test";

        [SetUp]
        public void OneTimeSetUp()
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

        [Test(Description = "Login with valid credentials")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Normal)]
        [AllureOwner("Olga Naumik")]
        [AllureSubSuite("Login")]
        public void VerifyLogin()
        {
            Login login = new Login(driver);
            login.LoginAs(username, pw);
            Thread.Sleep(5000);
            Assert.AreEqual(name, login.LoginResult.Text, "Expected result is not displayed");
        }
    }
}