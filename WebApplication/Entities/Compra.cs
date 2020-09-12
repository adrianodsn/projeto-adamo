using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace WebApplication.Entities
{
    public class Compra : Notifiable
    {
        public Compra()
        {
            ItensCompra = new HashSet<ItemCompra>();
        }

        public Compra(DateTime data, Fornecedor fornecedor)
        {
            Set(data, fornecedor);
            ItensCompra = new HashSet<ItemCompra>();
        }

        public int Id { get; private set; }
        public DateTime Data { get; private set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; private set; }
        public ICollection<ItemCompra> ItensCompra { get; set; }

        public void Set(DateTime data, Fornecedor fornecedor)
        {
            Data = data;
            Fornecedor = fornecedor;

            var dataMinima = DateTime.Now.AddYears(-120);
            var dataMaxima = DateTime.Now.AddYears(0);

            AddNotifications(new Contract()
                .Requires()
                .IsBetween(Data, dataMinima, dataMaxima, "Compra.Data", "Data inválida")
            //.IsBetween(Fornecedor.Nome.Length, 3, 50, "Compra.Fornecedor", string.Format("O nome do cliente deve ter entre {0} e {1} caracteres.", 3, 50))
            );
        }
    }
}