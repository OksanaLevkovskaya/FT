using NUnit.Framework;
using FinalTask.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using NUnit.Allure.Attributes;
using Allure.Commons;
using NUnit.Allure.Core;
using OpenQA.Selenium.Firefox;
using static FinalTask.Tests.Switcher;

namespace FinalTask.Tests
{

    [AllureNUnit]
    [AllureDisplayIgnored]
    public class Tests : BaseTest
    {
        private WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = (WebDriver)Switcher.CreateDriver(TypeOfDriver.Firefox);
            driver.Url = "http://automationpractice.com/index.php";
            driver.Manage().Window.Maximize();
        }

        [Test]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureDescription("Verify the ability to create an account")]
        public void AccountCreationTest()
        {
            var landingPage = new LandingPage(driver);
            var createAccountPage = new CreateAccountPage(driver);
            landingPage.InitiateAccountCreation();
            createAccountPage.SelectState();
            createAccountPage.RegisterUser();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            var accountPageIdentifier = driver.FindElement(By.ClassName("info-account"));
            Assert.IsTrue(accountPageIdentifier.Displayed, "Registration failed.");
            driver.Close();
        }

        [Test]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureDescription("Verify the ability to login in account")]
        public void LoginToAccount()
        {
            var landingPage = new LandingPage(driver);

            landingPage.LoginToAccount();

            var accountPageIdentifier = driver.FindElement(By.ClassName("info-account"));
            Assert.IsTrue(accountPageIdentifier.Displayed, "Login Failed");
            driver.Close();
        }

        [Test]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureDescription("Verify the ability to add to auto-created Wishlist")]
        public void AutocreateWishlist()
        {
            var landingPage = new LandingPage(driver);
            var myAccountPage = new MyAccountPage(driver);
            var shopItemPage = new ShopItemPage(driver);
            var wishlistPage = new WishlistPage(driver);

            landingPage.LoginToAccount();
            myAccountPage.NavigateToWishListPage();
            wishlistPage.NavigateToShopItemPage();
            shopItemPage.AddToWishList();
            shopItemPage.NavigateToAccountPage();
            myAccountPage.NavigateToWishListPage();

            var wishListExist = driver.FindElement(By.ClassName("first_item"));
            Assert.IsTrue(wishListExist.Displayed, "Wishlist Exists in the system.");
            driver.Close();
        }

        [Test]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureDescription("Verify the ability to add to your Wishlist")]
        public void AddItemToWishlist()
        {
            var landingPage = new LandingPage(driver);
            var myAccountPage = new MyAccountPage(driver);
            var wishlistPage = new WishlistPage(driver);
            var shopItemPage = new ShopItemPage(driver);

            landingPage.LoginToAccount();
            myAccountPage.NavigateToWishListPage();
            wishlistPage.CreateWishlist();
            wishlistPage.NavigateToShopItemPage();
            shopItemPage.AddToWishList();
            shopItemPage.NavigateToAccountPage();
            myAccountPage.NavigateToWishListPage();

            var wishListExist = driver.FindElement(By.ClassName("first_item"));
            Assert.IsTrue(wishListExist.Displayed, "Wishlist Exists in the system.");
            driver.Close();
        }

        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureDescription("Verify the ability to add to cart")]
        public void AddItemToCart()
        {
            var landingPage = new LandingPage(driver);
            var myAccountPage = new MyAccountPage(driver);
            var dressesPage = new DressesPage(driver);


            landingPage.LoginToAccount();
            myAccountPage.NavigateToDressesPage();
            dressesPage.AddElementsToCart();
            dressesPage.NavigatetoCartPage();

            var firstItemInCart = driver.FindElement(By.Id("product_3_13_0_700078"));
            Assert.IsTrue(firstItemInCart.Displayed, "First item is not in the cart.");
            var secondItemInCart = driver.FindElement(By.Id("product_4_16_0_700078"));
            Assert.IsTrue(firstItemInCart.Displayed, "Second item is not in the cart.");
            var thirdItemInCart = driver.FindElement(By.Id("product_5_19_0_700078"));
            Assert.IsTrue(firstItemInCart.Displayed, "Third item is not in the cart.");
            var actualtotalPrice = driver.FindElement(By.Id("total_price")).ToString;
            var expectedTotalPrice = "$107.97";
            Assert.AreEqual(expectedTotalPrice, actualtotalPrice, "Total Price is wrong.");
            driver.Close();
        }
    }
}
