using System;
using System.Linq;
using System.Web.UI;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication
{
    public partial class PgVendas : Page
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
            IQueryable<Venda> vendas = DB.Vendas;

            var cliente = Request.QueryString["cliente"];

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

            if (!string.IsNullOrEmpty(cliente))
            {
                txtCliente.Text = cliente;

                vendas = vendas.Where(x => x.Cliente.Contains(cliente));
            }

            if (dataIni != null)
            {
                txtDataIni.Text = dataIni.Value.ToString("yyyy-MM-dd");

                vendas = vendas.Where(x => x.Data>= dataIni);
            }

            if (dataFim != null)
            {
                txtDataFim.Text = dataFim.Value.ToString("yyyy-MM-dd");

                vendas = vendas.Where(x => x.Data <= dataFim);
            }

            grvVendas.DataSource = vendas.ToList();
            grvVendas.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Response.Redirect($"vendas.aspx?cliente={txtCliente.Text}&dataIni={txtDataIni.Text}&dataFim={txtDataFim.Text}");
        }


        protected void grvVendas_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(grvVendas.DataKeys[e.RowIndex].Value);
            var venda = DB.Vendas.Find(id);
            DB.Vendas.Remove(venda);
            DB.SaveChanges();
            CarregarRegistros();
        }
    }
}