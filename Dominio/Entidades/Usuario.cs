using Dominio.Entidades;
using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Dominio.Entidades
{
    public class Usuario: EntityBase
    {

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

    }
}
