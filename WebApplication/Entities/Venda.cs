using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace WebApplication.Entities
{
    public class Venda : Notifiable
    {
        public Venda()
        {
            ItensVenda = new HashSet<ItemVenda>();
        }

        public Venda(DateTime data, string cliente)
        {
            ItensVenda = new HashSet<ItemVenda>();

            Set(data, cliente);
        }

        public int Id { get; private set; }
        public DateTime Data { get; private set; }
        public string Cliente { get; private set; }

        public void Set(DateTime data, string cliente)
        {
            Data = data;
            Cliente = cliente;

            var dataMinima = DateTime.Now.AddYears(-120);
            var dataMaxima = DateTime.Now.AddYears(0);

            AddNotifications(new Contract()
                .Requires()
                .IsBetween(Data, dataMinima, dataMaxima, "Venda.Data", "Data inválida")
                .IsBetween(Cliente.Length, 3, 50, "Venda.Cliente", string.Format("O nome do cliente deve ter entre {0} e {1} caracteres.", 3, 50))
            );
        }

        public ICollection<ItemVenda> ItensVenda { get; set; }
    }
}