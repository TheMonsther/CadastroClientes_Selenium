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
            Cenario3();
            Cenario4();
            Cenario5();
        }
        //para todos os Cenários é assumido um e-mail válido sendo um e-mail que seja válido na expressão regular ^\w*(\.\w*)?@\w*+\.(a-z)$

        /*
         * Dado que eu esteja na tela de cadastro
         * E insira meu nome e sobrenome
         * E insira meu email válido
         * E insira uma senha com 8 caracteres
         * Quando clicar em Cadastrar
         * Então a página deve exibir meu cadastro feito em uma tabela
         */
        public static void Cenario1()
        {
            cadastroCliente.ClearDatas();
            cadastroCliente.TxtNome.Text = "Nome Sobrenome";
            cadastroCliente.TxtEmail.Text = "teste@gmail.com";
            cadastroCliente.TxtSenha.Text = "12345678";
            cadastroCliente.SetDatas();
            cadastroCliente.BtnCadastrar.Click();
            if(cadastroCliente.ValidaCadastro())
            Console.WriteLine("\nCenario1 executado com sucesso!\n");
            else Console.WriteLine("\nCenario1 executado com divergencia no resultado esperado!\n");
        }

        /*
         * Dado que eu esteja na tela de cadastro
         * E insira meu nome
         * E insira meu email válido
         * E insira uma senha com 8 caracteres
         * Quando clicar em Cadastrar
         * Então a página deve não exibir meu cadastro feito em uma tabela
         */
        public static void Cenario2()
        {
            cadastroCliente.ClearDatas();
            cadastroCliente.TxtNome.Text = "Nome";
            cadastroCliente.TxtEmail.Text = "teste@gmail.com";
            cadastroCliente.TxtSenha.Text = "12345678";
            cadastroCliente.SetDatas();
            cadastroCliente.BtnCadastrar.Click();
            if (cadastroCliente.ValidaCadastro())
                Console.WriteLine("\nCenario2 executado com divergencia no resultado esperado!\n");
            else Console.WriteLine("\nCenario2 executado com sucesso!\n");
        }

        /*
         * Dado que eu esteja na tela de cadastro
         * E insira meu nome e sobrenome
         * E insira meu email inválido
         * E insira uma senha com 8 caracteres
         * Quando clicar em Cadastrar
         * Então a página deve não exibir meu cadastro feito em uma tabela
         */
        public static void Cenario3()
        {
            cadastroCliente.ClearDatas();
            cadastroCliente.TxtNome.Text = "Nome Sobrenome";
            cadastroCliente.TxtEmail.Text = "teste@gmail.co1";
            cadastroCliente.TxtSenha.Text = "12345678";
            cadastroCliente.SetDatas();
            cadastroCliente.BtnCadastrar.Click();
            if (cadastroCliente.ValidaCadastro())
                Console.WriteLine("\nCenario3 executado com divergencia no resultado esperado!\n");
            else Console.WriteLine("\nCenario3 executado com sucesso!\n");
        }

        /*
         * Dado que eu esteja na tela de cadastro
         * E insira meu nome e sobrenome
         * E insira meu email válido
         * E insira uma senha com menos de 8 caracteres
         * Quando clicar em Cadastrar
         * Então a página deve não exibir meu cadastro feito em uma tabela
         */
        public static void Cenario4()
        {
            cadastroCliente.ClearDatas();
            cadastroCliente.TxtNome.Text = "Nome2 Sobrenome";
            cadastroCliente.TxtEmail.Text = "teste@gmail.com";
            cadastroCliente.TxtSenha.Text = "1234567";
            cadastroCliente.SetDatas();
            cadastroCliente.BtnCadastrar.Click();
            if (cadastroCliente.ValidaCadastro())
                Console.WriteLine("\nCenario4 executado com divergencia no resultado esperado!\n");
            else Console.WriteLine("\nCenario4 executado com sucesso!\n");
        }

        /*
         * Dado que eu esteja na tela de cadastro
         * E insira meu nome, sobrenome1 e sobrenome2
         * E insira meu email grande válido
         * E insira uma senha com mais de 8 caracteres e com caracateres especiais
         * Quando clicar em Cadastrar
         * Então a página deve exibir meu cadastro feito em uma tabela
         */
        public static void Cenario5()
        {
            cadastroCliente.ClearDatas();
            cadastroCliente.TxtNome.Text = "Nome Sobrenome1 Sobrenome2";
            cadastroCliente.TxtEmail.Text = "testeemail.Nome.Sobrenome1.Sobrenome2@hotmail.com";
            cadastroCliente.TxtSenha.Text = "Senha C0m Mais De 8 Caracteres !@#$%**--==";
            cadastroCliente.SetDatas();
            cadastroCliente.BtnCadastrar.Click();
            if (cadastroCliente.ValidaCadastro())
                Console.WriteLine("\nCenario5 executado com sucesso!\n"); 
            else Console.WriteLine("\nCenario5 executado com divergencia no resultado esperado!\n");
        }
    }
}
