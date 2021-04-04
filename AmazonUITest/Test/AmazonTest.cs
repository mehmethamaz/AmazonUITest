using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;
using AmazonUITest.PageModel;
using AmazonUITest.Utilities;

namespace AmazonUITest.Test 
{
    [Binding, Scope(Feature = "AmazonTest")]
    public class AmazonTest
    {
        public static IWebDriver WebDriver { get; set; }
        public BasePage basePage;
        public LoginPage loginPage;
        public SearchProductPage searchproductPage;
        public BrowserUtility browserUtility;
        string driverPath = String.Empty;

        public AmazonTest()
        {
            driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            browserUtility = new BrowserUtility();

        }

        [StepDefinition(@"'(.*)' browser açılır")]
        public void OpenBrowser(string driver)
        {            
         WebDriver = browserUtility.SetupChromeDriver(driverPath);
                   
            
            basePage = new BasePage(WebDriver);
            loginPage = new LoginPage(WebDriver);
            searchproductPage = new SearchProductPage(WebDriver);
        }

        [StepDefinition(@"'(.*)' sitesine gidilir")]
        public void OpenWebPage(string webPageUrl)
        {
            WebDriver.Navigate().GoToUrl(webPageUrl);
        }


        [StepDefinition(@"Giriş Yap butonuna tıklanır")]
        public void ClicktoLogin()
        {
            loginPage.ClickToLogin();
            if (!basePage.GetCurrentUrl().Contains("amazon.com.tr/ap/signin"))
            {
                Console.WriteLine("Giriş sayfası yüklenemedi!");
            }
        }

        [StepDefinition(@"E-posta adresi '(.*)' olarak girilir")]
        public void SetEmail(string email)
        {
            loginPage.SetEmail(email);
        }

        [StepDefinition(@"Devam et butonuna tıklanır\.")]
        public void ClickSubmitContinue()
        {
            loginPage.ClickSubmitContinue();
        }

        [StepDefinition(@"Şifre '(.*)' olarak girilir\.")]
        public void SetPassword(string password)
        {
            loginPage.SetPassword(password);
        }

        [StepDefinition(@"Giriş yap butonuna tıklanır")]
        public void ClickSubmitLogin()
        {
            loginPage.ClickSubmitLogin();
        }

        [StepDefinition(@"Arama yerine '(.*)' yazılır\.")]
        public void SetProduct(string productname)
        {
            searchproductPage.SetProduct(productname);
        }

        [StepDefinition(@"Arama yap butonuna tıklanır\.")]
        public void SearchProduct()
        {
            searchproductPage.SearchProduct();
        }

        [StepDefinition(@"Ürün görselleri kontrol edilir\.")]
        public void CheckProductImage()
        {
            searchproductPage.CheckProductImage();
        }

        [StepDefinition(@"Rastgele ürüne tıklanır\.")]
        public void ClickRandomProduct()
        {
            searchproductPage.ClickRandomProduct();
        }

        [StepDefinition(@"Ürün sepete eklenir\.")]
        public void AddToBasket()
        {
            searchproductPage.AddToBasket();
        }








        [AfterScenario]
        public void AfterSecenario()
        {
            browserUtility.TearDown();
        }

    }
}