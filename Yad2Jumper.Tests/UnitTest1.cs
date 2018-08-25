using NUnit.Framework;
using System;
using Yad2Jumper.browser;
using Yad2Jumper.pages;

namespace Yad2Jumper.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [SetUp]
        public void SetUp()
        {
            Pages.HomePage().GoTo(BrowserType.Chrome);
            Console.WriteLine("START TESTS");
        }

        [TearDown]
        public void TearDown()
        {
            Browser.StopBrowser();
        }


        [Test]
        public void TestMethod1()
        {
            Console.WriteLine("TEST 1");
            Pages.HomePage().LogIn("falukky@gmail.com", "Welcome13!");
            //Assert.IsTrue(Pages.HomePage().IsAt());
            //Pages.PersonalPage().jumpPosts();
            Console.WriteLine("TEST 2");
        }
    }
}
