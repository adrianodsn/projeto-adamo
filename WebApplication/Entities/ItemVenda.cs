using Flunt.Notifications;
using Flunt.Validations;

namespace WebApplication.Entities
{
    public class ItemVenda : Notifiable
    {
        public ItemVenda() { }

        public ItemVenda( string produto, int qtd, decimal valorUnit)
        {
            Set(produto, qtd, valorUnit);
        }

        public int Id { get; set; }
        public int VendaId { get; set; }
        public Venda Venda { get; set; }
        public string Produto { get; set; }
        public int Qtd { get; set; }
        public decimal ValorUnit { get; set; }
        public bool Excluir { get; set; }
        public decimal Total => Qtd * ValorUnit;
        
        //public decimal Total {
        //    get
        //    {
        //        return Qtd * ValorUnit;
        //    }
        //}

        public void Set(string produto, int qtd, decimal valorUnit)
        {
            Produto = produto;
            Qtd = qtd;
            ValorUnit = valorUnit;

            if (Venda != null)
            {
                AddNotifications(Venda);
            }

            AddNotifications(new Contract()
                .Requires()
                .IsBetween(Produto.Length, 3, 50, "ItensVenda.Produto", string.Format("O nome do produto deve ter entre {0} e {1} caracteres.", 3, 50))
                .IsFalse(Venda == null, "ItemVenda.Venda", "A venda não pode ser nula.")
            );
        }
    }
}