using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Models
{
    public class ProdutoViewModel
    {
        public int? Codigo { get; set; }

        [Required(ErrorMessage = "Preencha a Descrição do Produto")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o Valor do Produto")]
        [Range(0.1, Double.PositiveInfinity)]
        public decimal? Valor { get; set; }

        [Required(ErrorMessage = "Informe a Quantidade de Produtos em Estoque")]
        public double Quantidade { get; set; }

        [Required(ErrorMessage = "Informe a Categoria do Produto")]
        public int? CodigoCategoria { get; set; }

        public IEnumerable<SelectListItem> ListaCategorias { get; set; }

        public string DescricaoCategoria { get; set; }
    }
}
