using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceAvenida.Dapper;

namespace EcommerceAvenida.Migracao
{
    public class BancoDeDados
    {

        private readonly Conexao _conexao;
        public BancoDeDados(Conexao conexao)
        {
            _conexao = conexao;
        }
        public void CreateDatabase(string Nome)
        {
            var sql = "SELECT * FROM sys.databases WHERE name = @name";

            var parametros = new DynamicParameters();
            parametros.Add("name", Nome);


            var records = _conexao.Connection.Query(sql, parametros);

            if (!records.Any())
                _conexao.Connection.Execute($"CREATE DATABASE {Nome}");
        }
    }
}
