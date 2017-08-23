using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class DriverManagementHelper
    {
        static public void NavigateToUrl(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Size = new Size(1500, 800);
        }
        static public void SetWait(ref IWebDriver driver, int wait)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(wait));
        }
    }
}
