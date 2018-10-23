using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.dominio {
    class ItemPedido {
        int quantidade;
        double porcentagemDesconto;
        public Produto produto;
        public Pedido pedido;

        public ItemPedido(int quantidade, double porcentagemDesconto, Produto produto, Pedido pedido) {
            this.quantidade = quantidade;
            this.produto = produto;
            this.pedido = pedido;
            this.porcentagemDesconto = porcentagemDesconto;
        }

        public double subTotal() {
            double desconto = produto.preco * porcentagemDesconto / 100;
            return (produto.preco - desconto) * quantidade;
        }

        public override string ToString() {
            return produto.descricao + ", Preço: " + produto.preco + ", Qte: " + quantidade + ", Desconto: " + porcentagemDesconto + "%, Subtotal: " + subTotal();
        }
    }
}
