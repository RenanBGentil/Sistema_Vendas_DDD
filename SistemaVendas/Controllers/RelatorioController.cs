using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Servico;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly IServicoAplicacaoVenda ServicoAplicacaoVenda;  
        public RelatorioController(IServicoAplicacaoVenda servicoAplicacaoVenda)
        {
            ServicoAplicacaoVenda = servicoAplicacaoVenda;
        }

        public IActionResult Grafico()
        {
            var lista = ServicoAplicacaoVenda.ListaGrafico().ToList();

            string valores = string.Empty;
            string labels = string.Empty;
            string cores = string.Empty;

        var random = new Random();
            for (int i = 0; i < lista.Count; i++)
            {
                valores += lista[i].TotalVendido.ToString() + ",";
                labels += "'" + lista[i].Descricao.ToString() + "', ";
                cores += "'" + string.Format("#{0:x6}", random.Next(0x1000000)) + "', ";
            }

            ViewBag.Valores = valores;
            ViewBag.Labels = labels;
            ViewBag.Cores = cores;

            return View();
        }
    }
}
