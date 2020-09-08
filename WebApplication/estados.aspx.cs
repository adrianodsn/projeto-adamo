using System;
using System.Linq;
using System.Web.UI;
using WebApplication.Infra.Context;

namespace WebApplication
{
    public partial class PgEstados : Page
    {
        ApContext DB = new ApContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarRegistros();
        }

        private void CarregarRegistros()
        {
            grvEstados.DataSource = DB.Estados.ToList();
            grvEstados.DataBind();
        }

        protected void grvEstados_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(grvEstados.DataKeys[e.RowIndex].Value);
            var estado = DB.Estados.Find(id);
            DB.Estados.Remove(estado);
            DB.SaveChanges();
            CarregarRegistros();
        }
    }
}