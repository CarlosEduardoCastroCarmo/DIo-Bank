using System;
using System.Collections.Generic;
using System.Globalization;


namespace DotnetBank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opUsuario = "";

            do
            {
                opUsuario = ObterOpcaoUsuario();

                switch (opUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        Console.WriteLine("Encerrando a execução do programa");
                        break;
                }
            } while (opUsuario != "X" || opUsuario != "x");
        }

        private static void Depositar()
        {
            Console.WriteLine("Informe o indice da conta para saque: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Informe o valor do saque: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            Console.WriteLine();

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Transferir()
        {
            Console.Write("Informe o indice da conta que deseja efetuar a transferência: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Informe o indice da conta que deseja efetuar a transferência: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Informe o valor que deseja transferir: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

            Console.WriteLine("Dados da conta destino: ");

            Console.WriteLine(listContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.WriteLine("Informe o indice da conta para saque: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Informe o valor do saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            Console.WriteLine();

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            if(listContas.Count > 0)
            {
                for(int i = 0; i < listContas.Count; i++)
                {
                    Conta conta = listContas[i];
                    Console.WriteLine($"# Conta {i}");
                    Console.WriteLine(conta);
                }
            }
            else
            {
                Console.WriteLine("Lista de contas está vazia");
            }           
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Informe 1 para conta tipo pessoa física e 2 para conta tipo pessoa jurídica: ");
            TipoConta entradaTipoConta = Enum.Parse<TipoConta>(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(entradaTipoConta, entradaSaldo, entradaCredito, entradaNome);
            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();

            Console.WriteLine("Bem vindo a DotNetBank, o seu banco digital");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar Contas.");
            Console.WriteLine("2 - Cadastrar nova conta.");
            Console.WriteLine("3 - Transferências.");
            Console.WriteLine("4 - Sacar.");
            Console.WriteLine("5 - Depositar.");
            Console.WriteLine("C - Limpar tela.");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}
