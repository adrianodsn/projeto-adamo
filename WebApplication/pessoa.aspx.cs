using System;
using WebApplication.Entities;

namespace WebApplication
{
    public partial class PgPessoa : PaginaBase
    {
        Pessoa Pessoa { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);

            Pessoa = Uow.PessoaRepository.Procurar(id);

            if (!IsPostBack)
            {
                litAcao.Text = "Nova pessoa";

                if (Pessoa != null)
                {
                    litAcao.Text = "Edição de pessoa";

                    txtNome.Text = Pessoa.Nome;
                    txtCpf.Text = Pessoa.Cpf;
                    txtDataNasc.Text = Pessoa.DataNascimento.ToString("yyyy-MM-dd");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var nome = txtNome.Text.Trim();
            var cpf = txtCpf.Text.Trim();
            var dataNascimento = txtDataNasc.Text.Trim();

            if (Pessoa == null)
            {
                Pessoa = new Pessoa(nome, cpf, Convert.ToDateTime(dataNascimento));
                Uow.PessoaRepository.Adicionar(Pessoa);
            }
            else
            {
                Pessoa.Set(nome, cpf, Convert.ToDateTime(dataNascimento));
            }

            if (Pessoa.Valid)
            {
                Uow.Commit();

                Response.Redirect("pessoas.aspx");
            }
            else
            {
                ltvNotifications.DataSource = Pessoa.Notifications;
                ltvNotifications.DataBind();
            }
        }
    }
}