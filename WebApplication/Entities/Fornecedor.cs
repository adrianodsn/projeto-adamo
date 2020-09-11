using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using WebApplication.Utils;

namespace WebApplication.Entities
{
    public class Fornecedor : Notifiable
    {
        public Fornecedor()
        {
            Compras = new HashSet<Compra>();
        }

        public Fornecedor(string cnpj, string nome)
        {
            Set(cnpj, nome);
        }

        public int Id { get; private set; }
        public string Cnpj { get; private set; }
        public string Nome { get; private set; }
        public ICollection<Compra> Compras { get; set; }

        public void Set(string cnpj, string nome)
        {
            Cnpj = cnpj;
            Nome = nome;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Cnpj.IsCnpj(), "Fornecedor.Cnpj", "CNPJ Inválido")
                .IsBetween(Nome.Length, 3, 50, "Fornecedor.Nome", string.Format("Nome do fornecedor deve ter entre {0} e {1} caracteres.", 3, 50))
            );
        }
    }
}