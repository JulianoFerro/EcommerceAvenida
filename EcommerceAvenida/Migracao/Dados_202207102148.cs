using FluentMigrator;
using EcommerceAvenida.Models;

[Migration(202207102148)]
public class Dados_202207102148 : Migration
{
    public override void Down()
    {
        Delete.FromTable("TBLCATEGORIA")
            .AllRows();
    }

    public override void Up()
    {
        Insert.IntoTable("TBLCATEGORIA")
            .Row(new Categoria
            {
                Id = 1,
                Nome = "Eletrônico",
                Descricao = "Eletrodomésticos",
                Ativo = true
            });
        Insert.IntoTable("TBLCATEGORIA")
            .Row(new Categoria
            {
                Id = 2,
                Nome = "Informática",
                Descricao = "Produtos para Informática",
                Ativo = true
            });
        Insert.IntoTable("TBLCATEGORIA")
            .Row(new Categoria
            {
                Id = 3,
                Nome = "Celulares",
                Descricao = "Aparelhos e acessórios",
                Ativo = true
            });
        Insert.IntoTable("TBLCATEGORIA")
            .Row(new Categoria
            {
                Id = 4,
                Nome = "Moda",
                Descricao = "Artigos para vestuário em geral",
                Ativo = true
            });
        Insert.IntoTable("TBLCATEGORIA")
            .Row(new Categoria
            {
                Id = 5,
                Nome = "Livros",
                Descricao = "Livros ",
                Ativo = true
            }); 
        Insert.IntoTable("TBLPRODUTO")
             .Row(new Produto
             {
                 Id = 1,
                 Nome = "Teste",
                 Descricao = "Lorem Ipsum",
                 Ativo = true,
                 CategoriaId = 5
             });
    }
}