using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    internal class Produto
    {
        public string nomeProduto { get; set; }
        public double precoProduto { get; set; }
        

        public Produto(string nome, double preco) { 
            nomeProduto = nome;
            precoProduto = preco;
        }
    }
}
