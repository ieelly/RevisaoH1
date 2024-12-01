using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Domain.Entidades
{
    public class Produto
    {
        public Produto(string nome, string codigoBarra, string descricao, decimal valor, int estoque)
        {
            CodigoBarra = codigoBarra;
            Descricao = descricao;
            Valor = valor;
            Estoque = estoque;
            Nome = nome;
        }

        public Produto(int id,string nome, string codigoBarra, string descricao, decimal valor, int estoque)
        {
            Id = id;
            Nome = nome;
            CodigoBarra = codigoBarra;
            Descricao = descricao;
            Valor = valor;
            Estoque = estoque;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string CodigoBarra {  get; private set; }
        public decimal Valor { get; private set; }
        public int Estoque { get; private set; }

        public void DiminuirEstoque(int valor)
        {
            Estoque -= valor;
        }


    }
}
