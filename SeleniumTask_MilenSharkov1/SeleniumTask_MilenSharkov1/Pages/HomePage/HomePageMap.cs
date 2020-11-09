using OpenQA.Selenium;

namespace SeleniumTask_MilenSharkov1.Pages.HomePage
{
    public partial class HomePage
    {
        public IWebElement SearchField => Driver.FindElement(By.Id("twotabsearchtextbox"));

        public IWebElement AcceptCookiesButton => Driver.FindElement(By.Id("sp-cc-accept"));

        public IWebElement SearchButton => Driver.FindElement(By.ClassName("nav-search-submit-text"));

        public IWebElement HomePageLogo => Driver.FindElement(By.Id("nav-logo"));

        public IWebElement CategoryDropDownButton => Driver.FindElement(By.Id("searchDropdownBox"));

        public IWebElement BooksCategoryButton => Driver.FindElement(By.XPath("//*[@id=\"searchDropdownBox\"]/option[10]"));


    }
}
