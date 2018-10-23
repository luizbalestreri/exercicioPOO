using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program.dominio;

namespace Program {
    class Program {
        public static List<Produto> produto = new List<Produto>();
        public static List<Pedido> pedidos = new List<Pedido>();

        static void Main(string[] args) {
            int opcao = 0;
            produto.Add(new Produto(1001, "Cadeira simples", 500.00));
            produto.Add(new Produto(1002, "Cadeira acolchoada", 900.00));
            produto.Add(new Produto(1003, "Sofá de três lugares", 20000.00));
            produto.Add(new Produto(1004, "Mesa retangular", 1500.00));
            produto.Add(new Produto(1005, "Mesa retangular", 2000.00));
            produto.Sort();
            do {
                Console.Clear();
                Tela.MostrarTela();
                try {
                    opcao = int.Parse(Console.ReadLine());
                }
                catch (Exception e) {
                    Console.WriteLine("erro " + e.Message);
                    opcao = 0;
                }
                switch (opcao) {
                    case 1:
                        Tela.ListarProdutos();
                        break;
                    case 2:
                        try {
                            Tela.CadastrarProduto();
                        }
                        catch (Exception e) {
                            Console.WriteLine("erro: " + e.Message);
                        }
                        break;
                    case 3:
                        try {
                            Tela.CadastrarPedido();
                        }
                        catch (Exception e) {
                            Console.WriteLine("erro: " + e.Message);
                        }
                        break;
                    case 4:
                        try { Tela.DadosPedido(); }
                        catch (ModelException e) { Console.WriteLine("erro de negócio: " + e.Message); }
                        catch (Exception e) { Console.WriteLine("erro: " + e.Message); }
                        break;
                    case 5:
                        Console.Write("Adeus!");
                        break;
                }
                Console.ReadKey();
            }
            while (opcao != 5);

            Console.WriteLine(produto);
            Console.ReadKey();
        }
    }
}
