using System;
using TechTalk.SpecFlow;

namespace HW6
{
    [Binding]
    public class LogoutStepDefinitions
    {
        private IWebDriver driver;
        [Given(@"I connect to db")]
        public void GivenIConnectToDb()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://localhost:5000";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("user", "user");
            Assert.AreNotEqual(loginPage.GetNamePage(), "Login");
        }

        [When(@"I click logout")]
        public void WhenIClickLogout()
        {
            MenuPage menuPage = new MenuPage(driver);
            menuPage.Logout();
        }

        [Then(@"I disconnect from db")]
        public void ThenIDisconnectFromDb()
        {
            driver.Quit();
        }
    }
}
