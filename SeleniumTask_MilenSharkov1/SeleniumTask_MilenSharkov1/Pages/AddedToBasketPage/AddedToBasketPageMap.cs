using OpenQA.Selenium;

namespace SeleniumTask_MilenSharkov1.Pages.AddedToBasketPage
{
    public partial class AddedToBasketPage
    {
        public IWebElement AddedBookToBasket => Driver.FindElement(By.XPath("//*[@id=\"ewc-compact-body\"]/div/div/div[2]/span/div/a/img"));
        ////*[@id="ewc-compact-body"]/div/div/div[2]/span/div/a/img
        public IWebElement GiftCheckbox => Driver.FindElement(By.XPath("//*[@id=\"huc-v2-order-row-mark-gift\"]/div/label/input"));
        public IWebElement BookPriceOnAddedToBasketPage => Driver.FindElement(By.XPath("//*[@id=\"ewc-content\"]/div[1]/span/div/div/div[2]/span/span"));
        public IWebElement EditBasketButton => Driver.FindElement(By.Id("hlb-view-cart-announce"));
    
    }
}
