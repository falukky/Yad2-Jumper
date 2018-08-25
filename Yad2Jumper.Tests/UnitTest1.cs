using NUnit.Framework;
using System;
using Yad2Jumper.browser;
using Yad2Jumper.helpers;
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
        }

        [TearDown]
        public void TearDown()
        {
            Browser.StopBrowser();
        }


        [Test]
        public void TestMethod1()
        {
            Pages.HomePage().LogIn(Environment.GetEnvironmentVariable("emailaddress"), Environment.GetEnvironmentVariable("password"));
            Assert.IsTrue(Pages.HomePage().IsAt());
            Pages.PersonalPage().jumpPosts();
        }
    }
}
