using SistemaVendas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Repositorios
{
    public interface IRepositorioVenda : IRepositorio<Venda>
    {
        new void Delete(int Id);
    }
}
