using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Repositorios
{
    public interface IRepositorio<TEntidade> where TEntidade : class
    {
        void Create(TEntidade Entity);
        TEntidade Read(int id);
        void Delete(int Id);
        IEnumerable<TEntidade> Read();
    }
}
