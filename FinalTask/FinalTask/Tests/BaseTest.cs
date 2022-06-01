using Allure.Commons;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;

namespace FinalTask.Tests
{
    public class BaseTest
    {
        protected IWebDriver? driver;

        [OneTimeSetUp]
        public void ClearResultsDir()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [TearDown]
        public void TearDown()
        {
            CreateScreenshot();

            if (driver != null)
            {
                driver.Quit();
            }
        }

        private void CreateScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string path = Path.Combine(Environment.CurrentDirectory, "Screenshoot.jpg");
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Jpeg);
            }
        }
    }
}