using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class CartPage : BasePage
    { public CartPage(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.XPath, Using = "//input[@name='cart_quantity[]']")]
        private IWebElement modifyQuantity;

        [FindsBy(How = How.XPath, Using = "//td[@id='produse_cos']/table/tbody/tr[2]/td[4]/strong")]
        private IWebElement singlePrice;

        [FindsBy(How = How.XPath, Using = "//td[@id='produse_cos']/table/tbody/tr[2]/td[5]/strong")]
        private IWebElement totalPrice;

        //modify the quantity
        public void modify(string amount)
        {
            modifyQuantity.SendKeys(Keys.Backspace);
            modifyQuantity.SendKeys(Keys.Backspace);
            modifyQuantity.SendKeys(amount);

        }

        public void clickUnitPrice()
        {

            singlePrice.Click();
        }


        public int getQuantity()
        {
            string quantityNumber = modifyQuantity.GetAttribute("value");
            int number = int.Parse(quantityNumber);
            return number;


        }

        public int getUnitPrice()
        {
            string unitPrice = singlePrice.Text;
            int price = int.Parse(unitPrice);
            return price;

        }

        public int getTotalPrice()
        {

            string priceTotal = totalPrice.Text;
            int priceT = int.Parse(priceTotal);
            return priceT;

        }
    }
}
