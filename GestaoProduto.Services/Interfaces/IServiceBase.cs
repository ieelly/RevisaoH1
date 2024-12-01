using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Services.Interfaces
{
    public interface IServiceBase<T>
    {
        public bool Adicionar(T entidade);
    }
}
