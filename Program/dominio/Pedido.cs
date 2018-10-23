using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.dominio {
    class Pedido {
        public int codigo;
        public DateTime data;
        public List<ItemPedido> itens;

        public Pedido(int codigo, int dia, int mes, int ano) {
            this.codigo = codigo;
            data = new DateTime(ano, mes, dia);
            itens = new List<ItemPedido>();
        }

        public double ValorTotal() {
            double soma = 0f;
            for (int i = 0; i< itens.Count; i++) {
                soma = soma + itens[i].subTotal();
            }
            return soma;
        }

        public override string ToString() {
            String s = "Pedido: " + codigo + ", data:" + data.Day + "/" + data.Month + "/" + data.Year + "\n"
                + "itens:\n";
            for (int i = 0; i < itens.Count; i++) {
                s = s + itens[i] + "\n";
            }
            s = s + "Total de pedido: " + ValorTotal().ToString("F2", CultureInfo.InvariantCulture);
            return s;
        }
    }
}
