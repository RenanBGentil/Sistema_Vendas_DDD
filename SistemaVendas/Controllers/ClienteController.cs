using Aplicacao.Servico;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IServicoAplicacaoCliente _servicoAplicacaoCliente;
        public ClienteController(IServicoAplicacaoCliente servicoAplicacaoCliente)
        {
            _servicoAplicacaoCliente = servicoAplicacaoCliente;

        }

        public IActionResult Index()
        {
            return View(_servicoAplicacaoCliente.Listagem()) ;
        }

        [HttpGet]
        public IActionResult Cadastro(int? Id)
        {
            ClienteViewModel viewModel = new ClienteViewModel();

            if(Id != null)
            {
               viewModel =  _servicoAplicacaoCliente.CarregarRegistro((int)Id);
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ClienteViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                _servicoAplicacaoCliente.Cadastrar(entidade);
            }
            else
            {
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int Id)
        {
            _servicoAplicacaoCliente.Excluir(Id);
            return RedirectToAction("Index");
        }
    }
}
