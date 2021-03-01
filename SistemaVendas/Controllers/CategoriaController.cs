using Aplicacao.Servico;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly IServicoAplicacaoCategoria _servicoAplicacaoCategoria;
        public CategoriaController(IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            _servicoAplicacaoCategoria = servicoAplicacaoCategoria;

        }

        public IActionResult Index()
        {
            return View(_servicoAplicacaoCategoria.Listagem()) ;
        }

        [HttpGet]
        public IActionResult Cadastro(int? Id)
        {
            CategoriaViewModel viewModel = new CategoriaViewModel();

            if(Id != null)
            {
               viewModel =  _servicoAplicacaoCategoria.CarregarRegistro((int)Id);
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(CategoriaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                _servicoAplicacaoCategoria.Cadastrar(entidade);
            }
            else
            {
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int Id)
        {
            _servicoAplicacaoCategoria.Excluir(Id);
            return RedirectToAction("Index");
        }
    }
}
