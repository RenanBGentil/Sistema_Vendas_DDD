using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Informe Seu Email !")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Informe Sua Senha !")]
        public string Senha { get; set; }
    }
}
