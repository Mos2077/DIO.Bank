using System;
using System.Collections.Generic;

namespace DIO.Bank
{
  class Program
  {
    static List<Conta> ListContas = new List<Conta>();
    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
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
        opcaoUsuario = ObterOpcaoUsuario();
      }
      Console.WriteLine("Obrigado por nos escolher como o seu banco!");
      Console.ReadLine();
    }

    private static void Transferir()

    {
      Console.WriteLine("Qual o número da conta de origem: ");
      int indiceContaOrigem = int.Parse(Console.ReadLine());

      Console.WriteLine("Qual o número da conta de destino: ");
      int indiceContaDestino = int.Parse(Console.ReadLine());

      Console.WriteLine("Qual o valor que você quer transferir: ");
      double valorTransferencia = double.Parse(Console.ReadLine());

      ListContas[indiceContaOrigem].Transferir(valorTransferencia, ListContas[indiceContaDestino]);

    }

    private static void Sacar()
    {
      Console.WriteLine("Qual o número da conta: ");
      int indiceConta = int.Parse(Console.ReadLine());

      Console.WriteLine("Quanto você quer sacar: ");
      double valorSaque = double.Parse(Console.ReadLine());

      ListContas[indiceConta].Sacar(valorSaque);

    }

    private static void Depositar()
    {
      Console.WriteLine("Qual o número da conta: ");
      int indiceConta = int.Parse(Console.ReadLine());

      Console.WriteLine("Qual valor você quer depositar: ");
      double valorDeposito = double.Parse(Console.ReadLine());

      ListContas[indiceConta].Depositar(valorDeposito);

    }

    private static void InserirConta()
    {

      Console.WriteLine("Olá! Vamos criar sua nova conta?");

      Console.Write("Digite 1 para conta Física ou 2 para Pessoa Jurídica: ");
      int entradaTipoconta = int.Parse(Console.ReadLine());

      Console.Write("Vamos criar sua conta? Para começar, digite seu nome: ");
      string entradaNome = Console.ReadLine();

      Console.Write("Com qual valor você vai iniciar sua conta? ");
      double entradaSaldo = double.Parse(Console.ReadLine());

      Console.Write("Gostaria de um limite? Digite um valor, por favor: ");
      double entradaCredito = double.Parse(Console.ReadLine());

      Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoconta,
                                  saldo: entradaSaldo,
                                  credito: entradaCredito,
                                  nome: entradaNome);


      ListContas.Add(novaConta);



    }
    private static void ListarContas()
    {
      Console.WriteLine("Listar contas");

      if (ListContas.Count == 0)
      {
        Console.WriteLine("Nehuma conta cadastrada.");
        return;
      }

      for (int i = 0; i < ListContas.Count; i++)
      {

        Conta conta = ListContas[i];
        Console.Write("#{0} - ", i);
        Console.WriteLine(conta);


      }

    }
    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Bank sempre com você!");
      Console.WriteLine("Informe a opção desejada: ");

      Console.WriteLine("1- Listar contas");
      Console.WriteLine("2- Inserir nova conta");
      Console.WriteLine("3- Transferir");
      Console.WriteLine("4- Sacar");
      Console.WriteLine("5- Depositar");
      Console.WriteLine("C- Limpar tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }

}


