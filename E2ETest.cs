using AngleSharp.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace UdemySeleniumCourse
{

    public class E2ETest
    {
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
        public void EndToEndFlow()
        {
            String [] expectedProducts = { "iphone X", "Blackberry" };

            var userNameField = driver.FindElement(By.Id("username"));
            userNameField.SendKeys("rahulshettyacademy");//filling username field
            
            //driver.FindElement(By.Name("password")).SendKeys("learning")
            var passwordField = driver.FindElement(By.Name("password"));
            passwordField.SendKeys("learning");//filling password field

            //driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            var checkBox = driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input"));
            checkBox.Click();//clicking agreement checkbox

            //driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
            var signInButton = driver.FindElement(By.XPath("//input[@value='Sign In']"));
            signInButton.Click();//sign in after entering username and password 

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(d => driver.FindElement(By.PartialLinkText("Checkout")).Displayed);
            var checkoutButton = driver.FindElement(By.PartialLinkText("Checkout"));//PartialLinkText allows you to locate an anchor (<a>) element whose text contains the specified substring

            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));

            foreach (IWebElement product in products)
            {
                if (expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    //click cart when if condition matches a value from expectedProducts array
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
                TestContext.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
            }

            checkoutButton.Click();//click checkout cart button top of page
        }

        [TearDown]

        public void TearDown()
        {
            driver.Dispose();
        }

    }

}

