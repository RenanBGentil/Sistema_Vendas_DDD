using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio
{
    public interface IRepositorio<TEntidade> where TEntidade : class
    {
        void Create(TEntidade Entity);
        TEntidade Read(int id);
        void Delete(int Id);
        IEnumerable<TEntidade> Read();
    }
}
