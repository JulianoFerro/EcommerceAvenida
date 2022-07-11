
using System.Collections.Generic;

namespace EcommerceAvenida.Models
{

    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int CategoriaId { get; set; }

    }
}