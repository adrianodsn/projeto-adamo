using System;
using System.Linq;
using System.Web.UI;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication
{
    public partial class PgProdutos : PaginaBase
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
            var descricao = Request.QueryString["descricao"];

            txtDescricao.Text = descricao;

            var produtos = Uow.ProdutoRepository.BuscarProdutos(descricao);

            grvProdutos.DataSource = produtos;
            grvProdutos.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Response.Redirect($"produtos.aspx?descricao={txtDescricao.Text}");
        }

        protected void grvProdutos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(grvProdutos.DataKeys[e.RowIndex].Value);
            Uow.ProdutoRepository.Deletar(x=>x.Id == id);
            Uow.Commit();
            CarregarRegistros();
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"produtos.aspx");
        }
    }
}