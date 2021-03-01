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
    public class ServicoAplicacaoCategoria : IServicoAplicacaoCategoria
    {
        private readonly IServicoCategoria _servicoCategoria;
        public ServicoAplicacaoCategoria(IServicoCategoria servicoCategoria)
        {
            _servicoCategoria = servicoCategoria;
        }

        public void Cadastrar(CategoriaViewModel categoria)
        {
            Categoria item = new Categoria() {

                Codigo = categoria.Codigo,
                Descricao = categoria.Descricao,
            
            };

            _servicoCategoria.Cadastrar(item);
        }

        public CategoriaViewModel CarregarRegistro(int codigoCategoria)
        {
            var registro = _servicoCategoria.CarregarRegistros(codigoCategoria);

            CategoriaViewModel categoria = new CategoriaViewModel() { 
                
                Codigo = registro.Codigo,
                Descricao = registro.Descricao
            };

            return categoria;
        }

        public void Excluir(int Id)
        {
            _servicoCategoria.Excluir(Id);
        }

        public IEnumerable<SelectListItem> ListaCategoriasDropDownList()
        {
            List<SelectListItem> retorno = new  List<SelectListItem>();

            var lista = this.Listagem();

            foreach (var item in lista)
            {
                SelectListItem categoria = new SelectListItem() {

                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                
                };
                retorno.Add(categoria);
            }

            return retorno;
        }

        public IEnumerable<CategoriaViewModel> Listagem()
        {
            var lista = _servicoCategoria.Listagem();
            List<CategoriaViewModel> listaCategoria = new List<CategoriaViewModel>();

            foreach (var item in lista)
            {
                CategoriaViewModel categoria = new CategoriaViewModel() {

                    Codigo = item.Codigo,
                    Descricao = item.Descricao

                };
                listaCategoria.Add(categoria);
            }

            return listaCategoria;
        }
    }
}
