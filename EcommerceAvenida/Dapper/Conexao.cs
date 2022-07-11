using Npgsql;
using System;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceAvenida.Dapper
{
    public sealed class Conexao : IDisposable
    {
        private readonly Guid _id;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public Conexao(string connectionString)
        {
            _id = Guid.NewGuid();
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }

}
