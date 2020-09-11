using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using WebApplication.Utils;

namespace WebApplication.Entities
{
    public class Pessoa : Notifiable
    {
        public Pessoa()
        {
           
        }

        public Pessoa(string nome, string cpf, DateTime dataNascimento )
        {
            Set(nome, cpf, dataNascimento);
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }

        public DateTime DataNascimento { get; set; }

        public void Set(string nome, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;

            var dataNascimentoMinima = DateTime.Now.AddYears(-120);
            var dataNascimentoMaxima = DateTime.Now.AddYears(-12);

            AddNotifications(new Contract()
                .Requires()
                .IsBetween(Nome.Length, 3, 50, "Pessoa.Nome", string.Format("O nome da pessoa deve ter entre {0} e {1} caracteres.", 3, 50))
                .IsTrue(Cpf.IsCpf(), "Pessoa.Cpf","CPF Inválido")
                .IsBetween(DataNascimento, dataNascimentoMinima, dataNascimentoMaxima,"Pessoa.DataNascimento","Data Nascimento inválida")
            );
        }
    }
}