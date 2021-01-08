using CadastroClientes_Selenium.Components;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace CadastroClientes_Selenium.Pages
{
    class CadastroCliente
    {
        private TextField txtNome = new TextField();
        private TextField txtEmail = new TextField();
        private TextField txtSenha = new TextField();
        private IWebElement btnCadastrar;
        private IWebDriver driver;

        public CadastroCliente(IWebDriver driverMain)
        {
            driver = driverMain;
            TxtNome.WebElement = driver.FindElement(By.Id("name"));
            TxtEmail.WebElement = driver.FindElement(By.Id("email"));
            TxtSenha.WebElement = driver.FindElement(By.Id("password"));

            btnCadastrar = driver.FindElement(By.Id("register"));
        }

        //Obs: como esse método vai ser chamado por um assert, o estado FALSE significa que foi cadastrado com sucesso
        public bool ValidaCadastro()
        {
            IList<IWebElement> tabela;
            tabela = driver.FindElements(By.CssSelector("table"));

            foreach (IWebElement linha in tabela)
            {
                linha.FindElement(By.CssSelector("tr"));
            }
            return true;
        }

        public void SetDatas()
        {
            txtNome.WebElement.SendKeys(txtNome.Text);
            txtEmail.WebElement.SendKeys(txtEmail.Text);
            txtSenha.WebElement.SendKeys(txtSenha.Text);
        }

        public TextField TxtNome { get => txtNome;}
        public TextField TxtEmail { get => txtEmail;}
        public TextField TxtSenha { get => txtSenha;}
        public IWebElement BtnCadastrar { get => btnCadastrar;}
    }
}
