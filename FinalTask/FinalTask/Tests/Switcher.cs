using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace FinalTask.Tests
{
    public class Switcher
    {
        public enum TypeOfDriver
        {
            Chrome,
            Firefox,
            SauceLabs
        }
        public static IWebDriver CreateDriver(TypeOfDriver typeOfDriver)
        {
            switch (typeOfDriver)
            {
                case TypeOfDriver.Chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    return new ChromeDriver();

                case TypeOfDriver.Firefox:
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    return new FirefoxDriver();

                case TypeOfDriver.SauceLabs:
                    var browserOptions = new ChromeOptions();
                    browserOptions.PlatformName = "Windows 10";
                    browserOptions.BrowserVersion = "latest";

                    var sauceOptions = new Dictionary<string, object>();
                    sauceOptions.Add("name", TestContext.CurrentContext.TestDirectory);
                    sauceOptions.Add("username", Environment.GetEnvironmentVariable("SAUCE_USERNAME"));
                    sauceOptions.Add("accessKey", Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY"));
                    browserOptions.AddAdditionalOption("sauce:options", sauceOptions);
                    var sauceUrl = new Uri("https://api.eu-central-1.saucelabs.com/");

                    return new RemoteWebDriver(sauceUrl, browserOptions);

                default:
                    throw new Exception("Incorrect Browser Name");
            }
        }
    }
}
