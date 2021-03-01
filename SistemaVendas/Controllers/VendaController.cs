using Aplicacao.Servico;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class VendaController : Controller
    {
        private readonly IServicoAplicacaoVenda _servicoAplicacaoVenda;
        private readonly IServicoAplicacaoProduto _servicoAplicacaoProduto;
        private readonly IServicoAplicacaoCliente _servicoAplicacaoCliente;
        public VendaController(IServicoAplicacaoVenda servicoAplicacaoVenda, IServicoAplicacaoCliente servicoAplicacaoCliente,
            IServicoAplicacaoProduto servicoAplicacaoProduto)
        {
            _servicoAplicacaoVenda = servicoAplicacaoVenda;
            _servicoAplicacaoCliente = servicoAplicacaoCliente;
            _servicoAplicacaoProduto = servicoAplicacaoProduto;

        }

        public IActionResult Index()
        {
            return View(_servicoAplicacaoVenda.Listagem()) ;
        }

        [HttpGet]
        public IActionResult Cadastro(int? Id)
        {
           VendaViewModel viewModel = new VendaViewModel();

            if(Id != null)
            {
               viewModel =  _servicoAplicacaoVenda.CarregarRegistro((int)Id);
            }

            viewModel.ListaClientes = _servicoAplicacaoCliente.ListaClientesDropDownList();
            viewModel.ListaProdutos = _servicoAplicacaoProduto.ListaProdutosDropDownList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(VendaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                _servicoAplicacaoVenda.Cadastrar(entidade);
            }
            else
            {
                entidade.ListaClientes = _servicoAplicacaoCliente.ListaClientesDropDownList();
                entidade.ListaProdutos = _servicoAplicacaoProduto.ListaProdutosDropDownList();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int Id)
        {
            _servicoAplicacaoVenda.Excluir(Id);
            //_servicoAplicacaoProduto.Excluir(Id);
            return RedirectToAction("Index");
        }

        [HttpGet("LerValorProduto/{CodigoProduto}")]
        public decimal LerValorProduto(int CodigoProduto)
        {
            return (decimal)_servicoAplicacaoProduto.CarregarRegistro(CodigoProduto).Valor;
        }
    }
}
