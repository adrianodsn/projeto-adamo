using System;
using System.Web.UI;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication
{
    public partial class PgFornecedor : PaginaBase
    {
        Fornecedor Fornecedor { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);

            Fornecedor = Uow.FornecedorRepository.Procurar(id);

            if (!IsPostBack)
            {
                litAcao.Text = "Novo fornecedor";

                if (Fornecedor != null)
                {
                    litAcao.Text = "Edição de fornecedor";

                    txtCnpj.Text = Fornecedor.Cnpj;
                    txtNome.Text = Fornecedor.Nome;
                    txtCnpj.Enabled = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var cnpj = txtCnpj.Text.Trim();
            var nome = txtNome.Text.Trim();

            if (Fornecedor == null)
            {
                Fornecedor = new Fornecedor(cnpj, nome);
                Uow.FornecedorRepository.Adicionar(Fornecedor);
            }
            else
            {
                Fornecedor.Set(cnpj, nome);
            }

            if (Fornecedor.Valid)
            {
                Uow.Commit();

                Response.Redirect("fornecedores.aspx");
            }
            else
            {
                ltvNotifications.DataSource = Fornecedor.Notifications;
                ltvNotifications.DataBind();
            }
        }
    }
}