using GestaoProduto.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Services.Interfaces
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        public Produto BuscarPorCodigo(string codigo);
        public Produto BuscarPorNome(string nome);
        public Produto BaixarEstoque(int id, int quantidade);
    }
}
