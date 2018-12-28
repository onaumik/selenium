using NUnit.Framework;
using NUnit.Task130.pages;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace NUnit.Task130
{
    [TestFixture]
    public class Tests : TestBase
    {
        string username = "seleniumtests@tut.by";
        string pw = "123456789zxcvbn";
        string undefined = "Войти";
        string name = "Selenium Test";

        [Test(Description = "Login with valid credentials")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Normal)]
        [AllureOwner("Olga Naumik")]
        [AllureSubSuite("Login")]
        public void VerifyLogin()
        {
            Login login = new Login(driver);
            login.LoginAs(username, pw);
            Thread.Sleep(5000);
            Assert.AreEqual(name, login.LoginResult.Text, "Username is not displayed");
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
            Thread.Sleep(5000);
            Assert.AreEqual(undefined, login.LogoutResult.Text, "Username is not displayed");
        }
    }
}
