using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;

namespace SeleniumTask_MilenSharkov1.Pages.SearchResultsPage
{
    public partial class SearchResultsPage
    {
        public IWebElement Ad => Driver.FindElement(By.Id("ad - feedback - text - auto - sparkle - hsa - tetris"));
        //public IWebElement FirsArticleWithAdDislayed => Driver.FindElement(By.CssSelector("[data-cel-widget='search_result_1']"));

        public IWebElement FirstResultWithAdDisplayed => Driver.FindElement(By.XPath("//*[@id=\"search\"]/div[1]/div[2]/div/span[3]/div[2]/div[2]/div/span/div/div/div[2]/div[2]/div/div[1]/div/div/div[1]/h2/a/span"));
        public IWebElement FirstResultAdNotDisplayed => Driver.FindElement(By.XPath("//*[@id=\"search\"]/div[1]/div[2]/div/span[3]/div[2]/div[1]/div/span/div/div/div[2]/div[2]/div/div[1]/div/div/div[1]/h2/a/span"));

        public IWebElement PaperbackWithAdDisplayed => Driver.FindElement(By.XPath("//*[@id=\"search\"]/div[1]/div[2]/div/span[3]/div[2]/div[2]/div/span/div/div/div[2]/div[2]/div/div[2]/div[1]/div/div[1]/div[1]/a"));
        public IWebElement PaperbackAdNotDisplayed => Driver.FindElement(By.XPath("//*[@id=\"search\"]/div[1]/div[2]/div/span[3]/div[2]/div[1]/div/span/div/div/div[2]/div[2]/div/div[2]/div[1]/div/div[2]/div/div[2]/div[1]/a"));

        public IWebElement PriceFieldWithAdDisplayed => Driver.FindElement(By.XPath("//*[@id=\"search\"]/div[1]/div[2]/div/span[3]/div[2]/div[2]/div/span/div/div/div[2]/div[2]/div/div[2]/div[1]/div/div[1]/div[2]/div/div/a/span[1]/span[2]/span[2]"));

        public IWebElement PriceFieldAdNotDisplayed => Driver.FindElement(By.XPath("//*[@id=\"search\"]/div[1]/div[2]/div/span[3]/div[2]/div[1]/div/span/div/div/div[2]/div[2]/div/div[2]/div[1]/div/div[1]/div[2]/div/div/a/span[1]/span[1]"));

        ////*[@id="search"]/div[1]/div[2]/div/span[3]/div[2]/div[2]/div/span/div/div/div[2]/div[2]/div/div[2]/div[1]/div/div[1]/div[2]/div/div/a/span[1]
    }
}
