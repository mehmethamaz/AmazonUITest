using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonUITest.PageModel 
{
public class SearchProductPage : BasePage
    {
        private IWebDriver webDriver;
        public SearchProductPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }


        [FindsBy(How = How.XPath, Using = "//*[@id='twotabsearchtextbox']")]
        public IWebElement txtsearchProduct;

        [FindsBy(How = How.XPath, Using = "//*[@id='nav-search-submit-button']")]
        public IWebElement btnsearchSubmit; 


        [FindsBy(How = How.XPath, Using = "//a/div[@class='a-section aok-relative s-image-square-aspect']/img")]
        public IList<IWebElement> productImageList;

        [FindsBy(How = How.XPath, Using = "//span[@class='a-size-base-plus a-color-base a-text-normal']")]
        public IList<IWebElement> txtProductName;

        [FindsBy(How = How.XPath, Using = "//input[@id='add-to-cart-button']")]
        public IWebElement btnAddToBasket;

        public void SetProduct(string productname) 
        {
            SetText(txtsearchProduct, productname);
        }

        public void SearchProduct() 
        {
            Wait(5);
            ClickableElement(btnsearchSubmit);
            ClickElement(btnsearchSubmit);
        }

        public void CheckProductImage()
        {
            Wait(10);
            for (int i = 0; i < productImageList.Count; i++)
            {
                Wait(10);
                if (productImageList[i].Enabled)
                {
                    Wait(10);
                    Console.WriteLine(txtProductName[i].Text + " ürününün resmi mevcut değil!");
                }
            }
        }
        public void ClickRandomProduct()
        {
            Wait(10);
            Random rnd = new Random();
            int rndProduct = rnd.Next(1, productImageList.Count - 1);
            ClickableElement(productImageList[rndProduct]);
            ClickElement(productImageList[rndProduct]);
        }
        public void AddToBasket()
        {
            Wait(10);
            ClickableElement(btnAddToBasket);
            ClickElement(btnAddToBasket);
        }

    }
}