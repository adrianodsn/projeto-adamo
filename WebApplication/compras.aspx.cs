using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication
{
    public partial class PgCompras : Page
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
            ddlFornecedorId.DataSource = DB.Fornecedores.ToList();
            ddlFornecedorId.DataTextField = "Nome";
            ddlFornecedorId.DataValueField = "Id";
            ddlFornecedorId.DataBind();
            ddlFornecedorId.Items.Insert(0, new ListItem("Selecione", string.Empty));

            var compras = DB.Compras.Include(x => x.Fornecedor);

            var fornecedorId = !string.IsNullOrEmpty(Request.QueryString["fornecedorId"]) ? Convert.ToInt32(Request.QueryString["fornecedorId"]) : 0;

            if (!fornecedorId.Equals(0))
            {
                ddlFornecedorId.SelectedValue = fornecedorId.ToString();

                compras = compras.Where(x => x.FornecedorId == fornecedorId);
            }

            DateTime? dataIni = null;
            DateTime? dataFim = null;

            if (DateTime.TryParse(Request.QueryString["dataIni"], out DateTime _dataIni))
            {
                dataIni = _dataIni;
            }

            if (DateTime.TryParse(Request.QueryString["dataFim"], out DateTime _dataFim))
            {
                dataFim = _dataFim;
            }

            if (dataIni != null)
            {
                txtDataIni.Text = dataIni.Value.ToString("yyyy-MM-dd");

                compras = compras.Where(x => x.Data>= dataIni);
            }

            if (dataFim != null)
            {
                txtDataFim.Text = dataFim.Value.ToString("yyyy-MM-dd");

                compras = compras.Where(x => x.Data <= dataFim);
            }

            grvCompras.DataSource = compras.ToList();
            grvCompras.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
             Response.Redirect($"compras.aspx?fornecedorId={ddlFornecedorId.SelectedValue}&dataIni={txtDataIni.Text}&dataFim={txtDataFim.Text}");
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"compras.aspx");
        }

        protected void grvCompras_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(grvCompras.DataKeys[e.RowIndex].Value);
            var compra = DB.Compras.Find(id);
            DB.Compras.Remove(compra);
            DB.SaveChanges();
            CarregarRegistros();
        }

        protected void grvCompras_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(grvCompras.DataKeys[e.RowIndex].Value);
            var Compra = DB.Compras.Find(id);
            DB.Compras.Remove(Compra);
            DB.SaveChanges();
            CarregarRegistros();
        }
    }
}