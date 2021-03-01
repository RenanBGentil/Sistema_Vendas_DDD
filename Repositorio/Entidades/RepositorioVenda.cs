using Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using SistemaVendas.Dominio.Entidades;
using System.Linq;

namespace Repositorio.Entidades
{
    public class RepositorioVenda : Repositorio<Venda>, IRepositorioVenda
    {
        public RepositorioVenda(ApplicationDbContext dbContext) : base(dbContext){ }

        public override void Delete(int Id)
        {
            var listaProdutos = DbSetContex.Include(x => x.Produtos).Where(y => y.Codigo == Id).AsNoTracking().ToList();

            VendaProdutos vendaProdutos;
            foreach (var item in listaProdutos[0].Produtos)
            {
                vendaProdutos= new VendaProdutos();  
                vendaProdutos.CodigoVenda = Id;
                vendaProdutos.CodigoProduto = item.CodigoProduto;

                DbSet<VendaProdutos> DbSetAux;
                DbSetAux = Db.Set<VendaProdutos>();
                DbSetAux.Attach(vendaProdutos);
                DbSetAux.Remove(vendaProdutos);
                Db.SaveChanges();
            }


            base.Delete(Id);
        }
    }
}
