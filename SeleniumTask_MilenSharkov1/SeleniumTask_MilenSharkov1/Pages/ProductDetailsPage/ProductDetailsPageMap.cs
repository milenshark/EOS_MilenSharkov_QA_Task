using OpenQA.Selenium;

namespace SeleniumTask_MilenSharkov1.Pages.ProductDetailsPage
{
    public partial class ProductDetailsPage
    {
        public IWebElement SelectedBookTitle => Driver.FindElement(By.Id("productTitle"));
        public IWebElement SelectedBookSubtitle => Driver.FindElement(By.Id("productSubtitle"));
        public IWebElement SelectedBookPrice => Driver.FindElement(By.Id("buyNewSection"));
        public IWebElement AddToBasketButton => Driver.FindElement(By.Id("submit.add-to-cart"));
    }
}
