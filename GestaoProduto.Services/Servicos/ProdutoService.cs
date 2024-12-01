using GestaoProduto.Domain.Entidades;
using GestaoProduto.Domain.Interfaces;
using GestaoProduto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Services.Servicos
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public bool Adicionar(Produto novoProduto)
        {
            Produto produtoNome = _produtoRepository.ObterPorNome(novoProduto.Nome);
            Produto produtoCodigo = _produtoRepository.ObterPorCodigo(novoProduto.CodigoBarra);

            if (produtoNome != null)
            {
                throw new Exception("Já existe um produto com o mesmo nome.");
                return false;
            
            }
            if (produtoCodigo != null)
            {
                throw new Exception("Já existe um produto com o mesmo código de barras.");
                return false;
            }

            _produtoRepository.Adicionar(novoProduto);
            return true;

        }
        public Produto BaixarEstoque(int id, int quantidade)
        {
            var produto = _produtoRepository.ObterPorId(id);
            if (produto == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            if (quantidade > produto.Estoque)
            {
                throw new Exception("A quantidade informada para baixar é maior que o estoque disponível.");
            }

            return _produtoRepository.AtualizarEstoque(quantidade, id);
        }
        public Produto BuscarPorCodigo(string codigo)
        {
            return _produtoRepository.ObterPorCodigo(codigo);
        }
        public Produto BuscarPorNome(string nome)
        {
            return _produtoRepository.ObterPorNome(nome);
        }


    }
}
