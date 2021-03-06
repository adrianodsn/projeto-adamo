﻿using Flunt.Notifications;
using Flunt.Validations;

namespace WebApplication.Entities
{
    public class Cidade : Notifiable
    {
        public Cidade() { }

        public Cidade(Estado estado, string nome, int codigoTom)
        {
            Set(estado, nome, codigoTom);
        }

        public int Id { get; set; }
        public int EstadoId { get; set; }
        public string Nome { get; set; }
        public int CodigoTom { get; set; }
        public bool Excluir { get; set; }

        public void Set(Estado estado, string nome, int codigoTom)
        {
            Estado = estado;
            Nome = nome;
            CodigoTom = codigoTom;

            if (Estado != null)
            {
                AddNotifications(Estado);
            }

            AddNotifications(new Contract()
                .Requires()
                .IsBetween(Nome.Length, 3, 50, "Cidade.Nome", string.Format("O nome da cidade deve ter entre {0} e {1} caracteres.", 3, 50))
                .IsFalse(Estado == null, "Cidade.Estado", "O estado não pode ser nulo.")
            );
        }

        public Estado Estado { get; set; }
    }
}