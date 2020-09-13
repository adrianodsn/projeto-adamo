using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication
{
    public partial class PgCompra : Page
    {
        ApContext DB = new ApContext();
        Compra Compra { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);

            Compra = DB.Compras
                .Include(x => x.ItensCompra)
                .FirstOrDefault(x => x.Id == id);

            if (!IsPostBack)
            {
                ddlProdutoIdParent.DataSource = DB.Produtos.OrderBy(x => x.Descricao).ToList();
                ddlProdutoIdParent.DataTextField = "Descricao";
                ddlProdutoIdParent.DataValueField = "Id";
                ddlProdutoIdParent.DataBind();
                ddlProdutoIdParent.Items.Insert(0, new ListItem("Selecione", string.Empty));

                litAcao.Text = "Nova compra";

                ddlFornecedorId.DataSource = DB.Fornecedores.OrderBy(x => x.Nome).ToList();
                ddlFornecedorId.DataTextField = "Nome";
                ddlFornecedorId.DataValueField = "Id";
                ddlFornecedorId.DataBind();
                ddlFornecedorId.Items.Insert(0, new ListItem("Selecione", string.Empty));

                if (Compra != null)
                {
                    litAcao.Text = "Edição da compra";

                    txtDataCompra.Text = Compra.Data.ToString("yyyy-MM-dd");
                    ddlFornecedorId.SelectedValue = Compra.FornecedorId.ToString();

                    txtDataCompra.Enabled
                        = ddlFornecedorId.Enabled
                        = false;

                    grvItensCompra.DataSource = Compra.ItensCompra;
                    grvItensCompra.DataBind();
                }
            }
        }

        protected void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            var itens = new List<ItemCompra>();

            itens.Add(new ItemCompra());

            foreach (GridViewRow row in grvItensCompra.Rows)
            {
                var ddlProdutoId = (DropDownList)row.FindControl("ddlProdutoId");
                var txtQuantidade = (TextBox)row.FindControl("txtQuantidade");
                var txtValor = (TextBox)row.FindControl("txtValor");

                var id = Convert.ToInt32(grvItensCompra.DataKeys[row.RowIndex].Values["Id"]);
                var produtoId = !string.IsNullOrEmpty(ddlProdutoId.SelectedValue) ? Convert.ToInt32(ddlProdutoId.SelectedValue) : 0;

                var qtd = !string.IsNullOrEmpty(txtQuantidade.Text) ? Convert.ToInt32(txtQuantidade.Text) : 0;
                var valorUnit = !string.IsNullOrEmpty(txtValor.Text) ? Convert.ToDecimal(txtValor.Text) : 0;
                var excluir = !row.Visible;

                itens.Add(new ItemCompra() { Id = id, ProdutoId = produtoId, Qtd = qtd, ValorUnitario = valorUnit, Excluir = excluir });
            }

            grvItensCompra.DataSource = itens;
            grvItensCompra.DataBind();
        }

        protected void grvItensCompra_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            grvItensCompra.Rows[e.RowIndex].Visible = false;
        }

        protected void grvItensCompra_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var itemCompra = (ItemCompra)e.Row.DataItem;

                var txtQuantidade = (TextBox)e.Row.FindControl("txtQuantidade");
                var txtValor = (TextBox)e.Row.FindControl("txtValor");
                var ddlProdutoId = (DropDownList)e.Row.FindControl("ddlProdutoId");

                txtQuantidade.Text = itemCompra.Qtd > 0 ? itemCompra.Qtd.ToString() : string.Empty;

                txtValor.Text = itemCompra.ValorUnitario > 0 ? itemCompra.ValorUnitario.ToString("N2") : string.Empty;

                foreach (ListItem item in ddlProdutoIdParent.Items)
                {
                    ddlProdutoId.Items.Add(new ListItem(item.Text, item.Value));
                }

                ddlProdutoId.SelectedValue = !itemCompra.ProdutoId.Equals(0) ? itemCompra.ProdutoId.ToString() : string.Empty;

                e.Row.Visible = !itemCompra.Excluir;

                if (itemCompra.ProdutoId.Equals(0))
                {
                    ddlProdutoId.Enabled
                    = txtQuantidade.Enabled
                    = txtValor.Enabled
                    = true;
                }
                else
                {
                    ddlProdutoId.Enabled
                    = txtQuantidade.Enabled
                    = txtValor.Enabled
                    = false; //Aqui vai false
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var dataCompra = Convert.ToDateTime(txtDataCompra.Text);
            var fornecedorId = !string.IsNullOrEmpty(ddlFornecedorId.SelectedValue) ? Convert.ToInt32(ddlFornecedorId.SelectedValue) : 0;
            var fornecedor = DB.Fornecedores.Find(fornecedorId);

            if (Compra == null)
            {
                Compra = new Compra(dataCompra, fornecedor);
                DB.Compras.Add(Compra);
            }
            else
            {
                Compra.Set(dataCompra, fornecedor);
            }

            foreach (GridViewRow row in grvItensCompra.Rows)
            {
                var id = Convert.ToInt32(grvItensCompra.DataKeys[row.RowIndex].Values["Id"]);
                var txtQuantidade = (TextBox)row.FindControl("txtQuantidade");
                var txtValor = (TextBox)row.FindControl("txtValor");

                var qtd = !string.IsNullOrEmpty(txtQuantidade.Text) ? Convert.ToInt32(txtQuantidade.Text) : 0;
                var valorUnit = !string.IsNullOrEmpty(txtValor.Text) ? Convert.ToDecimal(txtValor.Text) : 0;

                var ddlProdutoId = (DropDownList)row.FindControl("ddlProdutoId");

                var produtoId = !string.IsNullOrEmpty(ddlProdutoId.SelectedValue) ? Convert.ToInt32(ddlProdutoId.SelectedValue) : 0;
                var produto = DB.Produtos.Find(produtoId);

                if (row.Visible)
                {
                    if (id == 0)
                    {
                        Compra.ItensCompra.Add(new ItemCompra(produto, qtd, valorUnit));
                        produto.Set(produto.Descricao, produto.ValorUnitario, produto.QtdEstoque + qtd);
                    }
                    else
                    {
                        // Não está executando (Não tem alteração dos itens)
                        ItemCompra itCompra = DB.ItensCompra.Find(id);
                        itCompra.Set(produto, qtd, valorUnit);
                        //produto.Set(produto.Descricao, produto.ValorUnitario, produto.QtdEstoque + qtd);
                    }
                }
                else
                {
                    ItemCompra itCompra = DB.ItensCompra.Find(id);

                    if (itCompra != null)
                    {
                        produto.Set(produto.Descricao, produto.ValorUnitario, produto.QtdEstoque - qtd);
                        DB.ItensCompra.Remove(itCompra);
                    }
                }
            }

            if (Compra.Valid)
            {
                DB.SaveChanges();

                Response.Redirect("compras.aspx");
            }
            else
            {
                ltvNotifications.DataSource = Compra.Notifications;
                ltvNotifications.DataBind();
            }
        }
    }
}