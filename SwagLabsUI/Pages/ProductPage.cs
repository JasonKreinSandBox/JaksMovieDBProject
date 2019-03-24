using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WebDriver = SwagLabsUI.WebDriver;

namespace SwagLabsUI.Pages
{
    public class ProductPage
    {
        WebDriver _webdriver;

        public ProductPage(WebDriver webDriver)
        {
            _webdriver = webDriver;
        }

        public void AddItemToCart(string name)
        {
            var itemList = _webdriver.FindElementsbyClass("inventory_item");
            foreach(var i in itemList)
            {
                if(i.Text.Contains(name))
                {
                    var myElement = i.FindElement(By.ClassName("pricebar"));
                    var addToCart = myElement.FindElement(By.XPath("./button"));
                    addToCart.Click();
                }
            }
        }
    }
}
