using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceAvenida.Models;

namespace EcommerceAvenida.Repositorios.Interface
{
    public interface IProdutoRepositorio
    {
        Task<List<Produto>> ObterTodasProdutosAsync();
        Task<Produto> ObterProdutoAsync(int id);
        Task<bool> InserirProdutoAsync(Produto categoria);
        Task<bool> AtualizarProdutoAsync(int id, Produto categoria);
        Task<bool> ExcluirProdutoAsync(int id);
    }
}
