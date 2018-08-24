using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
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
            emaillAddressTextBox.SendKeys(emailAddress);

            Browser.Actions.MoveToElement(passwordTextBox);
            Browser.Actions.Click();
            Browser.Actions.SendKeys(password);
            Browser.Actions.Build().Perform();

            Browser.Actions.MoveToElement(loginButton);
            Browser.Actions.Click();
            Browser.Actions.Build().Perform();
        }

        public bool IsAt()
        {
            return Browser.Driver.Url.EndsWith("personalAreaIndex");
        }
    }
}
