using System;
using System.Collections.Generic;
using System.Globalization;

namespace DotnetBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Conta conta = new Conta(TipoConta.PessoaFisica, 0, 0, "Carlos");

            Console.WriteLine(conta);
        }
    }
}
