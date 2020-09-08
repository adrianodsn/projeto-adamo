using System;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Infra.Context;

namespace WebApplication
{
    public partial class PgCidades : Page
    {
        ApContext DB = new ApContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarRegistros();
            }
        }

        private void CarregarRegistros()
        {
            ddlEstadoId.DataSource = DB.Estados.ToList();
            ddlEstadoId.DataTextField = "Nome";
            ddlEstadoId.DataValueField = "Id";
            ddlEstadoId.DataBind();
            ddlEstadoId.Items.Insert(0, new ListItem("Selecione", string.Empty));

            var cidades = DB.Cidades.Include(x => x.Estado);

            var q = Request.QueryString["q"];
            var estadoId = !string.IsNullOrEmpty(Request.QueryString["estadoId"]) ? Convert.ToInt32(Request.QueryString["estadoId"]) : 0;

            if (!string.IsNullOrEmpty(q))
            {
                txtQ.Text = q;

                cidades = cidades.Where(x => x.Nome.Contains(q));
            }

            if (!estadoId.Equals(0))
            {
                ddlEstadoId.SelectedValue = estadoId.ToString();

                cidades = cidades.Where(x => x.EstadoId == estadoId);
            }

            grvCidades.DataSource = cidades.ToList();
            grvCidades.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Response.Redirect($"cidades.aspx?q={txtQ.Text}&estadoId={ddlEstadoId.SelectedValue}");
        }

        protected void grvCidades_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(grvCidades.DataKeys[e.RowIndex].Value);
            var cidade = DB.Cidades.Find(id);
            DB.Cidades.Remove(cidade);
            DB.SaveChanges();
            CarregarRegistros();
        }


    }
}