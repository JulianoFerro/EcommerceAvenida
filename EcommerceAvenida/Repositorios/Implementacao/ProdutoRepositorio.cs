using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceAvenida.Dapper;
using EcommerceAvenida.Models;
using EcommerceAvenida.Repositorios.Interface;
using Dapper;

namespace EcommerceAvenida.Repositorios.Implementacao
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {

        private readonly Conexao _conexao;

        public ProdutoRepositorio(Conexao conexao)
        {
            _conexao = conexao;
        }

        public async Task<List<Produto>> ObterTodasProdutosAsync()
        {

            var sql = "SELECT * FROM TBLPRODUTO WHERE ATIVO = @Ativo";
            return  (await _conexao.Connection.QueryAsync<Produto>(sql, new { Ativo = 1 })).AsList();
        }
            public async Task<Produto> ObterProdutoAsync(int id)
        {
            var sql = "SELECT * FROM TBLPRODUTO WHERE ATIVO = @Ativo AND ID = @Id";
            return await _conexao.Connection.QueryFirstOrDefaultAsync<Produto>(sql, new { Ativo = 1, Id = id  });
        }
        public async Task<bool> InserirProdutoAsync(Produto produto)
        {
            var resultado = true;

            var sql = "INSERT INTO TBLPRODUTO (NOME, DESCRICAO, ATIVO, CATEGORIAID) VALUES ( @Nome, @Descricao, @Ativo, @CategoriaId)";

            var parametros = new DynamicParameters();
            parametros.Add("Nome", produto.Nome);
            parametros.Add("Descricao", produto.Descricao);
            parametros.Add("Ativo", produto.Ativo);
            parametros.Add("CategoriaId", produto.CategoriaId);

            
            var t = await _conexao.Connection.ExecuteAsync(sql, parametros);
            
            if ( t > 0)
                resultado = false;

            return resultado;
        }


        public async Task<bool> AtualizarProdutoAsync(int id, Produto produto)
        {
            var resultado = true;

            var sql = "UPDATE TBLPRODUTO  SET NOME = @Nome, SET DESCRICAO = @Descricao, SET ATIVO = @Ativo, SET CATEGORIAID = @CategoriaId)";
            sql += "WHERE ID = @Id";
          
            var parametros = new DynamicParameters();
            parametros.Add("Nome", produto.Nome);
            parametros.Add("Descricao", produto.Descricao);
            parametros.Add("Ativo", produto.Ativo);
            parametros.Add("Id", produto.Id);
            parametros.Add("CategoriaId", produto.CategoriaId);

            var t = await _conexao.Connection.ExecuteAsync(sql, parametros);

            if (t < 0)
                resultado = false;

            return resultado;
        }

        public async Task<bool> ExcluirProdutoAsync(int id)
        {
            var resultado = true;

            var sql = "DELETE FROM TBLPRODUTO WHERE id = @Id";

            var t = await _conexao.Connection.ExecuteAsync(sql, new { Id = id });

            if (t < 0)
                resultado = false;

            return resultado;
        }

    }
}
