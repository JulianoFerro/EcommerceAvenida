using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EcommerceAvenida.Models;

namespace EcommerceAvenida.Controles
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoControle : ControllerBase
    {

        private readonly Servicos.Interface.IProdutoServico _servico;

        public ProdutoControle(Servicos.Interface.IProdutoServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodasProdutosAsync()
        {
            return Ok(await _servico.ObterTodasProdutosAsync());
        }

        [Route("$id")]
        [HttpGet]
        public async Task<IActionResult> ObterProdutoAsync(int id)
        {
            
            return Ok(await _servico.ObterProdutoAsync(id));
        }

        [Route("inserir/")]
        [HttpPost]
        public async Task<IActionResult> InserirProdutoAsync(Produto produto)
        {
           
            return Ok(await _servico.InserirProdutoAsync(produto));
        }

        [Route("atualizar/$id")]
        [HttpPut]
        public async Task<IActionResult> AtualizarProdutoAsync(int id, Produto produto)
        {
            return Ok(await _servico.AtualizarProdutoAsync(id, produto));
        }


        [Route("excluir/$id")]
        [HttpDelete]
        public async Task<IActionResult> ExcluirProdutoAsync(int id)
        {
            return Ok(await _servico.ExcluirProdutoAsync(id));
        }

    }
}
