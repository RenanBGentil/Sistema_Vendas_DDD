namespace SistemaVendas.Dominio.Entidades
{
    public class VendaProdutos
    {
        public int CodigoVenda { get; set; }

        public int CodigoProduto { get; set; }

        public double Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal ValorTotal { get; set; }

        public Venda Venda { get; set; }

        public Produto Produto { get; set; }
    }
}
