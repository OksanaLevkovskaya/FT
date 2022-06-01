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
    public class ShopItemPage
    {
        private WebDriver driver;
        public ShopItemPage(WebDriver driver) { this.driver = driver; }

        IWebElement AddToWishlistBtn => driver.FindElement(By.Id("wishlist_button"));
        IWebElement CloseFancyBtn => driver.FindElement(By.XPath("//a[contains(@class,'fancybox-item')]"));
        IWebElement AccountBtn => driver.FindElement(By.ClassName("account"));

        public void AddToWishList()
        {
            AddToWishlistBtn.Click();
            CloseFancyBtn?.Click();   
        }

        public void NavigateToAccountPage()
        {
            AccountBtn.Click();
        }
    }
}
