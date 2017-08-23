using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver)
        {

        }
        [FindsBy(How = How.XPath, Using = "//d[@id='mesaj_casuta']/div/div[1]/div/a")]
        private IWebElement closeOfPopUp;
        public void Close()
        {
            closeOfPopUp.Click();
        }


        [FindsBy(How = How.XPath, Using = "//div[@class='breadCrumb']//a[@class='product_link']/b")]
        private IWebElement titleOfProduct;

        public string getTitle()
        {
            return titleOfProduct.Text;
            
        }
          //add to cart
        [FindsBy(How = How.XPath, Using = "//div[@class]/form/button[@class='btn btn-buy']")]
        private IWebElement addToCartButton;

        public void addtoCart()
        {
            addToCartButton.Click();
        }

        //detalii cos
        [FindsBy(How = How.XPath, Using = "//div[@id]//a[@id='btngocart']")]
        private IWebElement detailsCartButton;

        public void detailsCart()
        {
              detailsCartButton.Click();
        }

    }
}
