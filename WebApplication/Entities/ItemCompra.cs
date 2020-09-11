using Flunt.Notifications;
using Flunt.Validations;

namespace WebApplication.Entities
{
    public class ItemCompra : Notifiable
    {
        public ItemCompra() { }

        public ItemCompra(Produto produto, int qtd)
        {
            Set(produto, qtd);
        }

        public int Id { get; set; }
        public int CompraId { get; set; }
        public Compra Compra { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Qtd { get; set; }
        public bool Excluir { get; set; }
        //public decimal Total => Qtd * Produto.ValorUnitario;
   
        public decimal Total {
            get
            {
                if (Produto != null)
                {
                    return Qtd * Produto.ValorUnitario;
                }
                else {
                    return 0;
                }
            }
        }

        public void Set(Produto produto, int qtd)
        {
            Produto = produto;
            Qtd = qtd;

            if (Compra != null)
            {
                AddNotifications(Compra);
            }

            AddNotifications(new Contract()
                .Requires()
                //.IsBetween(Produto.Descricao.Length, 3, 50, "ItensCompra.Produto", string.Format("O nome do produto deve ter entre {0} e {1} caracteres.", 3, 50))
                .IsFalse(Compra == null, "ItensCompra.Compra", "A venda não pode ser nula.")
            );
        }
    }
}