using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Models
{
    public class ClienteViewModel
    {
        public int? Codigo { get; set; }

        [Required(ErrorMessage = "Preencha o Nome do Cliente")]
        public string Nome { get; set; }       
        
        [Required(ErrorMessage = "Preencha o CNPJ/CPF do Cliente")]
        public string CNPJ_CPF { get; set; }

        [Required(ErrorMessage = "Preencha o Email do Cliente")]
        public string Email { get; set; }           
        
        [Required(ErrorMessage = "Preencha o Celular do Cliente")]
        public string Celular { get; set; }
    }
}
