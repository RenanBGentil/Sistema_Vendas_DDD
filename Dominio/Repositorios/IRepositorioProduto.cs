using SistemaVendas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Repositorios
{
    public interface IRepositorioProduto : IRepositorio<Produto>
    {
         new IEnumerable<Produto> Read();
    }
}
