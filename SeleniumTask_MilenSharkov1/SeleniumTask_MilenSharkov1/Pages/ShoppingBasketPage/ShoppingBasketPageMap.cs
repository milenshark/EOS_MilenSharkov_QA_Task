using OpenQA.Selenium;

namespace SeleniumTask_MilenSharkov1.Pages.ShoppingBasketPage
{
    public partial class ShoppingBasketPage
    {
        public IWebElement ShoppingBasketBookTitle => Driver.FindElement(By.XPath("/html/body/div[1]/div[4]/div/div[6]/div/div[2]/div[3]/form/div[2]/div[3]/div[4]/div/div[1]/div/div/div[2]/ul/li[1]/span/a/span[1]"));

        public IWebElement ShoppingBasketBookType => Driver.FindElement(By.XPath("//*[@id=\"sc-item-Cb2c74d38-d77b-48a5-bfea-762eb99b45c5\"]/div[4]/div/div[1]/div/div/div[2]/ul/li[3]/span/span/text()"));

        public IWebElement ShoppingBasketSubtotalData => Driver.FindElement(By.Id("sc-subtotal-label-activecart"));

        public IWebElement ShoppingBasketPrice => Driver.FindElement(By.Id("sc-subtotal-amount-activecart"));
    }
}
