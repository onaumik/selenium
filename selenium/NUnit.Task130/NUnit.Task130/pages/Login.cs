using System;
using OpenQA.Selenium;

namespace NUnit.Task130.pages
{
    class Login
    {
        private By authorizeLink = By.CssSelector("a[data-target-popup='authorize-form']");
        private By username = By.CssSelector("input[name='login']");
        private By password = By.CssSelector("input[name='password']");
        private By btnEnter = By.XPath("//input[@value='Войти']");
        private By name = By.ClassName("uname");
        private By btnGoOut = By.XPath("//a[@class='button wide auth__reg']");

        private IWebDriver driver;

        public Login(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickOnAuthLink()
        {
            driver.FindElement(authorizeLink).Click();
        }

        public void TypeUsername(string uname)
        {
            driver.FindElement(username).SendKeys(uname);
        }

        public void TypePW(String pw)
        {
            driver.FindElement(password).SendKeys(pw);
        }

        public void ClickBtnEnter()
        {
            driver.FindElement(btnEnter).Submit();
        }

        public void ClickOnName()
        {
            driver.FindElement(name).Click();
        }

        public void ClickBtnGoOut()
        {
            driver.FindElement(btnGoOut).Click();
        }

        public void LoginAs(String uname, String password)
        {
            this.ClickOnAuthLink();
            this.TypeUsername(uname);
            this.TypePW(password);
            this.ClickBtnEnter();
        }

        //public void MakeScreenshot(IWebDriver driver)
        //{
        //    if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
        //    {
        //        Screenshot s = ((ITakesScreenshot)driver).GetScreenshot();
        //        byte[] image = s.AsByteArray;
        //        AllureLifecycle.Instance.AddAttachment("Screenshot", AllureLifecycle.AttachFormat.ImagePng, image);
        //    }

        //}

        public void Logout()
        {
            this.ClickOnAuthLink();
            this.ClickBtnGoOut();
        }

        public IWebElement LoginResult
        {
            get { return driver.FindElement(By.ClassName("uname")); }
        }

        public IWebElement LogoutResult
        {
            get { return driver.FindElement(By.LinkText("Войти")); }
        }
    }
}
