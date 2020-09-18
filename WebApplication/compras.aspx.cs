using System;
using System.Web.UI.WebControls;
using WebApplication.Services;

namespace WebApplication
{
    public partial class PgCompras : PaginaBase
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
            ddlFornecedorId.DataSource = Uow.FornecedorRepository.BuscarFornecedores(null, null);
            ddlFornecedorId.DataTextField = "Nome";
            ddlFornecedorId.DataValueField = "Id";
            ddlFornecedorId.DataBind();
            ddlFornecedorId.Items.Insert(0, new ListItem("Selecione", string.Empty));

            var fornecedorId = !string.IsNullOrEmpty(Request.QueryString["fornecedorId"]) ? Convert.ToInt32(Request.QueryString["fornecedorId"]) : 0;

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


            if (!fornecedorId.Equals(0)) ddlFornecedorId.SelectedValue = fornecedorId.ToString();
            if (dataIni != null) txtDataIni.Text = dataIni.Value.ToString("yyyy-MM-dd");
            if (dataFim != null) txtDataFim.Text = dataFim.Value.ToString("yyyy-MM-dd");

            var compras = Uow.CompraRepository.BuscarComprasIncludeFornecedor(fornecedorId, dataIni, dataFim);

            grvCompras.DataSource = compras;
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

        protected void grvCompras_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(grvCompras.DataKeys[e.RowIndex].Value);
            ComprasService.ExcluirCompra(Uow, id);
            CarregarRegistros();
        }
    }
}