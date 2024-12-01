using GestaoProduto.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Domain.Interfaces
{
    public interface IRepositoryBase<T>
    {
        public void Adicionar(T entidade);
        public IList<T> ObterTodos();
    }
}
