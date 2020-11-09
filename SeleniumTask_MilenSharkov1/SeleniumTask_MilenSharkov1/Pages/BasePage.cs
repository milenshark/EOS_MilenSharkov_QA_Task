using OpenQA.Selenium;

namespace SeleniumTask_MilenSharkov1.Pages
{
    public abstract class BasePage
    {
        private static IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public static IWebDriver Driver => _driver;

        public string Url { get; protected set; }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(Url);
        }

    }
}
