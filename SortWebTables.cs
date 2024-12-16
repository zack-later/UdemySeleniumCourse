using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Collections;

namespace UdemySeleniumCourse
{
    public class SortWebTables
    {
        IWebDriver driver;

        [SetUp]

        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }

        [Test]
        public void SortTable()
        {
            ArrayList a = new ArrayList();
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByText("20");

            //step 1 - get all veggie names into an arraylist
            IList<IWebElement> veggieList = driver.FindElements(By.XPath("//tr//td[1]"));

            foreach(IWebElement veggies in veggieList)
            {
                a.Add(veggies.Text);
            }

            //Step 2 - sort arraylist - A
            a.Sort();

            //step 3 - go and click column

            //step 4 - get all veggies name into arraylist B

            //arrayList A to B are equal

        }


        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}

