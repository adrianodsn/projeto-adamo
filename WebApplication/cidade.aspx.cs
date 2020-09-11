using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication
{
    public partial class PgCidade : Page
    {
        ApContext DB = new ApContext();
        Cidade Cidade { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);

            Cidade = DB.Cidades.Find(id);

            if (!IsPostBack)
            {
                litAcao.Text = "Nova cidade";

                ddlEstadoId.DataSource = DB.Estados.ToList();
                ddlEstadoId.DataTextField = "Nome";
                ddlEstadoId.DataValueField = "Id";
                ddlEstadoId.DataBind();
                ddlEstadoId.Items.Insert(0, new ListItem("Selecione", string.Empty));

                if (Cidade != null)
                {
                    litAcao.Text = "Edição de cidade";

                    txtNome.Text = Cidade.Nome;
                    ddlEstadoId.SelectedValue = Cidade.EstadoId.ToString();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var estadoId = !string.IsNullOrEmpty(ddlEstadoId.SelectedValue) ? Convert.ToInt32(ddlEstadoId.SelectedValue) : 0;
            var nome = txtNome.Text.Trim();

            var estado = DB.Estados.Find(estadoId);

            if (Cidade == null)
            {
                Cidade = new Cidade(estado, nome);
                DB.Cidades.Add(Cidade);
            }
            else
            {
                Cidade.Set(estado, nome);
            }

            if (Cidade.Valid)
            {
                DB.SaveChanges();

                Response.Redirect("cidades.aspx");
            }
            else
            {
                ltvNotifications.DataSource = Cidade.Notifications;
                ltvNotifications.DataBind();
            }
        }
    }
}