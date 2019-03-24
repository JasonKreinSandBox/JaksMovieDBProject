using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriver = SwagLabsUI.WebDriver;

namespace SwagLabsUI
{
    public class LoginPage
    {
        WebDriver _webDriver;
        private const string url = "https://www.saucedemo.com";
        public LoginPage(WebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void LoadPage()
        {
            _webDriver.OpenPage(url);
        }
        public void InputUserName(string name)
        {
            _webDriver.FindElementById("user-name").SendKeys(name);
        }

        public void InputPassword(string password)
        {
            _webDriver.FindElementById("password").SendKeys(password);
        }

        public void ClickLogin()
        {
            _webDriver.FindElementByClass("btn_action").Click();
        }
    }
}
