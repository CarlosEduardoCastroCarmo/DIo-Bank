using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBank
{
    class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            // Validação de saldo insuficiente;

            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            /*Caso o valor do saque seja menor que o valor do saldo acrescido do valor de crédito especial a operação 
             a operação será efetivada.*/

            else
            {
                this.Saldo -= valorSaque;
                return true;
                Console.WriteLine($"Saldo atual da conta {this.Nome} é igual é: {this.Saldo}");
            }            
        }

        public void Depositar(double valorDeposito)
        {
            // Acresce o valor do saldo atual do valor recebido do parâmetro valorDeposito;

            this.Saldo += valorDeposito;
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Tipo Conta: " + this.Saldo);
            sb.AppendLine("Nome: " + this.Nome);
            sb.AppendLine("Saldo: " + this.Saldo);
            sb.AppendLine("Credito: " + this.Credito);

            return sb.ToString();                
        }

    }
}
