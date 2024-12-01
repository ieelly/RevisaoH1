
using GestaoProduto.Data.Contexto;
using GestaoProduto.Domain.Entidades;
using GestaoProduto.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Data.Repositorios
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDBContext _appDBContext;

        public ProdutoRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public void Adicionar(Produto novoProduto)
        {
            _appDBContext.Produto.Add(novoProduto);
            _appDBContext.SaveChanges();
        }

        public Produto? ObterPorNome(string nome)
        {

            return _appDBContext.Produto.Where(
                p => p.Nome == nome
                ).FirstOrDefault();
        }

        public Produto? ObterPorCodigo(string codigo)
        {
            return _appDBContext.Produto.Where(
                p => p.CodigoBarra == codigo).FirstOrDefault();
        }
        public Produto? AtualizarEstoque(int quantidade, int id)
        {
            var produto = _appDBContext.Produto.Where(p => p.Id == id).FirstOrDefault();

            if (produto != null)
            {
                produto.DiminuirEstoque(quantidade);
                _appDBContext.SaveChanges();
                
            }
            return produto;
        }

        public IList<Produto> ObterTodos()
        {
            return _appDBContext.Produto.ToList();
        }
        public Produto ObterPorId(int id)
        {
            return _appDBContext.Produto.FirstOrDefault(p => p.Id == id);
        }
    }
}
