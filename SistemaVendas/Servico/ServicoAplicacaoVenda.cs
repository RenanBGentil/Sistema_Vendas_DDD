using Dominio.Interfaces;
using SistemaVendas.Dominio.Entidades;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoVenda : IServicoAplicacaoVenda
    {
        private readonly IServicoVenda _servicoVenda;
        public ServicoAplicacaoVenda(IServicoVenda servicoVenda)
        {
            _servicoVenda = servicoVenda;
        }

        public void Cadastrar(VendaViewModel venda)
        {
            Venda item = new Venda() {

                Codigo = venda.Codigo,
                Data = (DateTime)venda.Data,
                CodigoCliente = (int)venda.CodigoCliente,
                 Total = venda.Total,
            };

            _servicoVenda.Cadastrar(item);
        }

        public VendaViewModel CarregarRegistro(int codigoVenda)
        {
            var registro = _servicoVenda.CarregarRegistros(codigoVenda);

            VendaViewModel venda = new VendaViewModel() {

                Codigo = registro.Codigo,
                Data = (DateTime)registro.Data,
                CodigoCliente = (int)registro.CodigoCliente,
                Total = registro.Total,
            };

            return venda;
        }

        public void Excluir(int Id)
        {
            _servicoVenda.Excluir(Id);
        }

        public IEnumerable<VendaViewModel> Listagem()
        {
            var lista = _servicoVenda.Listagem();
            List<VendaViewModel> listaVenda = new List<VendaViewModel>();

            foreach (var item in lista)
            {
                VendaViewModel venda = new VendaViewModel() {

                    Codigo = item.Codigo,
                    Data = (DateTime)item.Data,
                    CodigoCliente = (int)item.CodigoCliente,
                    Total = item.Total,
                };
                listaVenda.Add(venda);
            }

            return listaVenda;
        }

        public IEnumerable<GraficoViewModel> ListaGrafico()
        {
            List<GraficoViewModel> lista = new List<GraficoViewModel>();
            var aux =  _servicoVenda.ListaGrafico();

            foreach (var item in aux)
            {
                GraficoViewModel graficoViewModel = new GraficoViewModel()
                {
                    CodigoProduto = item.CodigoProduto,
                    Descricao = item.Descricao,
                    TotalVendido = item.TotalVendido
                };

                lista.Add(graficoViewModel);
            }

            return lista;
        }
    }
}
