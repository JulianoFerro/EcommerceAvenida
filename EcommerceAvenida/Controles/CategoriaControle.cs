using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EcommerceAvenida.Models;

namespace EcommerceAvenida.Controles
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaControle : ControllerBase
    {

        private readonly Servicos.Interface.ICategoriaServico _servico;

        public CategoriaControle(Servicos.Interface.ICategoriaServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodasCategoriasAsync()
        {
            return Ok(await _servico.ObterTodasCategoriasAsync());
        }

        [Route("$id")]
        [HttpGet]
        public async Task<IActionResult> ObterCategoriaAsync(int id)
        {
            
            return Ok(await _servico.ObterCategoriaAsync(id));
        }

        [Route("inserir/")]
        [HttpPost]
        public async Task<IActionResult> InserirCategoriaAsync(Categoria categoria)
        {
           
            return Ok(await _servico.InserirCategoriaAsync(categoria));
        }

        [Route("atualizar/$id")]
        [HttpPut]
        public async Task<IActionResult> AtualizarCategoriaAsync(int id, Categoria categoria)
        {
            return Ok(await _servico.AtualizarCategoriaAsync(id, categoria));
        }


        [Route("excluir/$id")]
        [HttpDelete]
        public async Task<IActionResult> ExcluirCategoriaAsync(int id)
        {
            return Ok(await _servico.ExcluirCategoriaAsync(id));
        }

    }
}
