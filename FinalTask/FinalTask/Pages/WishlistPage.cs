using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace FinalTask.Pages
{
    public class WishlistPage
    {
        private WebDriver driver;
        public WishlistPage(WebDriver driver) { this.driver = driver; }

        IWebElement WishListNameField => driver.FindElement(By.Id("name"));
        IWebElement SaveWishlistBtn => driver.FindElement(By.Id("submitWishlist"));
        IWebElement DressItem => driver.FindElement(By.XPath("//a[@class = 'products-block-image content_img clearfix']"));
        public void CreateWishlist()
        {
            WishListNameField.Click();
            WishListNameField.SendKeys("Test WishList");
            SaveWishlistBtn.Click();
        }

        public void NavigateToShopItemPage()
        {
            DressItem.Click();
        }
    }
}
