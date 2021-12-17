using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;

namespace HW4.Pages
{
    class CreateProductPage : AbstractPage
    {
        public CreateProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='ProductName']")]
        private IWebElement ProductName;

        [FindsBy(How = How.XPath, Using = "//*[@id='CategoryId']")]
        private IWebElement CategoryId;

        [FindsBy(How = How.XPath, Using = "//*[@id='SupplierId']")]
        private IWebElement SupplierId;

        [FindsBy(How = How.XPath, Using = "//*[@id='UnitPrice']")]
        private IWebElement UnitPrice;

        [FindsBy(How = How.XPath, Using = "//*[@id='QuantityPerUnit']")]
        private IWebElement QuantityPerUnit;

        [FindsBy(How = How.XPath, Using = "//*[@id='UnitsInStock']")]
        private IWebElement UnitsInStock;

        [FindsBy(How = How.XPath, Using = "//*[@id='UnitsOnOrder']")]
        private IWebElement UnitsOnOrder;

        [FindsBy(How = How.XPath, Using = "//*[@id='ReorderLevel']")]
        private IWebElement ReorderLevel;

        [FindsBy(How = How.XPath, Using = "//input[contains(@class,'btn')]")]
        private IWebElement SendBtn;

        public void Create()
        {
            new SelectElement(CategoryId).SelectByText("Seafood");
            new SelectElement(SupplierId).SelectByText("Heli Su?waren GmbH & Co. KG");
            IAction action = new Actions(driver)
                .Click(ProductName)
                .SendKeys("BrovaTheOctopus")
                .Click(UnitPrice)
                .SendKeys("60")
                .Click(QuantityPerUnit)
                .SendKeys("1")
                .Click(UnitsInStock)
                .SendKeys("1")
                .Click(UnitsOnOrder)
                .SendKeys("1")
                .Click(ReorderLevel)
                .SendKeys("1")
                .Click(SendBtn);
            action.Perform();
        }
    }
}
