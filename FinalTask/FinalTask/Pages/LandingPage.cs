using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FinalTask.Pages
{
    public class LandingPage
    {
        private WebDriver driver;
        public LandingPage(WebDriver driver) { this.driver = driver; }
        IWebElement LnkToLogin => driver.FindElement(By.ClassName("login"));
        IWebElement FieldEmail => driver.FindElement(By.Id("email_create"));
        IWebElement BtnCreate => driver.FindElement(By.Id("SubmitCreate"));
        IWebElement EmailField => driver.FindElement(By.Id("email"));
        IWebElement PasswordField => driver.FindElement(By.Id("passwd"));
        IWebElement SignInBtn => driver.FindElement(By.Id("SubmitLogin"));

        public void InitiateAccountCreation()
        {
            LnkToLogin.Click();
            FieldEmail.Click();
            FieldEmail.SendKeys("temp@test.test");
            BtnCreate.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public void LoginToAccount()
        {
            LnkToLogin.Click();
            EmailField.Click();
            EmailField.SendKeys("werwewerw@erte.ert");
            PasswordField.Click();
            PasswordField.SendKeys("11111");
            SignInBtn.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }
    }
}

