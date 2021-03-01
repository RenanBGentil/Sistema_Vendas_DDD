using SistemaVendas.Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Repositorios
{
    public interface IRepositorioVendaProdutos
    {
        IEnumerable<GraficoViewModel> ListaGrafico();
    }
}
