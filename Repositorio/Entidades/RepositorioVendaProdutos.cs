using Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using SistemaVendas.Dominio.DTO;
using SistemaVendas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Entidades
{
    public class RepositorioVendaProdutos : IRepositorioVendaProdutos
    {
        protected ApplicationDbContext DbSetContext;

        public RepositorioVendaProdutos(ApplicationDbContext context)
        {
            DbSetContext = context;
        }

        public IEnumerable<GraficoViewModel> ListaGrafico()
        {
            var lista = DbSetContext.VendaProdutos.Include(x=>x.Produto).GroupBy(x => x.CodigoProduto)
              .Select(y => new GraficoViewModel
              {

                  CodigoProduto = y.First().CodigoProduto,
                  Descricao = y.First().Produto.Descricao,
                  TotalVendido = y.Sum(z => z.Quantidade)

              }).ToList();
            return lista;
        }
    }
}
