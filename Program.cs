using System;
using System.Collections.Generic;

namespace Bank_exercise
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();
            while(OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
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
                    
                    default:
                        throw new ArgumentOutOfRangeException();    
                   
                }
                OpcaoUsuario = ObterOpcaoUsuario();
            }

           Console.WriteLine("Obrigado pela preferência \r\n");
           Console.ReadLine();
          
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o número da conta de origem");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido");
            double valorTransferido = double.Parse(Console.ReadLine()); 

            listContas[indiceContaOrigem].Transferir(valorTransferido, listContas[indiceContaDestino]);
                
        }
        private static void Sacar()
        {
            Console.WriteLine("Insira o número da conta");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Indique o valor a ser sacado");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        
        }

          private static void Depositar()
        {
            Console.WriteLine("Insira o número da conta");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Indique o valor a ser depositado");
            double valorDeposito = double.Parse(Console.ReadLine());         
            listContas[indiceConta].Depositar(valorDeposito);
        
        }

        private static void InserirConta()
        {
           Console.WriteLine("Inserir nova Cota");

           Console.WriteLine("Insira 1 para pessoa física e 2 para pessoa jurídica");
           int entradaTipoConta = int.Parse(Console.ReadLine());

           Console.WriteLine( "Insira o nome do Cliente");
           string entradanome = Console.ReadLine();

           Console.WriteLine("Digite o saldo inicial: ");
           double entradasaldo = double.Parse(Console.ReadLine());

           Console.WriteLine("Digite o crédito: ");
           double entradacredito = double.Parse(Console.ReadLine());

           Conta novaconta = new Conta(tipoConta: (Tipo_conta)entradaTipoConta,
                                                    saldo: entradasaldo, 
                                                    credito: entradacredito, 
                                                    Nome: entradanome);

            listContas.Add(novaconta);
            
        }
        
        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");
            if(listContas.Count == 0)
            {
                Console.WriteLine(" Nenhuma Conta cadastrada");
                return;
            }
            for (int i = 0; i< listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
                                
            }



        }


        private static string ObterOpcaoUsuario ()
        {
            Console.WriteLine();
            Console.WriteLine("Noob Bank ao seu dispor \r\n" + "Informe a opção desejada: ");

            Console.WriteLine("1- Listar Contas");
            Console.WriteLine("2- Inserir nova Conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
        }
    }
}
