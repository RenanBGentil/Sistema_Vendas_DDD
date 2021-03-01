using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using SistemaVendas.Dominio.Entidades;

namespace Repositorio.Entidades
{
    public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(ApplicationDbContext dbContext) : base(dbContext){ }

        public bool ValidarLogin(string email, string senha)
        {
            var usuario = DbSetContex.Where(x => x.Email == email && x.Senha.ToUpper() == senha.ToUpper()).FirstOrDefault();
            return (usuario == null) ? false : true;
        }
    }
}
