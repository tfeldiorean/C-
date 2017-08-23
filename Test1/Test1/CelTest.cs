using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Test1
{
    [TestFixture]
    public class CelTest
    {
        private IWebDriver driver;
        private HomePage home;
        private CategoryPage categoryPage;
        private ProductPage productPage;
        private CartPage cartPage;


        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            DriverManagementHelper.SetWait(ref driver, 30);
            home = new HomePage(driver);
            categoryPage = new CategoryPage(driver);
            productPage = new ProductPage(driver);
            cartPage = new CartPage(driver);

        }
        [TearDown]
        public void TearDown()
        {
        }
        [Test]
        public void FirstTest()
        {
            DriverManagementHelper.NavigateToUrl(driver,"http://www.cel.ro/");
            Assert.AreEqual("CEL.ro - CEL mai ieftin, CEL mai rapid.", home.GetPageTitle());

            Assert.IsTrue(home.IsLogoDisplayed());

            //title of page
            var containsMenu = home.SelectFromMenu(7, 2);
            Assert.IsTrue(home.GetPageTitle().Contains(containsMenu));

            //compare paths
            string[] listaLabel = { "CEL.ro", "Software", "Antivirus" };
            var list = categoryPage.GetLabelCategory();

            foreach (var item in list)
            {
                Assert.AreEqual(item, listaLabel[list.IndexOf(item)]);
            }

            //check if logo is displayed
            Assert.True(home.IsLogoDisplayed());

            //click on product
            categoryPage.clickOnProduct("Kaspersky Internet Security 2017 3PC 1An+3luni gratuite Licenta Noua Box");
            
            //close Popup
           categoryPage.close();
            
            
            //verify if the page title is the same with the product title
            Assert.AreEqual(productPage.GetPageTitle(), home.GetPageTitle());

            Thread.Sleep(2000);
            //addToCart
            productPage.addtoCart();

            Thread.Sleep(1000);
            //details cart
            productPage.detailsCart();

            //check if CartPage contains "continut Cos"
            Assert.AreEqual("Continut cos", home.GetPageTitle());

            //modifyQuantity
            cartPage.modify("3");

            //Thread.Sleep(2000);
            //check if price equals quantity
            cartPage.clickUnitPrice();

            Thread.Sleep(3000);

            cartPage.getQuantity();
            int calculateTotalPrice = cartPage.getQuantity() * cartPage.getUnitPrice();
            int totalPrice = cartPage.getTotalPrice();

            Assert.AreEqual(calculateTotalPrice, totalPrice);
            Console.WriteLine("total price is: " + totalPrice);
        }
    }
}
