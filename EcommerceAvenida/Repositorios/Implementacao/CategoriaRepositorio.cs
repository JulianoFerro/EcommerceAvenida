using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceAvenida.Dapper;
using EcommerceAvenida.Models;
using EcommerceAvenida.Repositorios.Interface;
using Dapper;

namespace EcommerceAvenida.Repositorios.Implementacao
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {

        private readonly Conexao _conexao;

        public CategoriaRepositorio(Conexao conexao)
        {
            _conexao = conexao;
        }

        public async Task<List<Categoria>> ObterTodasCategoriasAsync()
        {
            var sql = "SELECT * FROM TBLCATEGORIA WHERE ATIVO = @Ativo";
            return  (await _conexao.Connection.QueryAsync<Categoria>(sql, new { Ativo = 1 })).AsList();
        }
            public async Task<Categoria> ObterCategoriaAsync(int id)
        {
            var sql = "SELECT * FROM TBLCATEGORIA WHERE ATIVO = @Ativo AND ID = @Id";
            return await _conexao.Connection.QueryFirstOrDefaultAsync<Categoria>(sql, new { Ativo = 1, Id = id  });
        }
        public async Task<bool> InserirCategoriaAsync(Categoria categoria)
        {
            var resultado = true;

            var sql = "INSERT INTO TBLCATEGORIA (NOME, DESCRICAO, ATIVO) VALUES ( @Nome, @Descricao, @Ativo)";

            var parametros = new DynamicParameters();
            parametros.Add("Nome", categoria.Nome);
            parametros.Add("Descricao", categoria.Descricao);
            parametros.Add("Ativo", categoria.Ativo);
            
            var t = await _conexao.Connection.ExecuteAsync(sql, parametros);
            
            if ( t > 0)
                resultado = false;

            return resultado;
        }


        public async Task<bool> AtualizarCategoriaAsync(int id, Categoria categoria)
        {
            var resultado = true;

            var sql = "UPDATE TBLCATEGORIA  SET NOME = @Nome, SET DESCRICAO = @Descricao, SET ATIVO = @Ativo)";
            sql += "WHERE ID = @Id";
          
            var parametros = new DynamicParameters();
            parametros.Add("Nome", categoria.Nome);
            parametros.Add("Descricao", categoria.Descricao);
            parametros.Add("Ativo", categoria.Ativo);
            parametros.Add("Id", categoria.Id);

            var t = await _conexao.Connection.ExecuteAsync(sql, parametros);

            if (t < 0)
                resultado = false;

            return resultado;
        }

        public async Task<bool> ExcluirCategoriaAsync(int id)
        {
            var resultado = true;

            var sql = "DELETE FROM TBLCATEGORIA WHERE id = @Id";

            var t = await _conexao.Connection.ExecuteAsync(sql, new { Id = id });

            if (t < 0)
                resultado = false;

            return resultado;
        }
    }
}
