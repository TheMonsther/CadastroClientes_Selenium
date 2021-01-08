using CadastroClientes_Selenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace CadastroClientes_Selenium
{
    class ClasseTeste
    {
        protected static IWebDriver driver;
        protected static CadastroCliente cadastroCliente;

        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");

            driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("http://prova.stefanini-jgr.com.br/teste/qa/");

            cadastroCliente = new CadastroCliente(driver);

            Cenario1();
            Cenario2();
        }
        /*
         * Dado
         * Quando
         * Então
         */

        /*
         * Dado que eu esteja na tela de cadastro
         * E insira meu nome e sobrenome
         * E insira meu email válido
         * E insira uma senha com mais de 8 caracteres
         * Quando clicar em Cadastrar
         * Então a página deve exibir meu cadastro feito em uma tabela
         */
        public static void Cenario1()
        {
            cadastroCliente.TxtNome.Text = "Roberto Golveia";
            cadastroCliente.TxtEmail.Text = "roberto@gmail.com";
            cadastroCliente.TxtSenha.Text = "12345678";
            cadastroCliente.SetDatas();
            cadastroCliente.BtnCadastrar.Click();
            if(cadastroCliente.ValidaCadastro())
            Console.WriteLine("Cenario encerrado com sucesso!");
            else Console.WriteLine("Cenario encerrado com divergencia no resultado");
        }

        public static void Cenario2()
        {

        }
    }
}
