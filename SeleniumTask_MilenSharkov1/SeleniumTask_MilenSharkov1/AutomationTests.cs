using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTask_MilenSharkov1.Pages.HomePage;
using SeleniumTask_MilenSharkov1.Pages.SearchResultsPage;
using SeleniumTask_MilenSharkov1.Pages.ProductDetailsPage;
using SeleniumTask_MilenSharkov1.Pages.AddedToBasketPage;
using SeleniumTask_MilenSharkov1.Pages.ShoppingBasketPage;
using FluentAssertions;
using System;


namespace Tests
{
    [TestFixture]
    public class AutomationTests
    {
        private IWebDriver driver;
        private HomePage homePage;
        private SearchResultsPage searchResultsPage;
        private ProductDetailsPage productDetailsPage;
        private AddedToBasketPage addedToBasketPage;
        private ShoppingBasketPage shoppingBasketPage;


        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            homePage = new HomePage(driver);
            homePage.NavigateTo();

            searchResultsPage = new SearchResultsPage(driver);
            productDetailsPage = new ProductDetailsPage(driver);
            addedToBasketPage = new AddedToBasketPage(driver);
            shoppingBasketPage = new ShoppingBasketPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            //driver.Manage().Cookies.DeleteAllCookies(); //Clear cookies
            driver.Close(); //Close browser
        }

        [Test]
        public void PD1_VerifyTheUserIsOnTheCorrectPage()
        {
            string homePageTitle = driver.Title;
            homePageTitle.Should().Be("Amazon.co.uk: Low Prices in Electronics, Books, Sports Equipment & more");
        }

        [Test]
        public void PD2_SearchAndVerifyBookTypeAndPrice()
        {
            homePage.CategoryDropDownButton.Click();
            homePage.BooksCategoryButton.Click();

            homePage.SearchField.Click();
            homePage.SearchField.SendKeys("\"Harry Potter and the Cursed Child\" 1 & 2");
            homePage.AcceptCookiesButton.Click();
            homePage.SearchButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);


            bool adDisplayed = driver.PageSource.Contains("ad-feedback-text-auto-sparkle-hsa-tetris");

            if(adDisplayed)
            {
                string bookName = searchResultsPage.FirstResultWithAdDisplayed.Text.Split(':')[0];
                Assert.AreEqual("Harry Potter and the Cursed Child - Parts One and Two", bookName);
                string paperback = searchResultsPage.PaperbackWithAdDisplayed.Text;
                paperback.Should().Contain("Paperback");
                string bookPrice = searchResultsPage.PriceFieldWithAdDisplayed.Text;
                Assert.IsNotNull(bookPrice);
            }
            else
            {
                string bookName = searchResultsPage.FirstResultAdNotDisplayed.Text.Split(':')[0];
                Assert.AreEqual("Harry Potter and the Cursed Child - Parts One and Two", bookName);
                string paperback = searchResultsPage.PaperbackAdNotDisplayed.Text;
                paperback.Should().Contain("Paperback");
                string bookPrice = searchResultsPage.PriceFieldAdNotDisplayed.Text;
                Assert.IsNotNull(bookPrice);
            }
        }

        [Test]
        public void PD3_VerifyProductDetails()
        {
            homePage.CategoryDropDownButton.Click();
            homePage.BooksCategoryButton.Click();

            homePage.SearchField.Click();
            homePage.SearchField.SendKeys("\"Harry Potter and the Cursed Child\" 1 & 2");
            homePage.AcceptCookiesButton.Click();
            homePage.SearchButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);


            bool adDisplayed = driver.PageSource.Contains("ad-feedback-text-auto-sparkle-hsa-tetris");

            if (adDisplayed)
            {
                searchResultsPage.PaperbackWithAdDisplayed.Click();
            }
            else
            {
                searchResultsPage.PaperbackAdNotDisplayed.Click();
            }

            string selectedBookTitle = productDetailsPage.SelectedBookTitle.Text.Split(':')[0];
            Assert.AreEqual("Harry Potter and the Cursed Child - Parts One and Two", selectedBookTitle);
            string selectedBookType = productDetailsPage.SelectedBookSubtitle.Text.Split(' ')[0];
            selectedBookType.Should().Be("Paperback");

            string bookPrice = productDetailsPage.SelectedBookPrice.Text;
            bookPrice.Should().Be("£4.00");
        }

        [Test]
        public void PD4_VerifyCorrectTitlePriceAndGift()
        {
            homePage.CategoryDropDownButton.Click();
            homePage.BooksCategoryButton.Click();

            homePage.SearchField.Click();
            homePage.SearchField.SendKeys("\"Harry Potter and the Cursed Child\" 1 & 2");
            homePage.AcceptCookiesButton.Click();
            homePage.SearchButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);


            bool adDisplayed = driver.PageSource.Contains("ad-feedback-text-auto-sparkle-hsa-tetris");

            if (adDisplayed)
            {
                searchResultsPage.PaperbackWithAdDisplayed.Click();
            }
            else
            {
                searchResultsPage.PaperbackAdNotDisplayed.Click();
            }

            string selectedBookTitle = productDetailsPage.SelectedBookTitle.Text.Split(':')[0];
            string bookPriceOnProductDetailsPage = productDetailsPage.SelectedBookPrice.Text;

            productDetailsPage.AddToBasketButton.Click();
            addedToBasketPage.GiftCheckbox.Click();

            Assert.IsTrue(addedToBasketPage.GiftCheckbox.Selected);

            string bookPriceOnAddedToBasketPage = addedToBasketPage.BookPriceOnAddedToBasketPage.Text;
            bookPriceOnProductDetailsPage.Should().Be(bookPriceOnAddedToBasketPage);
        }

        [Test]
        public void PD5_VerifyCorrectShoppingBasketContents()
        {
            homePage.CategoryDropDownButton.Click();
            homePage.BooksCategoryButton.Click();

            homePage.SearchField.Click();
            homePage.SearchField.SendKeys("\"Harry Potter and the Cursed Child\" 1 & 2");
            homePage.AcceptCookiesButton.Click();
            homePage.SearchButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);


            bool adDisplayed = driver.PageSource.Contains("ad-feedback-text-auto-sparkle-hsa-tetris");

            if (adDisplayed)
            {
                searchResultsPage.PaperbackWithAdDisplayed.Click();
            }
            else
            {
                searchResultsPage.PaperbackAdNotDisplayed.Click();
            }

            string selectedBookTitle = productDetailsPage.SelectedBookTitle.Text.Split(':')[0];
            string selectedBookType = productDetailsPage.SelectedBookSubtitle.Text.Split(' ')[0];
            string bookPriceOnProductDetailsPage = productDetailsPage.SelectedBookPrice.Text;

            productDetailsPage.AddToBasketButton.Click();
            addedToBasketPage.GiftCheckbox.Click();
            addedToBasketPage.EditBasketButton.Click();

            //string displayedBookTitleOnEditBasketPage = shoppingBasketPage.ShoppingBasketBookTitle.Text.Split(':')[0];
            //displayedBookTitleOnEditBasketPage.Should().Be(selectedBookTitle);

            //string displayedBookTypeOnEditBasketPage = shoppingBasketPage.ShoppingBasketBookType.Text;
            //displayedBookTypeOnEditBasketPage.Should().Be(selectedBookType);

            string displayedBookPriceOnEditBasketPage = shoppingBasketPage.ShoppingBasketPrice.Text;
            displayedBookPriceOnEditBasketPage.Should().Be(bookPriceOnProductDetailsPage);

            string displayedSubtotalItemsOnEditBasketPage = shoppingBasketPage.ShoppingBasketSubtotalData.Text;
            displayedSubtotalItemsOnEditBasketPage.Should().Contain("Subtotal (1 item):");
        }
    }
}
