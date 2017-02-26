using System;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Test
{
    [TestFixture]
    public class Foo
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();

            baseURL = "http://www.calculatorsoup.com/";
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






        [TestCase(12, 479001600)]
        [TestCase(2, 2)]
        [TestCase(3, 6)]
        public void FactorialTest(int input, int output)
        {

            driver.Navigate().GoToUrl(baseURL + "/calculators/discretemathematics/factorials.php");
            driver.FindElement(By.Id("n")).Clear();
            driver.FindElement(By.Id("n")).SendKeys(input.ToString());
            driver.FindElement(By.CssSelector("input.btn")).Click();
            Thread.Sleep(2000);
            var expected = $"= {output}";
            Assert.AreEqual(expected , driver.FindElement(By.CssSelector("div.cell.alignCenter")).Text);


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

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
