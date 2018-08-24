using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yad2Jumper.browser;
using Yad2Jumper.pages;

namespace Yad2Jumper.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void SetUp()
        {
            Pages.HomePage().GoTo(BrowserType.Chrome);
        }

        [TestCleanup]
        public void TearDown()
        {
            Browser.StopBrowser();
        }


        [TestMethod]
        public void TestMethod1()
        {                        
            Pages.HomePage().LogIn("falukky@gmail.com", "Welcome99!");
            Assert.IsTrue(Pages.HomePage().IsAt());
        }
    }
}
