using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendas.Dominio.Entidades
{
    public class Venda: EntityBase
    {
        public DateTime Data { get; set; }

        [ForeignKey("Cliente")]
        public int CodigoCliente { get; set; }

        public decimal Total{ get; set; }

        public Cliente Cliente { get; set; }

        public ICollection<VendaProdutos> Produtos { get; set; }
    }
}
