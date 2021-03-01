using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Models
{
    public class CategoriaViewModel
    {
        public int? Codigo { get; set; }

        [Required(ErrorMessage ="Preencha a Descrição")]
        public string Descricao { get; set; }
    }
}
