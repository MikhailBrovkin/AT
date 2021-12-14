using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace HW3
{
    public class TestCases
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public bool IsElementNotPresent(By locator)
        {
            try
            {
                driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                return true;
            }
            return false;
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://localhost:5000";

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Timeout = TimeSpan.FromSeconds(1);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
           
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='Name']"))).SendKeys("user");
            
            driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("user");
            driver.FindElement(By.XPath("//input[contains(@class,'btn')]")).Click();

            Assert.AreEqual(driver.FindElement(By.XPath("//h2")).Text, "Home page");
        }

        [Test]
        public void AddProduct()
        {
            driver.FindElement(By.XPath("//a[@href = '/Product']")).Click();
            driver.FindElement(By.XPath("//a[contains(@class,'btn')]")).Click();

            driver.FindElement(By.XPath("//*[@id='ProductName']")).SendKeys("BrovaTheOctopus");
            new SelectElement(driver.FindElement(By.XPath("//*[@id='CategoryId']"))).SelectByText("Seafood");
            new SelectElement(driver.FindElement(By.XPath("//*[@id='SupplierId']"))).SelectByText("Heli Su?waren GmbH & Co. KG");
            driver.FindElement(By.XPath("//*[@id='UnitPrice']")).SendKeys("60");
            driver.FindElement(By.XPath("//*[@id='QuantityPerUnit']")).SendKeys("1");
            driver.FindElement(By.XPath("//*[@id='UnitsInStock']")).SendKeys("1");
            driver.FindElement(By.XPath("//*[@id='UnitsOnOrder']")).SendKeys("1");
            driver.FindElement(By.XPath("//*[@id='ReorderLevel']")).SendKeys("1");

            driver.FindElement(By.XPath("//input[contains(@class,'btn')]")).Click();

            Assert.IsTrue(IsElementNotPresent(By.XPath("//*[h2='Product editing']")));
        }

        [Test]
        public void CheckProduct()
        {
            driver.FindElement(By.XPath("//a[@href = '/Product']")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'BrovaTheOctopus')]")).Click();

            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='ProductName']")).GetAttribute("value"), "BrovaTheOctopus");
            Assert.AreEqual(driver.FindElement(By.XPath("//option[@selected='selected'][contains(text(),'Seafood')]")).Text, "Seafood");
            Assert.AreEqual(driver.FindElement(By.XPath("//option[@selected='selected'][contains(text(),'Heli Su?waren GmbH & Co. KG')]")).Text, "Heli Su?waren GmbH & Co. KG");
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='UnitPrice']")).GetAttribute("value"), "60,0000");
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='QuantityPerUnit']")).GetAttribute("value"), "1");
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='UnitsInStock']")).GetAttribute("value"), "1");
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='UnitsOnOrder']")).GetAttribute("value"), "1");
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='ReorderLevel']")).GetAttribute("value"), "1");            
        }

        [Test]
        public void RemoveProduct()
        {
            driver.FindElement(By.XPath("//a[@href = '/Product']")).Click();
            driver.FindElement(By.XPath("(//*[@data-remove])[78]")).Click();

            driver.SwitchTo().Alert().Accept();
        }

        [TearDown]
        public void TearDown()
        {
            driver.FindElement(By.XPath("//a[contains(@href,'Logout')]")).Click();

            Assert.AreEqual(driver.FindElement(By.XPath("//h2")).Text, "Login");

            driver.Quit();
        }
    }
}