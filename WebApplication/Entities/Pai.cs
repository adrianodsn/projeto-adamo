using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace WebApplication.Entities
{
    public class Pai : Notifiable
    {
        public Pai()
        {
            Filhos = new HashSet<Filho>();
        }

        public Pai(string nomePai, string nomeMae)
        {
            Set(nomePai, nomeMae);
            Filhos = new HashSet<Filho>();
        }

        public int Id { get; private set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public ICollection<Filho> Filhos { get; set; }

        public void Set(string nomePai, string nomeMae)
        {
            NomePai = nomePai;
            NomeMae = NomeMae;

            AddNotifications(new Contract()
                .Requires()
                .IsBetween(NomePai.Length, 3, 50, "Pai.NomePai", string.Format("O nome do pai deve ter entre {0} e {1} caracteres.", 3, 50))
                .IsBetween(nomeMae.Length, 3, 50, "Pai.NomeMae", string.Format("O nome da mãe deve ter entre {0} e {1}caracteres.", 3, 50))
            );
        }
    }
}