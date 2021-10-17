using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabadin_primeiro_encontro
{
    public class Conta
    {
        public string Nome { get ; private set; }
        public byte TipoConta { get; private set; }
        public int NumeroConta { get; private set; }
        public decimal Saldo { get; private set; }
        public decimal Limite { get; private set; }
        public decimal SaldoTotal { get; private set; }

        private decimal _limite = 300;

        public Conta(string nome, byte tipoConta, int numeroConta, decimal saldo)
        {
            Nome = nome;
            TipoConta = tipoConta;
            NumeroConta = numeroConta;
            Saldo = saldo;
            Limite = _limite;
            SaldoTotal = SaldoTotal + Limite;
        }

        public void Depositar(decimal valor)
        {
            Saldo += valor;
        }

        public bool Sacar(decimal valor)
        {
            if (valor > SaldoTotal)
                return false;

            Saldo -= valor;

            if (Saldo < 0)
                Saldo += Limite;

            return true;
        }

        public void Transferir(Conta contaDestino, decimal valor)
        {
            Sacar(valor);

            contaDestino.Depositar(valor);
        }

        public override string ToString()
        {
            Console.WriteLine("===========================================================================================================");
            return $"Conta numero {NumeroConta}:\n" +
                   $"Conta de {Nome.ToUpper()}, Saldo {Saldo.ToString("C")}, Limite {Limite.ToString("C")}";
        }
    }
}
