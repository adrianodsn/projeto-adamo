using System;
using System.Web.UI;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication
{
    public partial class PgProduto : Page
    {
        ApContext DB = new ApContext();
        Produto Produto { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);

            Produto = DB.Produtos.Find(id);

            if (!IsPostBack)
            {
                litAcao.Text = "Novo produto";

                if (Produto != null)
                {
                    litAcao.Text = "Edição de produto";

                    txtDescricao.Text = Produto.Descricao;
                    txtValorUnit.Text = Produto.ValorUnitario.ToString();
                    txtQtdEstoque.Text = Produto.QtdEstoque.ToString();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var descricao = txtDescricao.Text.Trim();
            var valorUnit = Convert.ToDecimal(txtValorUnit.Text.Trim());
            var qtdEsoque = !string.IsNullOrEmpty(txtQtdEstoque.Text) ? Convert.ToInt32(txtQtdEstoque.Text) : 0;

            if (Produto == null)
            {
                Produto = new Produto(descricao, valorUnit, qtdEsoque);
                DB.Produtos.Add(Produto);
            }
            else
            {
                Produto.Set(descricao, valorUnit, qtdEsoque);
            }

            if (Produto.Valid)
            {
                DB.SaveChanges();

                Response.Redirect("produtos.aspx");
            }
            else
            {
                ltvNotifications.DataSource = Produto.Notifications;
                ltvNotifications.DataBind();
            }
        }
    }
}