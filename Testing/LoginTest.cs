using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Testing
{
    public class LoginTest
    {
        private IWebDriver? driver;
        private WebDriverWait? wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2); // për elementët e thjeshtë
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // pritje e qartë për redirect ose DOM
        }

        [Test]
        public void Login_WithValidCredentials_ShouldSucceed()
        {
            driver!.Navigate().GoToUrl("http://localhost:3000/login");

           
            wait!.Until(driver => driver.FindElement(By.Id("email")));

            var emailInput = driver.FindElement(By.Id("email"));
            emailInput.SendKeys("loriku123321@gmail.com");

            var passwordInput = driver.FindElement(By.Id("password"));
            passwordInput.SendKeys("loriku2004");

            var loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));
            loginButton.Click();

           
            wait.Until(driver => driver.Url.Contains("/dashboard"));

            Assert.IsTrue(driver.Url.Contains("/dashboard"), "Login failed or redirect did not happen");
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
