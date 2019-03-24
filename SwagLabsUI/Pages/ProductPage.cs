using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void AddBikeLightToCart()
        {
            _webdriver.FindElementByXPath("//*[@id='inventory_container']/div/div[2]/div[3]/button").Click();
        }

        public void AddOnesieToCart()
        {
            _webdriver.FindElementByXPath("//*[@id='inventory_container']/div/div[5]/div[3]/button").Click();
        }
    }
}
