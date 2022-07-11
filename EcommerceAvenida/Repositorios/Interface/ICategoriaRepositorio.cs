using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceAvenida.Models;

namespace EcommerceAvenida.Repositorios.Interface
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> ObterTodasCategoriasAsync();
        Task<Categoria> ObterCategoriaAsync(int id);
        Task<bool> InserirCategoriaAsync(Categoria categoria);
        Task<bool> AtualizarCategoriaAsync(int id, Categoria categoria);
        Task<bool> ExcluirCategoriaAsync(int id);
    }
}
