using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
                
        }
        [FindsBy(How = How.ClassName, Using = "niv1")]
        private IList<IWebElement> menu;


        public string SelectFromMenu(int indexMenu, int indexSubMenu)
        {
            IWebElement elementMenu = menu[indexMenu];
            Actions action = new Actions(_driver);
            action.MoveToElement(menu[indexMenu]).Build().Perform();
            return SelectFromSubMenu(elementMenu, indexSubMenu);

        }
        public string SelectFromSubMenu(IWebElement elementMenu, int indexSubMenu)
        {

            var subMenu = elementMenu.FindElements(By.ClassName("aa"));
            String text = subMenu[indexSubMenu].Text;
            subMenu[indexSubMenu].Click();

            return text;
        }
    }
}
