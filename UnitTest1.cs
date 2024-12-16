using NUnit.Framework;

namespace UdemySeleniumCourse.SeleniumProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Setup method execution");
        }

        //[Test]

        public void Test1()
        {
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}