using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.Extensions;


namespace FinalTask.Pages
{
    public class DressesPage
    {
        private WebDriver driver;
        public DressesPage(WebDriver driver) { this.driver = driver; }

        IWebElement FirstDress => driver.FindElement(By.XPath("//img[@src = 'http://automationpractice.com/img/p/8/8-home_default.jpg']"));
        IWebElement AddToCartFirstElementBtn => driver.FindElement(By.XPath("//a[@data-id-product = '3']"));
        IWebElement SecondDress => driver.FindElement(By.XPath("//img[@src = 'http://automationpractice.com/img/p/1/0/10-home_default.jpg']"));
        IWebElement AddToCartSecondElementBtn => driver.FindElement(By.XPath("//a[@data-id-product = '4']"));
        IWebElement ThirdDress => driver.FindElement(By.XPath("//img[@src = 'http://automationpractice.com/img/p/1/2/12-home_default.jpg']"));
        IWebElement AddToCartThirdElementBtn => driver.FindElement(By.XPath("//a[@data-id-product = '5']"));
        IWebElement CloseConfirmationPopupBtn => driver.FindElement(By.ClassName("cross"));
        IWebElement CartBtn => driver.FindElement(By.XPath("//a[@href='http://automationpractice.com/index.php?controller=order']"));

        public void AddElementsToCart()
        {
            FirstDress.Click();
            AddToCartFirstElementBtn.Click();
            CloseConfirmationPopupBtn.Click();
            SecondDress.Click();
            AddToCartSecondElementBtn.Click();
            CloseConfirmationPopupBtn.Click();
            ThirdDress.Click();AddToCartThirdElementBtn.Click();
            CloseConfirmationPopupBtn.Click();
        }

        public void NavigatetoCartPage()
        {
            CartBtn.Click();
        }      
    }
}
