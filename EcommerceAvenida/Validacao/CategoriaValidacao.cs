
using FluentValidation;
using EcommerceAvenida.Models;

namespace EcommerceAvenida.Validacao
{

    public class CategoriaValidador: AbstractValidator<Categoria>
    {
        public CategoriaValidador()
        {
            RuleFor(categoria => categoria.Nome).NotEmpty().MinimumLength(2);
            RuleFor(categoria => categoria.Descricao).NotEmpty().MinimumLength(2);
        }
    }
}
