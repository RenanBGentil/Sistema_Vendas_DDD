using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Dominio.Entidades;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public interface IServicoAplicacaoUsuario
    {
        bool ValidarLogin(string email, string senha);
        Usuario RetornarDadosDoUsuario(string email, string senha);
    }
}
