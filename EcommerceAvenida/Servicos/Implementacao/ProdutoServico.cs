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
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task<bool> AtualizarProdutoAsync(int id, Produto produto)
        {
            var resultado = true;

            try
            {
                resultado = await ValidaProduto(produto, resultado);

                if (!await _produtoRepositorio.AtualizarProdutoAsync(id, produto))
                    resultado = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return resultado;

        }

        private static async Task<bool> ValidaProduto(Produto produto, bool resultado)
        {
            var produtosValidador = new ProdutoValidador();
            var resultadoValidador = await produtosValidador.ValidateAsync(produto);
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

        public async Task<bool> ExcluirProdutoAsync(int id)
        {
            var resultado = true;

            try
            {
                if (!await _produtoRepositorio.ExcluirProdutoAsync(id))
                    resultado = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return resultado;
        }

        public async Task<bool> InserirProdutoAsync(Produto produto)
        {
            var resultado = true;

            try
            {
                resultado = await ValidaProduto(produto, resultado);

                if (!await _produtoRepositorio.InserirProdutoAsync(produto))
                    resultado = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return resultado;
        }

        public async Task<Produto> ObterProdutoAsync(int id)
        {
            try
            {
                return await _produtoRepositorio.ObterProdutoAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Produto>> ObterTodasProdutosAsync()
        {
            try
            {
                return await _produtoRepositorio.ObterTodasProdutosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
