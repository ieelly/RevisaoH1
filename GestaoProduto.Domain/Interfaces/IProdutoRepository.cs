using GestaoProduto.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Domain.Interfaces
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        public Produto ObterPorCodigo(string codigo);
        public Produto ObterPorNome(string nome);
        public Produto AtualizarEstoque(int quantidade, int id);
        Produto ObterPorId(int id);
    }
}
