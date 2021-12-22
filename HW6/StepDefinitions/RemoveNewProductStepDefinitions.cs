using System;
using TechTalk.SpecFlow;

namespace HW6
{
    [Binding]
    public class RemoveNewProductStepDefinitions
    {
        private IWebDriver driver;

        [Given(@"I'm logging")]
        public void GivenImLogging()
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

        [When(@"I go to products page and remove product")]
        public void WhenIGoToProductsPageAndRemoveProduct()
        {
            MenuPage menuPage = new MenuPage(driver);
            AllProductsPage productsPage = menuPage.GoToProducts();
            productsPage.Remove();
        }

        [Then(@"All right")]
        public void ThenAllRight()
        {
            driver.Quit();
        }
    }
}
