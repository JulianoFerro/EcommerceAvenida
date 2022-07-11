using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceAvenida.Models;
using EcommerceAvenida.Repositorios.Interface;
using EcommerceAvenida.Servicos.Interface;
using EcommerceAvenida.Validacao;

namespace EcommerceAvenida.Servicos.Implementacao
{
    public class CategoriaServico : ICategoriaServico
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaServico(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<bool> AtualizarCategoriaAsync(int id, Categoria categoria)
        {
            var resultado = true;

            try
            {
                resultado = await ValidaCategoria(categoria, resultado);

                if (!await _categoriaRepositorio.AtualizarCategoriaAsync(id, categoria))
                    resultado = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return resultado;

        }

        private static async Task<bool> ValidaCategoria(Categoria categoria, bool resultado)
        {
            var categoriasValidador = new CategoriaValidador();
            var resultadoValidador = await categoriasValidador.ValidateAsync(categoria);
            var erros = TrataErrosValidacao(resultadoValidador);

            if (erros.Count > 0)
                resultado = false;

            return resultado;
        }

        private static List<string> TrataErrosValidacao(FluentValidation.Results.ValidationResult resultadoValidador)
        {
            var erros = new List<string>();
            if (resultadoValidador.IsValid)
            {
                foreach (var erro in resultadoValidador.Errors)
                    erros.Add("Property " + erro.PropertyName + " failed validation. Error was: " + erro.ErrorMessage);
            }

            return erros;
        }

        public async Task<bool> ExcluirCategoriaAsync(int id)
        {
            var resultado = true;

            try
            {
                if (!await _categoriaRepositorio.ExcluirCategoriaAsync(id))
                    resultado = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return resultado;
        }

        public async Task<bool> InserirCategoriaAsync(Categoria categoria)
        {
            var resultado = true;

            try
            {
                resultado = await ValidaCategoria(categoria, resultado);

                if (!await _categoriaRepositorio.InserirCategoriaAsync(categoria))
                    resultado = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return resultado;
        }

        public async Task<Categoria> ObterCategoriaAsync(int id)
        {
            try
            {
                return await _categoriaRepositorio.ObterCategoriaAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Categoria>> ObterTodasCategoriasAsync()
        {
            try
            {
                return await _categoriaRepositorio.ObterTodasCategoriasAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
