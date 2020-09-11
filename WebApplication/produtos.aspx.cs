using System;
using System.Linq;
using System.Web.UI;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication
{
    public partial class PgProdutos : Page
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
            IQueryable<Produto> produtos = DB.Produtos;

            var descricao = Request.QueryString["descricao"];

            if (!string.IsNullOrEmpty(descricao))
            {
                txtDescricao.Text = descricao;

                produtos = produtos.Where(x => x.Descricao.Contains(descricao));
            }

            grvProdutos.DataSource = produtos.ToList();
            grvProdutos.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Response.Redirect($"produtos.aspx?descricao={txtDescricao.Text}");
        }
    }
}