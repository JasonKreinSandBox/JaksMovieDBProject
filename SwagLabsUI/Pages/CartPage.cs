using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WebDriver = SwagLabsUI.WebDriver;

namespace SwagLabsUI.Pages
{
    public class CartPage
    {
        WebDriver _webdriver;
        public CartPage(WebDriver webdriver)
        {
            _webdriver = webdriver;
        }

        public void GoToCart()
        {
            _webdriver.FindElementByXPath("//*[@id='shopping_cart_container']").Click();
        }

        public List<InventoryItem> GetItemsInCart()
        {
            var itemList = new List<InventoryItem>();
            var inventory = _webdriver.FindElements(By.ClassName("cart_item"));
            foreach (var item in inventory)
            {
                double price;
                //Split text and add to inventory item.
                var inventoryItemText = item.Text.Trim().Remove(0, 3).Replace('\r','^').Replace('\n', ' ').Split('^');

                var inventoryItem = new InventoryItem();
                inventoryItem.Name = inventoryItemText[0];
                inventoryItem.Description = inventoryItemText[1];
                double.TryParse(inventoryItemText[2].ToString(), out price);
                inventoryItem.Price = price;
                itemList.Add(inventoryItem);
            }

            return itemList;
        }
    }
}
