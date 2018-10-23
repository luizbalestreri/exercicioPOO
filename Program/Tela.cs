using System;
using Program.dominio;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program {
    class Tela {

        //Produto produto = new Produto();

        public static void MostrarTela() {
            Console.WriteLine("" +
                "1 – Listar produtos ordenadamente\n" +
                "2 – Cadastrar produto\n" +
                "3 – Cadastrar pedido\n" +
                "4 – Mostrar dados de um pedido\n" +
                "5 – Sair");
        }

        public static void ListarProdutos() {
            for (int i = 0; i < Program.produto.Count; i++) {
                Console.WriteLine(Program.produto[i]);
            }
        }

        public static void CadastrarProduto() {

            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Digite a descrição do produto: ");
            string descricao = Console.ReadLine();
            Console.Write("Digite o preço do produto: ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Program.produto.Add(new Produto(codigo, descricao, preco));
            Program.produto.Sort();
        }

        public static void CadastrarPedido() {
            Console.WriteLine("Digite os dados do pedido:");
            Console.Write("Código:");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Dia:");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("Mês:");
            int mes = int.Parse(Console.ReadLine());
            Console.Write("Ano:");
            int ano = int.Parse(Console.ReadLine());
            Pedido P = new Pedido(codigo, dia, mes, ano);
            Console.Write("Quantos itens tem o pedido:");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++) {
                Console.Write("Digite os dados do " + (i + 1) + " item:\n");
                Console.Write("Produto(Código):");
                int codProduto = int.Parse(Console.ReadLine());
                int pos = Program.produto.FindIndex(x => x.codigo == codProduto);
                if (pos == -1) {
                    throw new ModelException("Código não encontrado " + codProduto);
                }
                Console.Write("Quantidade:");
                int qte = int.Parse(Console.ReadLine());
                Console.Write("Porcentagem de desconto:");
                double pct = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                ItemPedido ip = new ItemPedido(qte, pct, Program.produto[pos], P);
                P.itens.Add(ip);
            }
            Program.pedidos.Add(P);
        }

        public static void DadosPedido() {
            Console.Write("Digite o código do pedido: ");
            int codigo = int.Parse(Console.ReadLine());
            int indice = Program.pedidos.FindIndex(x => x.codigo == codigo);
            if (indice == -1) { throw new ModelException("Código não encontrado " + codigo); }
            else {
                Console.WriteLine(Program.pedidos[indice]);
            }
        }
    }

}
