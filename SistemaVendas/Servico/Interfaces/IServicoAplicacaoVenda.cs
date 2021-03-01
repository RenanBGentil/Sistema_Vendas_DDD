using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public interface IServicoAplicacaoVenda
    {

        IEnumerable<GraficoViewModel> ListaGrafico();

        IEnumerable<VendaViewModel> Listagem();

        VendaViewModel CarregarRegistro(int codigoVenda);

        void Cadastrar(VendaViewModel venda);

        void Excluir(int Id);
    }
}
