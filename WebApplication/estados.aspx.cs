using System;
using System.Linq;

namespace WebApplication
{
    public partial class PgEstados : PaginaBase
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
            var nom = Request.QueryString["nom"];
            txtNome.Text = nom;
            var estados = Uow.EstadoRepository.BuscarEstadosPorNome(nom);
            grvEstados.DataSource = estados.ToList();
            grvEstados.DataBind();
        }

        protected void grvEstados_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(grvEstados.DataKeys[e.RowIndex].Value);
            Uow.EstadoRepository.Deletar(x => x.Id == id);
            Uow.Commit();
            CarregarRegistros();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Response.Redirect($"estados.aspx?nom={txtNome.Text}");
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"estados.aspx");
        }
    }
}