using System;
using System.Web.UI;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication
{
    public partial class PgFornecedor : Page
    {
        ApContext DB = new ApContext();
        Fornecedor Fornecedor { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);

            Fornecedor = DB.Fornecedores.Find(id);

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
                DB.Fornecedores.Add(Fornecedor);
            }
            else
            {
                Fornecedor.Set(cnpj, nome);
            }

            if (Fornecedor.Valid)
            {
                DB.SaveChanges();

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