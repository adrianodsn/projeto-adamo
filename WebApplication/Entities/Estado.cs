using Flunt.Notifications;
using Flunt.Validations;
using System.Collections.Generic;

namespace WebApplication.Entities
{
    public class Estado : Notifiable
    {
        public Estado()
        {
            Cidades = new HashSet<Cidade>();
        }

        public Estado(string nome, string sigla)
        {
            Set(nome, sigla);
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Sigla { get; private set; }

        public void Set(string nome, string sigla)
        {
            Nome = nome;
            Sigla = sigla;
            
            AddNotifications(new Contract()
                .Requires()
                .IsBetween(Nome.Length, 3, 50, "Estado.Nome", string.Format("O nome do estado deve ter entre {0} e {1} caracteres.", 3, 50))
                .IsTrue(Sigla.Length == 2, "Estado.Sigla", "A sigla do estado deve possuir 2 caracteres.")
            );
        }

        public ICollection<Cidade> Cidades { get; set; }
    }
}