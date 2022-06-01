using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;


namespace FinalTask.Pages
{
    public class MyAccountPage
    {
        private WebDriver driver;
        public MyAccountPage(WebDriver driver) { this.driver = driver; }

        IWebElement WishlistBtn => driver.FindElement(By.ClassName("icon-heart"));
        IWebElement DressesButton => driver.FindElement(By.XPath("//ul[@class= 'sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li[2]/a"));



        public void NavigateToWishListPage()
        {
            WishlistBtn.Click();
        }

        public void NavigateToDressesPage()
        {
            DressesButton.Click();
        }
    }
}
