using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Entities;
using WebApplication.Infra.Context;
using WebApplication.Services;

namespace WebApplication
{
    public partial class PgCompra : PaginaBase
    {
        Compra Compra { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);

            Compra = Uow.CompraRepository.ObterCompraIncludeItens(id);

            if (!IsPostBack)
            {
                ddlProdutoIdParent.DataSource = Uow.ProdutoRepository.ObterTodos().OrderBy(x => x.Descricao);
                ddlProdutoIdParent.DataTextField = "Descricao";
                ddlProdutoIdParent.DataValueField = "Id";
                ddlProdutoIdParent.DataBind();
                ddlProdutoIdParent.Items.Insert(0, new ListItem("Selecione", string.Empty));

                litAcao.Text = "Nova compra";

                ddlFornecedorId.DataSource = Uow.FornecedorRepository.ObterTodos().OrderBy(x => x.Nome);
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

            var produtoAdicionadoId = Convert.ToInt32(ddlProdutoIdParent.SelectedValue);
            var produtoAdicionadoQtd = Convert.ToInt32(txtQtd.Text);
            var produto = Uow.ProdutoRepository.Procurar(produtoAdicionadoId);

            itens.Add(new ItemCompra() { ProdutoId = produtoAdicionadoId, Qtd = produtoAdicionadoQtd, ValorUnitario = produto.ValorUnitario });

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

                e.Row.Visible = !itemCompra.Excluir; //É a mesma coisa do código abaixo comentado
                /*if (!itemCompra.Excluir)
                {
                    e.Row.Visible = true;
                }
                else
                {
                    e.Row.Visible = false;
                }*/

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
            var fornecedor = Uow.FornecedorRepository.Procurar(fornecedorId);

            if (Compra == null)
            {
                Compra = new Compra(dataCompra, fornecedor);
                Uow.CompraRepository.Adicionar(Compra);
            }
            else
            {
                Compra.Set(dataCompra, fornecedor);
            }

            foreach (GridViewRow row in grvItensCompra.Rows)
            {                
                var ddlProdutoId = (DropDownList)row.FindControl("ddlProdutoId");
                var txtQuantidade = (TextBox)row.FindControl("txtQuantidade");
                var txtValor = (TextBox)row.FindControl("txtValor");

                var id = Convert.ToInt32(grvItensCompra.DataKeys[row.RowIndex].Values["Id"]);
                var produtoId = !string.IsNullOrEmpty(ddlProdutoId.SelectedValue) ? Convert.ToInt32(ddlProdutoId.SelectedValue) : 0;
                var qtd = !string.IsNullOrEmpty(txtQuantidade.Text) ? Convert.ToInt32(txtQuantidade.Text) : 0;
                var valorUnit = !string.IsNullOrEmpty(txtValor.Text) ? Convert.ToDecimal(txtValor.Text) : 0;

                if (row.Visible)
                {
                    if (id == 0)
                    {
                        ComprasService.AdicionarItemCompra(Uow, Compra, produtoId, qtd, valorUnit);
                    }
                }
                else
                {
                    var itemCompra = Compra.ItensCompra.FirstOrDefault(x => x.Id == id);

                    if (itemCompra != null)
                    {
                        ComprasService.ExcluirItemCompra(Uow, itemCompra.Id);
                    }
                }
            }

            if (Compra.Valid)
            {
                Uow.Commit();

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