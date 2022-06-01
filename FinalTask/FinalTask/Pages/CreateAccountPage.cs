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
    public class CreateAccountPage
    {
        private WebDriver driver;
        public CreateAccountPage(WebDriver driver) { this.driver = driver; }

        IWebElement FirstNameField => driver.FindElement(By.Id("customer_firstname"));
        IWebElement LastNameField => driver.FindElement(By.Id("customer_lastname"));
        IWebElement PasswordField => driver.FindElement(By.Id("passwd"));
        IWebElement AdressField => driver.FindElement(By.Id("address1"));
        IWebElement CityField => driver.FindElement(By.Id("city"));
        IWebElement ZipField => driver.FindElement(By.Id("postcode"));
        IWebElement PhoneField => driver.FindElement(By.Id("phone_mobile"));
        IWebElement AdditionalAdressField => driver.FindElement(By.Id("alias"));
        IWebElement SubmitBtn => driver.FindElement(By.Id("submitAccount"));

        public void SelectState()
        {
            var optionsStates = new SelectElement(driver.FindElement(By.Id("id_state")));
            optionsStates.SelectByText("Alabama");
        }
        public void RegisterUser()
        {
            FirstNameField.Click();
            FirstNameField.SendKeys("Oksana");
            LastNameField.Click();
            LastNameField.SendKeys("Levkovskaya");
            PasswordField.Click();
            PasswordField.SendKeys("testpassword");
            AdressField.Click();
            AdressField.SendKeys("Test Adress");
            CityField.Click();
            CityField.SendKeys("Los Angeles");
            ZipField.Click();
            ZipField.SendKeys("12345");
            PhoneField.Click();
            PhoneField.SendKeys("1234567890");
            AdditionalAdressField.Click();
            AdditionalAdressField.SendKeys("Additional Test Adress");
            SubmitBtn.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        
    }
}
