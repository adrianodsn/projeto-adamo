using System;
using System.Web.UI;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication
{
    public partial class PgEstado : Page
    {
        ApContext DB = new ApContext();
        Estado Estado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);

            Estado = DB.Estados.Find(id);

            if (!IsPostBack)
            {
                litAcao.Text = "Novo estado";

                if (Estado != null)
                {
                    litAcao.Text = "Edição de estado";

                    txtNome.Text = Estado.Nome;
                    txtSigla.Text = Estado.Sigla;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var nome = txtNome.Text.Trim();
            var sigla = txtSigla.Text.Trim();

            if (Estado == null)
            {
                Estado = new Estado(nome, sigla);
                DB.Estados.Add(Estado);
            }
            else
            {
                Estado.Set(nome, sigla);
            }

            if (Estado.Valid)
            {
                DB.SaveChanges();

                Response.Redirect("estados.aspx");
            }
            else
            {
                ltvNotifications.DataSource = Estado.Notifications;
                ltvNotifications.DataBind();
            }
        }
    }
}