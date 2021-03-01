using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Helpers;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class LoginController : Controller
    {
        private readonly IServicoAplicacaoUsuario servicoAplicacaoUsuario;
        protected IHttpContextAccessor httpContextAcessor;

        public LoginController(IServicoAplicacaoUsuario ServicoAplicacaoUsuario, IHttpContextAccessor mhttpContextAccessor)
        {
            servicoAplicacaoUsuario = ServicoAplicacaoUsuario;
            httpContextAcessor = mhttpContextAccessor;
        }

        public IActionResult Index(int? id)
        {
            if(id != null)
            {
                if(id == 0)
                {
                    httpContextAcessor.HttpContext.Session.Clear();
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            ViewData["ErroLogin"] = string.Empty;
            if (ModelState.IsValid) {

                var Senha = Criptografia.GetMd5Hash(model.Senha);
                bool login = servicoAplicacaoUsuario.ValidarLogin(model.Email, Senha);
                var usuario = servicoAplicacaoUsuario.RetornarDadosDoUsuario(model.Email, Senha);
                if(login)
                {
                    httpContextAcessor.HttpContext.Session.SetString(Sessao.NOME_USUARIO, usuario.Nome);
                    httpContextAcessor.HttpContext.Session.SetString(Sessao.EMAIL_USUARIO, usuario.Email);
                    httpContextAcessor.HttpContext.Session.SetInt32(Sessao.CODIGO_USUARIO, (int)usuario.Codigo);
                    httpContextAcessor.HttpContext.Session.SetInt32(Sessao.LOGADO_USUARIO, 1);
                    return RedirectToAction("Index", "Home");

    
                }
                else
                {
                    ViewData["ErroLogin"] = "O usuario ou senha não existe no sistema";
                    return View(model);
                }

            }
            else {
                return View();
            }
            
        }
    }
}
