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
    public class ServicoAplicacaoProduto : IServicoAplicacaoProduto
    {
        private readonly IServicoProduto _servicoProduto;
        public ServicoAplicacaoProduto(IServicoProduto servicoProduto)
        {
            _servicoProduto = servicoProduto;
        }

        public void Cadastrar(ProdutoViewModel produto)
        {
            Produto item = new Produto() {
                Codigo = produto.Codigo,
                Descricao = produto.Descricao,
                Quantidade = produto.Quantidade,
                Valor = (decimal)produto.Valor,
                CodigoCategoria = (int)produto.CodigoCategoria,
            };

            _servicoProduto.Cadastrar(item);
        }

        public ProdutoViewModel CarregarRegistro(int codigoProduto)
        {
            var registro = _servicoProduto.CarregarRegistros(codigoProduto);

            ProdutoViewModel produto = new ProdutoViewModel() {

                Codigo = registro.Codigo,
                Descricao = registro.Descricao,
                Quantidade = registro.Quantidade,
                Valor = (decimal)registro.Valor,
                CodigoCategoria = (int)registro.CodigoCategoria,
            };

            return produto;
        }

        public void Excluir(int Id)
        {
            _servicoProduto.Excluir(Id);
        }

        public IEnumerable<SelectListItem> ListaProdutosDropDownList()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();

            var lista = this.Listagem();

            foreach (var item in lista)
            {
                SelectListItem produto = new SelectListItem()
                {

                    Value = item.Codigo.ToString(),
                    Text = item.Descricao

                };
                retorno.Add(produto);
            }

            return retorno;
        }


        public IEnumerable<ProdutoViewModel> Listagem()
        {
            var lista = _servicoProduto.Listagem();
            List<ProdutoViewModel> listaProduto = new List<ProdutoViewModel>();

            foreach (var item in lista)
            {
                ProdutoViewModel produto = new ProdutoViewModel() {

                    Codigo = item.Codigo,
                    Valor = (decimal)item.Valor,
                    CodigoCategoria = (int)item.CodigoCategoria,
                     Quantidade = item.Quantidade,
                     Descricao = item.Descricao,
                     DescricaoCategoria = item.Categoria.Descricao
                };

                listaProduto.Add(produto);
            }

            return listaProduto;
        }
    }
}
