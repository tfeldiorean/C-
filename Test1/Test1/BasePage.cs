using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class BasePage
    {
        protected IWebDriver _driver;
        [FindsBy(How = How.XPath, Using = "//a[@id='logo_head']/img")]
        private IWebElement logo;

        public BasePage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //logo
        public bool IsLogoDisplayed()
        {
            return logo.Displayed;
        }

        public string GetPageTitle()
        {
            return _driver.Title;
        }
    }
}
