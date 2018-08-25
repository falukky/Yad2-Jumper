using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using Yad2Jumper.browser;

namespace Yad2Jumper.pages
{
    public class HomePage
    {
        private string url = "http://www.yad2.co.il/";

        public void GoTo(BrowserType browserType)
        {
            Browser.StartBrowser(browserType, url);
        }

        private IWebElement emaillAddressTextBox
        {
            get
            {
                return Browser.WebDriverWait60Seconds.Until(ExpectedConditions.ElementIsVisible(By.Id("login_email")));
            }
        }

        private IWebElement passwordTextBox
        {
            get
            {
                return Browser.WebDriverWait60Seconds.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("tr[id=mockpass] input")));
            }
        }

        private IWebElement loginButton
        {
            get
            {
                return Browser.WebDriverWait60Seconds.Until(ExpectedConditions.ElementToBeClickable(By.Name("login")));
            }
        }

        public void LogIn(string emailAddress, string password)
        {
            System.Console.WriteLine("start to insert email");
            Thread.Sleep(1000);
            emaillAddressTextBox.SendKeys(emailAddress);
            System.Console.WriteLine("finish to insert email");

            Thread.Sleep(1000);
            System.Console.WriteLine("start to insert password");
            Browser.Actions.MoveToElement(passwordTextBox);
            Browser.Actions.Click();
            Browser.Actions.SendKeys(password);
            Browser.Actions.Build().Perform();
            System.Console.WriteLine("finish to insert password");

            Thread.Sleep(1000);
            System.Console.WriteLine("start to click login");
            Browser.Actions.MoveToElement(loginButton);
            Browser.Actions.Click();
            Browser.Actions.Build().Perform();
            System.Console.WriteLine("finish to click login");

            System.Console.WriteLine("wait 5 seconds");
            Thread.Sleep(5000);
            System.Console.WriteLine("CURRENT URL: " + Browser.Driver.Url);
        }

        public bool IsAt()
        {
            return Browser.Driver.Url.EndsWith("personalAreaIndex");
        }
    }
}
