using SistemaVendas.Entidades;
using System.Collections.Generic;

namespace SistemaVendas.Helpers.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        Categoria ObterCategoria(int Id);
        IEnumerable<Categoria> ObterTodasCategorias();
        void Cadastrar(Categoria categoria);
        void Atualizar(Categoria categoria);
        void Excluir(int Id);
    }
}
