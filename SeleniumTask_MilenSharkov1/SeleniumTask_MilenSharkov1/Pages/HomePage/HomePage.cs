using OpenQA.Selenium;

namespace SeleniumTask_MilenSharkov1.Pages.HomePage
{
    public partial class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            Url = "https://www.amazon.co.uk/";
        }
    }
}
