using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumDemoProject
{
    [TestFixture]
    public class DemoTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestOne()
        {
            var url = "http://demo.guru99.com/test/ajax.html";

            _driver.Navigate().GoToUrl(url);

            var yesRadioButton = _driver.FindElement(By.Id("yes"));

            var noRadiobutton = _driver.FindElement(By.Id("no"));

            var checkButton = _driver.FindElement(By.Id("buttoncheck"));

            yesRadioButton.Click();
            Thread.Sleep(1500);

            checkButton.Click();
            Thread.Sleep(1500);

            var validationText = _driver.FindElement(By.ClassName("radiobutton")).Text;

            Assert.AreEqual("Radio button is checked and it's value is Yes", validationText);

            noRadiobutton.Click();
            Thread.Sleep(1500);

            checkButton.Click();
            Thread.Sleep(1500);

            validationText = _driver.FindElement(By.ClassName("radiobutton")).Text;

            Assert.AreEqual("Radio button is checked and it's value is No", validationText);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}
