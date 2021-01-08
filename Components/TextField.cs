using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroClientes_Selenium.Components
{
    class TextField
    {
        private IWebElement webElement;
        private string text = "";

        public string Text { get => text; set { text = value; } }

        public IWebElement WebElement { get => webElement; set { webElement = value; } }

    }
}
