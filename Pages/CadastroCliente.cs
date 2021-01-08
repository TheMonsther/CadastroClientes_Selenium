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

        //Verifica se o nome e o e-mail presentes na tabela são iguais os digitados anteriormente.
        public bool ValidaCadastro()
        {
            IList<IWebElement> tabela;
            string id;
            tabela = driver.FindElements(By.CssSelector("table"));

            foreach (IWebElement linha in tabela)
            {
                id = linha.FindElement(By.CssSelector("td")).Text;
                if ((linha.FindElement(By.CssSelector("#tdUserName" + id + "")).Text.Equals(TxtNome.Text)))
                {
                    if ((linha.FindElement(By.CssSelector("#tdUserEmail" + id + "")).Text.Equals(TxtEmail.Text)))
                        return true;
                }

            }
            return false;
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
