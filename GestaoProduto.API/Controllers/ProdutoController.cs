using GestaoProduto.API.Models;
using GestaoProduto.Services;
using GestaoProduto.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using GestaoProduto.Domain.Entidades;
using Microsoft.EntityFrameworkCore.Design.Internal;

namespace GestaoProduto.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        [HttpPost]
        [Route("AdicionarProduto")]
        public IActionResult Adicionar(NovoProduto novoProduto)
        {
            bool sucesso = _produtoService.Adicionar(
                new Produto(
                    novoProduto.Nome,
                    novoProduto.CodigoBarra,
                    novoProduto.Descricao,
                    novoProduto.Valor,
                    novoProduto.Estoque
                    )
                );
            if (sucesso)
                return Ok("Produto inserido com sucesso");

            return BadRequest("Erro ao inserir");
        }
        [HttpGet]
        [Route("BuscarProdutoPorCodigo")]
        public IActionResult BuscarPorCodigo(string codigo)
        {
            var produtoPesquisado = _produtoService.BuscarPorCodigo(codigo);

            if (produtoPesquisado is null)
            {
                return NotFound($"Produto com codigo de barra {codigo} não encontrado.");
            }

            return Ok(produtoPesquisado);
        }
        [HttpGet]
        [Route("BuscarPorNome")]
        public IActionResult BuscarPorNome(string nome)
        {
            var produtoPesquisado = _produtoService.BuscarPorNome(nome);
            if (produtoPesquisado is null)
            {
                return NotFound($"Produto com nome {nome} não encontrado.");
            }

            return Ok(produtoPesquisado);
        }
        [HttpPut]
        [Route("AtualizarEstoque")]
        public IActionResult AtualizarEstoque(int id, int quantidade)
        {
            try
            {
                var produto = _produtoService.BaixarEstoque(id, quantidade);
                return Ok($"{produto.Nome} atualizado com sucesso! Novo estoque: {produto.Estoque}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar estoque: {ex.Message}");
            }
        }
    }
}