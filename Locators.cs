using AngleSharp.Html.Dom;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Runtime.InteropServices;
using WebDriverManager.DriverConfigs.Impl;

namespace UdemySeleniumCourse.SeleniumProject
{
    public class Locators
    {
        // xpath, css, id, classname, name, tagname, linktext
        // css selector & xpath 
        // tagname[attribute = 'value']

        IWebDriver driver;

        [SetUp]

        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]

        public void LocatorIdentification()
        {
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("username")).Clear();

            Thread.Sleep(5000);
            driver.FindElement(By.Name("password")).SendKeys("123456");
            driver.FindElement(By.Name("password")).Clear();
            //driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();

            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
            Thread.Sleep(3000);
            string errorMessage = driver.FindElement(By.ClassName("alert-danger")).Text;

            TestContext.Progress.WriteLine(errorMessage);

            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            string hrefAttribute = link.GetAttribute("href");
            string expectedUrl = "https://rahulshettyacademy.com/#/documents-request";

            Assert.That(expectedUrl, Is.EqualTo("https://rahulshettyacademy.com/#/documents-request"));

            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));

            //selecting options from static dropdowns
            var s = new SelectElement(dropdown);
            s.SelectByText("Teacher");
            s.SelectByValue("consult");
            s.SelectByIndex(1); //select first option in drop down

            //selecting radio buttons
            IList<IWebElement> radioB = driver.FindElements(By.CssSelector("input[type='radio']"));

            foreach (IWebElement radioButtons in radioB)
            {
                if (radioButtons.GetAttribute("value").Equals("user"))
                {
                    radioButtons.Click(); 
                }
            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
           
            wait.Until(d => driver.FindElement(By.Id("okayBtn")).Displayed);
            driver.FindElement(By.Id("okayBtn")).Click(); 

        }

        [TearDown]

        public void TearDown()
        {
            driver.Dispose();
        }
    }
}

