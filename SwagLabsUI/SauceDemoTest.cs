﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwagLabsUI.Pages;

namespace SwagLabsUI
{
  [TestClass]
  public class SauceDemoTest
  {
    LoginPage loginPage;
    ProductPage productPage;
    CartPage cartPage;
    const string username = "standard_user";
    const string password = "secret_sauce";
    int expectedItems = 2;
    const string onesie = "Sauce Labs Onesie";
    const string bikelight = "Sauce Labs Bike Light";

    [TestMethod]
    public void AddItemsToCartValidateCartHasItems()
    {
      //Setup Test 
      var TestBrowser = new WebDriver();
      loginPage = new LoginPage(TestBrowser);
      productPage = new ProductPage(TestBrowser);
      cartPage = new CartPage(TestBrowser);

      //Login
      loginPage.LoadPage();
      loginPage.InputUserName(username);
      loginPage.InputPassword(password);
      loginPage.ClickLogin();

      //Add items to cart
      productPage.AddItemToCart(bikelight);
      productPage.AddItemToCart(onesie);
      cartPage.GoToCart();

      var cart = cartPage.GetItemsInCart();
      Assert.IsNotNull(cart);
      Assert.AreEqual(expectedItems, cart.Count, $"Expected 2 items in cart, there were {cart.Count}");

      //Validate expected results
      var expectedCartCount = 0;
      foreach (var i in cart)
      {
        if (i.Name == onesie || i.Name == bikelight)
        {
          expectedCartCount++;
        }
      }

      Assert.AreEqual(expectedItems, expectedCartCount);

      TestBrowser.Close();
    }
  }
}
