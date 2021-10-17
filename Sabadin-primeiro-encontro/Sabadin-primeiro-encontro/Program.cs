using System;
using System.Collections.Generic;

namespace Sabadin_primeiro_encontro
{
    class Program
    {
        private static List<Conta> _contas;

        static void Main(string[] args)
        {
            _contas = new List<Conta>();
            ExibirMenu();
        }

        public static void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("=========================");
            Console.WriteLine("           MENU          ");
            Console.WriteLine("=========================");
            Console.WriteLine();
            Console.WriteLine("Selecione uma opção:");

            Console.WriteLine("1 - Criar uma conta");
            Console.WriteLine();

            Console.WriteLine("2 - Depositar");
            Console.WriteLine();

            Console.WriteLine("3 - Sacar");
            Console.WriteLine();

            Console.WriteLine("4 - Transferir");
            Console.WriteLine();

            Console.WriteLine("5 - Saldo");
            Console.WriteLine();

            Console.WriteLine("6 - Listar contas");
            Console.WriteLine();

            Console.Write("Sua opção =>");

            int opcao = int.Parse(Console.ReadLine());
            SelecionarOpcao(opcao);
        }

        private static void SelecionarOpcao(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    CadastrarConta();
                    break;

                case 2:
                    Depositar();
                    break;

                case 3:
                    Sacar();
                    break;

                case 4:
                    Transferir();
                    break;

                case 6:
                    ListarContas();
                    break;

                default:
                    Console.WriteLine("Opção digitada é invalida, tente novamente!");
                    ExibirMenu();
                    break;
            }
        }

        private static void Depositar()
        {
            Console.Write("Informe a conta para o deposito:");
            int conta = int.Parse(Console.ReadLine());

            if (VerificarConta(conta))
            {
                Console.Write("Informe o valor do deposito:");
                decimal valor = decimal.Parse(Console.ReadLine());
                ObterConta(conta).Depositar(valor);
            }
            else
            {
                Console.WriteLine("Conta não existe");
            }
            Console.WriteLine("Digite enter para continuar");
            Console.ReadLine();
            ExibirMenu();
        }

        private static void Sacar()
        {
            Console.Write("Digite a conta para saque:");
            int numeroConta = int.Parse(Console.ReadLine());

            if (VerificarConta(numeroConta))
            {
                Console.Write("Digite o valor do saque:");
                decimal valor = decimal.Parse(Console.ReadLine());

                Conta conta = ObterConta(numeroConta);
                bool verificarSaque = conta.Sacar(valor);

                if (verificarSaque)
                    Console.WriteLine($"Saque efetuado, novo saldo {conta.Saldo}, limite disponivel: {conta.Limite}");

                if (!verificarSaque)
                    Console.WriteLine("Não foi possivel efetuar o saque, saldo não suficiente.");
            }
            else
            {
                Console.WriteLine("Conta não existe");
            }

            Console.WriteLine("Aperte enter para continuar");
            Console.ReadLine();

            ExibirMenu();
        }

        private static void Transferir()
        {
            Console.Write("Selecione a conta de origem: ");
            int contaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Selecione a conta de origem: ");
            int contaDestino = int.Parse(Console.ReadLine());

            Console.Write("Insira o valor da a ser tranferido: ");
            decimal valor = decimal.Parse(Console.ReadLine());

            if (VerificarConta(contaDestino) && VerificarConta(contaOrigem))
            {
                ObterConta(contaOrigem).Transferir(ObterConta(contaDestino), valor);
            }
            else
            {
                Console.WriteLine("Conta de origem ou conta de destino não existente.");
            }
            Console.WriteLine("Aperte enter para continuar");
            Console.ReadLine();
            ExibirMenu();
        }

        private static void ListarContas()
        {
            Console.Clear();
            if (_contas.Count < 1)
            {
                Console.WriteLine("Não existem contas cadastradas.");
            }
            else
            {
                for (var i = 0; i < _contas.Count; i++)
                {
                    Console.WriteLine(_contas[i].ToString());
                }
            }
            Console.WriteLine("\nAperte enter para continuar");
            Console.ReadLine();
            ExibirMenu();
        }

        private static void CadastrarConta()
        {
            Console.Clear();
            Console.WriteLine("=========================");
            Console.WriteLine("     Criação de conta    ");
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Tipo de conta = 1 PF ou 2 PJ: ");
            byte tipoConta = byte.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Digite o saldo inicial da conta: ");
            decimal saldo = decimal.Parse(Console.ReadLine());

            int numeroConta = _contas.Count + 1;

            var conta = new Conta(nome, tipoConta, numeroConta, saldo);

            _contas.Add(conta);

            Console.WriteLine("Conta inserida com sucesso, aperte qualquer coisa para continuar");
            Console.ReadLine();
            ExibirMenu();
        }

        private static bool VerificarConta(int conta)
        {
            if (ObterConta(conta) != null)
                return true;

            return false;
        }

        private static Conta ObterConta(int numeroConta)
        {
            return _contas.Find(a => a.NumeroConta == numeroConta) ?? null;
        }
    }
}
