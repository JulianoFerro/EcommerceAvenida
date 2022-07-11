
using FluentValidation;
using EcommerceAvenida.Models;

namespace EcommerceAvenida.Validacao
{

    public class ProdutoValidador: AbstractValidator<Produto>
    {
        public ProdutoValidador()
        {
            RuleFor(produto => produto.Nome).NotEmpty().MinimumLength(2);
            RuleFor(produto => produto.Descricao).NotEmpty().MinimumLength(2);
        }
    }
}
