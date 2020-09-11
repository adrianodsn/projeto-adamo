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
    public partial class PgVenda : Page
    {
        ApContext DB = new ApContext();
        Venda Venda { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);

            Venda = DB.Vendas
                .Include(x => x.ItensVenda)
                .FirstOrDefault(x => x.Id == id);

            if (!IsPostBack)
            {
                litAcao.Text = "Nova venda";

                if (Venda != null)
                {
                    litAcao.Text = "Edição da venda";

                    txtDataVenda.Text = Venda.Data.ToString("yyyy-MM-dd");
                    txtNomeCliente.Text = Venda.Cliente;

                    txtDataVenda.Enabled
                        = txtNomeCliente.Enabled
                        = false;

                    grvItensVenda.DataSource = Venda.ItensVenda;
                    grvItensVenda.DataBind();
                }
            }
        }

        protected void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            var itens = new List<ItemVenda>();

            itens.Add(new ItemVenda());

            foreach (GridViewRow row in grvItensVenda.Rows)
            {
                var txtProduto = (TextBox)row.FindControl("txtProduto");
                var txtQuantidade = (TextBox)row.FindControl("txtQuantidade");
                var txtValor = (TextBox)row.FindControl("txtValor");

                var id = Convert.ToInt32(grvItensVenda.DataKeys[row.RowIndex].Values["Id"]);
                var produto = txtProduto.Text.Trim();
                var qtd = !string.IsNullOrEmpty(txtQuantidade.Text) ? Convert.ToInt32(txtQuantidade.Text) : 0;
                var valorUnit = !string.IsNullOrEmpty(txtValor.Text) ? Convert.ToDecimal(txtValor.Text) : 0;
                var excluir = !row.Visible;

                itens.Add(new ItemVenda() { Id = id, Produto = produto, Qtd = qtd, ValorUnit = valorUnit, Excluir = excluir });
            }

            grvItensVenda.DataSource = itens;
            grvItensVenda.DataBind();
        }

        protected void grvItensVenda_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            grvItensVenda.Rows[e.RowIndex].Visible = false;
        }

        protected void grvItensVenda_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var itemVenda = (ItemVenda)e.Row.DataItem;

                var txtQuantidade = (TextBox)e.Row.FindControl("txtQuantidade");
                var txtValor = (TextBox)e.Row.FindControl("txtValor");

                txtQuantidade.Text = itemVenda.Qtd > 0 ? itemVenda.Qtd.ToString() : string.Empty;
                txtValor.Text = itemVenda.ValorUnit > 0 ? itemVenda.ValorUnit.ToString("N2") : string.Empty;

                //var excluir = Convert.ToBoolean(grvItensVenda.DataKeys[e.Row.RowIndex].Values["Excluir"]);
                e.Row.Visible = !itemVenda.Excluir;
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var dataVenda = Convert.ToDateTime(txtDataVenda.Text);
            var nomeCliente = txtNomeCliente.Text.Trim();

            if (Venda == null)
            {
                Venda = new Venda(dataVenda, nomeCliente);
                DB.Vendas.Add(Venda);
            }
            else
            {
                Venda.Set(dataVenda, nomeCliente);
            }

            foreach (GridViewRow row in grvItensVenda.Rows)
            {
                var txtProduto = (TextBox)row.FindControl("txtProduto");
                var txtQuantidade = (TextBox)row.FindControl("txtQuantidade");
                var txtValor = (TextBox)row.FindControl("txtValor");

                var id = Convert.ToInt32(grvItensVenda.DataKeys[row.RowIndex].Values["Id"]);
                var produto = txtProduto.Text.Trim();
                var qtd = Convert.ToInt32(txtQuantidade.Text);
                var valorUnit = Convert.ToDecimal(txtValor.Text);

                if (row.Visible)
                {
                    if (id == 0)
                    {
                        Venda.ItensVenda.Add(new ItemVenda(produto, qtd, valorUnit));
                    }
                    else
                    {
                        ItemVenda itVenda = DB.ItensVenda.Find(id);
                        itVenda.Set(produto, qtd, valorUnit);
                    }
                }
                else
                {
                    ItemVenda itVenda = DB.ItensVenda.Find(id);

                    if (itVenda != null)
                    {
                        DB.ItensVenda.Remove(itVenda);
                    }
                }
            }

            if (Venda.Valid)
            {
                DB.SaveChanges();

                Response.Redirect("vendas.aspx");
            }
            else
            {
                ltvNotifications.DataSource = Venda.Notifications;
                ltvNotifications.DataBind();
            }
        }
    }
}