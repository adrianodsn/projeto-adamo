using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using WebApplication.Utils;

namespace WebApplication.Entities
{
    public class Produto : Notifiable
    {
        public Produto()
        {
            ItensCompra = new HashSet<ItemCompra>();
        }

        public Produto(string descricao, decimal valorUnitario, int qtdEstoque)
        {
            Set(descricao, valorUnitario, qtdEstoque);
        }

        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public int QtdEstoque { get; private set; }
        public ICollection<ItemCompra> ItensCompra { get; set; }

        public void Set(string descricao, decimal valorUnitario, int qtdEstoque)
        {
            Descricao = descricao;
            ValorUnitario = valorUnitario;
            QtdEstoque = qtdEstoque;

            AddNotifications(new Contract()
                .Requires()
                .IsBetween(Descricao.Length, 3, 50, "Produto.Descricao", string.Format("Descrição do produto deve ter entre {0} e {1} caracteres.", 3, 50))
            );
        }
    }
}