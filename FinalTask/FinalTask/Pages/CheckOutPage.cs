using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace FinalTask.Pages
{
    public class CheckOutPage
    {
        private WebDriver driver;
        public CheckOutPage(WebDriver driver) { this.driver = driver; }

        IWebElement FirstItemInCart => driver.FindElement(By.Id("product_3_13_0_700078"));
        IWebElement SecondItemInCart => driver.FindElement(By.Id("product_4_16_0_700078"));
        IWebElement ThirdItemInCart => driver.FindElement(By.Id("product_5_19_0_700078"));
        IWebElement TotalPrice => driver.FindElement(By.Id("total_price"));
    }
}
