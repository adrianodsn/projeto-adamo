using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace WebApplication.Entities
{
    public class Filho : Notifiable
    {
        public Filho() { }

        public Filho(string nomeFilho, DateTime dataNasc)
        {
            Set(nomeFilho, dataNasc);
        }

        public int Id { get; set; }
        public int PaiId { get; set; }
        public Pai Pai { get; set; }
        public string NomeFilho { get; set; }
        public DateTime DataNasc { get; set; }
        public bool Excluir { get; set; }

        public void Set(string nomeFilho, DateTime dataNasc)
        {
            NomeFilho = nomeFilho;
            DataNasc = dataNasc;

            if (Pai != null)
            {
                AddNotifications(Pai);
            }

            AddNotifications(new Contract()
                .Requires()
                //.IsBetween(Produto.Descricao.Length, 3, 50, "ItensCompra.Produto", string.Format("O nome do produto deve ter entre {0} e {1} caracteres.", 3, 50))
                .IsFalse(Pai == null, "Filho.Pai", "O pai não pode ser nulo.")
            );
        }
    }
}