using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    internal class Cliente
    {
        public int id { get; set; }
        public string Nome {  get; set; }
        public string cpf { get; set; }
        public int Pontos {  get; set; }

        public Cliente(string nome, int pontos) { 
            Nome = nome;
            Pontos = 0;
        }

        public void adicionarPontos(int pontos)
        {
            Pontos += pontos;
        }
    }
}
