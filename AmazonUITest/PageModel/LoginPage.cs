using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonUITest.PageModel
{
    public class LoginPage : BasePage
    {
        private IWebDriver webDriver;
        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }

        [FindsBy(How = How.XPath, Using = "//div[@id='nav-tools']/a")]
        public IWebElement btnLogin;

        [FindsBy(How = How.XPath, Using = "//*[@id='ap_email']")]
        public IWebElement txtEmail;

        [FindsBy(How = How.XPath, Using = "//*[@id='continue']/span/input")]
        public IWebElement btnmailSubmit;
       

        [FindsBy(How = How.XPath, Using = "//*[@id='ap_password']")]
        public IWebElement txtPassword;

        [FindsBy(How = How.XPath, Using = "//*[@id='signInSubmit']")]
        public IWebElement btnpasswordSubmit;

        public void ClickToLogin()
        {
            ClickElement(btnLogin);
        }
        public void SetEmail(string email)
        {
            SetText(txtEmail, email);
        }
        public void SetPassword(string password)
        {
            SetText(txtPassword, password);
        }

        public void ClickSubmitContinue()
        {
            ClickElement(btnmailSubmit);
        }
        public void ClickSubmitLogin()
        {
            ClickElement(btnpasswordSubmit);
        }
        


    }

}