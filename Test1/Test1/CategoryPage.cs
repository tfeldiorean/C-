using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class CategoryPage : BasePage
    {
        public CategoryPage(IWebDriver driver) : base(driver)
        {

        }
        [FindsBy(How = How.XPath, Using = "//div[@id='mesaj_casuta']/div/div[1]/div/a[@onclick]")]
        private IWebElement closeOfPopUp;
        public void close()
        {
            closeOfPopUp.Click();
        }

        [FindsBy(How = How.ClassName, Using = "breadCrumb")]
        private IWebElement lableCategoryPath;

        public List<string> GetLabelCategory()
        {
            var list = new List<string>();
            foreach (var item in lableCategoryPath.FindElements(By.TagName("b")))
            {
                list.Add(item.Text.Trim());
            }
            return list;
        }

        [FindsBy(How = How.XPath, Using = "//div[@id='listProducts']/div[1]/div[2]/div[5]/div[8]/div/div[4]/h4/a[@class]")]
        private IList<IWebElement> titlesOfProducts;

        public void clickOnProduct(String title)
        {
            foreach(IWebElement item in titlesOfProducts)
            {
                string itemTitle = item.Text;
                if (itemTitle.Equals(title))
                {
                    item.Click();
                    break;
                }

            }
        }

    }
}
