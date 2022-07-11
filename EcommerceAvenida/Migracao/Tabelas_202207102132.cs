using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAvenida.Migracao
{
    [Migration(202207102132)]
    public class Tabelas_202207102132 : Migration
    {
        public override void Down()
        {
            Delete.Table("tblCategoria");
            Delete.Table("tblProduto");
        }
        public override void Up()
        {
            Create.Table("tblCategoria")
                .WithColumn("Id").AsInt32().PrimaryKey()
                .WithColumn("Nome").AsString(255).NotNullable()
                .WithColumn("Descricao").AsString(255).NotNullable()
                .WithColumn("Ativo").AsByte().WithDefaultValue(1);
            Create.Table("tblProduto")
                .WithColumn("Id").AsInt32().PrimaryKey()
                .WithColumn("Nome").AsString(255).NotNullable()
                .WithColumn("Descricao").AsString(255).NotNullable()
                .WithColumn("Ativo").AsByte().WithDefaultValue(1)
                .WithColumn("CategoriaId").AsInt32().NotNullable().ForeignKey("tblCategoria", "Id");
        }
    }
}
