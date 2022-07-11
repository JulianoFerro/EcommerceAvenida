using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceAvenida.Migracao;

namespace EcommerceAvenida.Extensoes
{
    public static class GerenciadorMigracoes
    {
        public static IHost MigrarBanco(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var banco = scope.ServiceProvider.GetRequiredService<BancoDeDados>();
                var migracao = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                try
                {
                    banco.CreateDatabase("AvaliacaoSimpress");
                    migracao.ListMigrations();
                    migracao.MigrateUp();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            return host;
        }
    }
}
