using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceAvenida.Models;

namespace EcommerceAvenida.Servicos.Interface
{
    public interface IProdutoServico
    {
        Task<List<Produto>> ObterTodasProdutosAsync();
        Task<Produto> ObterProdutoAsync(int id);
        Task<bool> InserirProdutoAsync(Produto produto);
        Task<bool> AtualizarProdutoAsync(int id, Produto produto);
        Task<bool> ExcluirProdutoAsync(int id);
    }
}
