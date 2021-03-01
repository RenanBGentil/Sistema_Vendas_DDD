using Aplicacao.Servico;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IServicoAplicacaoProduto _servicoAplicacaoProduto;
        private readonly IServicoAplicacaoCategoria _servicoAplicacaoCategoria;
        public ProdutoController(IServicoAplicacaoProduto servicoAplicacaoProduto, IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            _servicoAplicacaoProduto = servicoAplicacaoProduto;
            _servicoAplicacaoCategoria = servicoAplicacaoCategoria;

        }

        public IActionResult Index()
        {
            return View(_servicoAplicacaoProduto.Listagem()) ;
        }

        [HttpGet]
        public IActionResult Cadastro(int? Id)
        {
            ProdutoViewModel viewModel = new ProdutoViewModel();

            if(Id != null)
            {
               viewModel =  _servicoAplicacaoProduto.CarregarRegistro((int)Id);
            }

            viewModel.ListaCategorias = _servicoAplicacaoCategoria.ListaCategoriasDropDownList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                _servicoAplicacaoProduto.Cadastrar(entidade);
            }
            else
            {
                entidade.ListaCategorias = _servicoAplicacaoCategoria.ListaCategoriasDropDownList();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int Id)
        {
            _servicoAplicacaoProduto.Excluir(Id);
            return RedirectToAction("Index");
        }
    }
}
