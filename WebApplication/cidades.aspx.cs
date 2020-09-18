using System;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class PgCidades : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarRegistros();
            }
        }

        private void CarregarRegistros()
        {
            ddlEstadoId.DataSource = Uow.EstadoRepository.ObterTodos();
            ddlEstadoId.DataTextField = "Nome";
            ddlEstadoId.DataValueField = "Id";
            ddlEstadoId.DataBind();
            ddlEstadoId.Items.Insert(0, new ListItem("Selecione", string.Empty));

            var q = Request.QueryString["q"];
            var estadoId = !string.IsNullOrEmpty(Request.QueryString["estadoId"]) ? Convert.ToInt32(Request.QueryString["estadoId"]) : 0;

            txtQ.Text = q;
            ddlEstadoId.SelectedValue = !estadoId.Equals(0) ? estadoId.ToString() : string.Empty;

            var cidades = Uow.CidadeRepository.BuscarCidadesPorNomeEEstado(q, estadoId);

            grvCidades.DataSource = cidades;
            grvCidades.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Response.Redirect($"cidades.aspx?q={txtQ.Text}&estadoId={ddlEstadoId.SelectedValue}");
        }

        protected void grvCidades_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(grvCidades.DataKeys[e.RowIndex].Value);
            Uow.CidadeRepository.Deletar(x => x.Id == id);
            Uow.Commit();
            CarregarRegistros();
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"cidades.aspx");
        }
    }
}