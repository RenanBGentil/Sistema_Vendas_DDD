using SistemaVendas.DAL;
using SistemaVendas.Entidades;
using SistemaVendas.Helpers.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SistemaVendas.Helpers.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _banco;
        public CategoriaRepository(ApplicationDbContext banco)
        {
            _banco = banco;
        }
        public void Atualizar(Categoria categoria)
        {
            _banco.Update(categoria);
            _banco.SaveChanges();
        }

        public void Cadastrar(Categoria categoria)
        {
            _banco.Add(categoria);
            _banco.SaveChanges();
        }


        public void Excluir(int Id)
        {
            Categoria categoria = ObterCategoria(Id);
            _banco.Remove(categoria);
            _banco.SaveChanges();
        }

        public Categoria ObterCategoria(int Id)
        {
            return _banco.Categorias.Find(Id);
        }

        public IEnumerable<Categoria> ObterTodasCategorias()
        {
           return _banco.Categorias.ToList();
        }
    }
}
