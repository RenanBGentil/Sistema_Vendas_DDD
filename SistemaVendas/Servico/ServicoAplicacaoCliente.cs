using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Dominio.Entidades;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoCliente : IServicoAplicacaoCliente
    {
        private readonly IServicoCliente _servicoCliente;
        public ServicoAplicacaoCliente(IServicoCliente servicoCliente)
        {
            _servicoCliente = servicoCliente;
        }

        public void Cadastrar(ClienteViewModel cliente)
        {
            Cliente item = new Cliente() {

                Codigo = cliente.Codigo,
                Celular = cliente.Celular,
                CNPJ_CPF = cliente.CNPJ_CPF,
                Email = cliente.Email,
                Nome = cliente.Nome
            };

            _servicoCliente.Cadastrar(item);
        }

        public ClienteViewModel CarregarRegistro(int codigoProduto)
        {
            var registro = _servicoCliente.CarregarRegistros(codigoProduto);

            ClienteViewModel cliente = new ClienteViewModel() { 
                
                Codigo = registro.Codigo,
                Nome = registro.Nome,
                Email = registro.Email,
                CNPJ_CPF = registro.CNPJ_CPF,
                Celular = registro.Celular
            };

            return cliente;
        }

        public void Excluir(int Id)
        {
            _servicoCliente.Excluir(Id);
        }

        public IEnumerable<SelectListItem> ListaClientesDropDownList()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();

            var lista = this.Listagem();

            foreach (var item in lista)
            {
                SelectListItem cliente = new SelectListItem()
                {

                    Value = item.Codigo.ToString(),
                    Text = item.Nome

                };
                retorno.Add(cliente);
            }

            return retorno;
        }

        public IEnumerable<ClienteViewModel> Listagem()
        {
            var lista = _servicoCliente.Listagem();
            List<ClienteViewModel> listaCliente = new List<ClienteViewModel>();

            foreach (var item in lista)
            {
                ClienteViewModel cliente= new ClienteViewModel() {

                    Codigo = item.Codigo,
                    Celular = item.Celular,
                    CNPJ_CPF = item.CNPJ_CPF,
                    Email = item.Email,
                    Nome = item.Nome
                };
                listaCliente.Add(cliente);
            }

            return listaCliente;
        }
    }
}
