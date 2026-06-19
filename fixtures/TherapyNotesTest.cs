using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TherapyNotesUITests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                driver?.Quit();
            }
            finally
            {
                (driver as System.IDisposable)?.Dispose();
                driver = null;
            }
        }

        [Test]
        public void LoginToTherapyNotes()
        {
            driver.Navigate().GoToUrl("https://www.therapynotes.com");
            System.Threading.Thread.Sleep(2000);

            var loginLink = driver.FindElement(By.LinkText("Log In"));
            loginLink.Click();

            System.Threading.Thread.Sleep(2000);

            var practiceCode = driver.FindElement(By.Id("PracticeCode"));
            var buttonContinue = driver.FindElement(By.Id("Continue__ContinueButton"));
            practiceCode.SendKeys("QAInterviewPractice");
            buttonContinue.Click();
            System.Threading.Thread.Sleep(2000);

            var usernameField = driver.FindElement(By.Id("Login__UsernameField"));
            var passwordField = driver.FindElement(By.Id("Login__Password"));

            usernameField.Clear();
            usernameField.SendKeys("TestUser");
            passwordField.SendKeys("HorshamPA19044@@");

            var loginButton = driver.FindElement(By.Id("Login__LogInButton"));
            loginButton.Click();

            System.Threading.Thread.Sleep(2000);

            var welcomeHeader = driver.FindElement(By.Id("FrontpageHeaderText"));
            Assert.IsTrue(welcomeHeader.Text.Contains("Welcome"), "Login should be successful and welcome message should be displayed.");
        }
    }
}