using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SwagLabsUI
{
    public class WebDriver : IWebDriver
    {
        private IWebDriver _driver;

        public WebDriver()
        {
            _driver = new ChromeDriver();
        }
        public string Url
        {
            get
            {
                return _driver.Url;
            }

            set
            {
                _driver = this;
            }
        }

        public string Title
        {
            get
            {
                return _driver.Title;
            }
        }

        public string PageSource
        {
            get
            {
                return _driver.PageSource;
            }
        }

        public string CurrentWindowHandle
        {
            get
            {
                return _driver.CurrentWindowHandle;
            }
        }

        public ReadOnlyCollection<string> WindowHandles
        {
            get
            {
                return _driver.WindowHandles;
            }
        }

        public void Close()
        {
            _driver.Close();
        }

        public void Quit()
        {
            _driver.Quit();
        }

        public IOptions Manage()
        {
            throw new NotImplementedException();
        }

        public INavigation Navigate()
        {
            throw new NotImplementedException();
        }

        public void OpenPage(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void Back()
        {
            _driver.Navigate().Back();
        }

        public void Forward()
        {
            _driver.Navigate().Forward();
        }

        public ITargetLocator SwitchTo()
        {
            throw new NotImplementedException();
        }

        public IWebElement FindElement(By by)
        {
            return _driver.FindElement(by);
        }

        public IWebElement FindElementByXPath(string xpath)
        {
            return FindElement(By.XPath(xpath));

        }

        public IWebElement FindElementById(string id)
        {
            return FindElement(By.Id(id));
        }

        public IWebElement FindElementByClass(string name)
        {
            return _driver.FindElement(By.ClassName(name));
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return _driver.FindElements(by);
        }

        public List<IWebElement> FindElementsbyClass(string className)
        {
            var inventoryList = new List<IWebElement>();
            var listOfElementsByClassName = FindElements(By.ClassName(className));
            foreach(var i in listOfElementsByClassName)
            {
                inventoryList.Add(i);
            }
            return inventoryList;
        }

        public void Dispose()
        {
            _driver.Dispose();
        }

    }
}
