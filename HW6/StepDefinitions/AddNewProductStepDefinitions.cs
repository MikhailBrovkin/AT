using System;
using TechTalk.SpecFlow;

namespace HW6
{
    [Binding]
    public class AddNewProductStepDefinitions
    {
        private IWebDriver driver;

        [Given(@"I'm logging in")]
        public void GivenImLoggingIn()
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

        [When(@"I go to products page and add product")]
        public void WhenIGoToProductsPageAndAddProduct()
        {
            MenuPage menuPage = new MenuPage(driver);
            AllProductsPage productsPage = menuPage.GoToProducts();
            ProductLogic productPage = productsPage.AddNewProduct();

            Product newProduct = ProductGenerator.GenerateProduct();
            productPage.CreateNewProduct(newProduct);
        }

        [Then(@"All good")]
        public void ThenAllGood()
        {
            Assert.AreEqual(driver.FindElement(By.XPath("//h2")).Text, "All Products");
            driver.Quit();
        }
    }
}
