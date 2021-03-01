using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using SistemaVendas.Dominio.Entidades;

namespace Repositorio.Entidades
{
    public class RepositorioProduto : Repositorio<Produto>, IRepositorioProduto
    {
        public RepositorioProduto(ApplicationDbContext dbContext) : base(dbContext){ }

        public override IEnumerable<Produto> Read()
        {
            return DbSetContex.Include(x => x.Categoria).AsNoTracking().ToList();
        }
    }
}
