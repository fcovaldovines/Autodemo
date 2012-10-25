//using System;
//using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Homepage001
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://eagl-qa.spe.sony.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheHomepage001Test()
        {
            driver.Navigate().GoToUrl(baseURL + "/Home");
            driver.FindElement(By.CssSelector("input[type=\"text\"]")).Click();
            driver.FindElement(By.CssSelector("span")).Click();
            driver.FindElement(By.CssSelector("input[type=\"text\"]")).Clear();
            driver.FindElement(By.CssSelector("input[type=\"text\"]")).SendKeys("photo");
            driver.FindElement(By.CssSelector("img.search-button-image")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.CssSelector("a > img")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.CssSelector("li.find > a > span")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.LinkText("Photo")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.CssSelector("input[type=\"text\"]")).Click();
            driver.FindElement(By.CssSelector("input[type=\"text\"]")).Clear();
            driver.FindElement(By.CssSelector("input[type=\"text\"]")).SendKeys("poster");
            driver.FindElement(By.CssSelector("img[title=\"Search\"]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.CssSelector("a > img")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.LinkText("poster")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.CssSelector("span")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
