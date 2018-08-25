using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
using System.Threading;
using Yad2Jumper.browser;

namespace Yad2Jumper.pages
{
    public class PersonalPage
    {
        private ReadOnlyCollection<IWebElement> CategoriesPostsUrls
        {
            get
            {
                return Browser.WebDriverWait60Seconds.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("div.thumbnailBar_wrap a")));
            }
        }

        private ReadOnlyCollection<IWebElement> CategoryPosts
        {
            get
            {
                return Browser.WebDriverWait60Seconds.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("tr.item.item-color-1")));
            }
        }

        private ReadOnlyCollection<IWebElement> Frames
        {
            get
            {
                return Browser.WebDriverWait60Seconds.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//iframe[contains(@src, '//my.yad2.co.il')]")));
            }
        }

        private IWebElement JumpPostButton
        {
            get
            {
                return Browser.WebDriverWait60Seconds.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='details_area manage_area view']//span[@id='bounceRatingOrderBtn']")));
            }
        }

        private bool IsPostJumpButtonEnable()
        {
            return JumpPostButton.GetAttribute("data-viewcommandactive") == "1";
        }

        public void jumpPosts()
        {
            Thread.Sleep(3000);
            System.Console.WriteLine(Browser.Driver.Url);

            ReadOnlyCollection<IWebElement> urls = CategoriesPostsUrls;
            for (int i = 0; i < urls.Count; i++)
            {
                Browser.Driver.Navigate().GoToUrl(urls[i].GetAttribute("href"));
                ReadOnlyCollection<IWebElement> po = CategoryPosts;
                for (int j = 0; j < po.Count; j++)
                {
                    po[j].Click();
                    ReadOnlyCollection<IWebElement> frames = Frames;
                    Browser.Driver.SwitchTo().Frame(frames[0]);
                    Thread.Sleep(2000);


                    if (IsPostJumpButtonEnable())
                    { // In case jump post is available.
                        System.Console.WriteLine("Jump post button is enable, click jump post...");
                        JumpPostButton.Click();
                        Thread.Sleep(2000);
                        Browser.Driver.SwitchTo().DefaultContent();
                        po[j].Click();
                    }
                    else
                    { // In case jump post is not available.
                        Browser.Driver.SwitchTo().DefaultContent();
                        Thread.Sleep(2000);
                        po[j].Click();
                    }

                    Browser.Refresh();
                    po = CategoryPosts;
                }
            }
        }
    }
}
