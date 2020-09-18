using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebApplication.Entities;

namespace WebApplication
{
    public partial class PgEstado : PaginaBase
    {
        Estado Estado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);

            Estado = Uow.EstadoRepository.ObterEstadoIncludeCidades(id);

            if (!IsPostBack)
            {
                litAcao.Text = "Novo estado";

                if (Estado != null)
                {
                    litAcao.Text = "Edição de estado";

                    txtNome.Text = Estado.Nome;
                    txtSigla.Text = Estado.Sigla;

                    ltvCidades.DataSource = Estado.Cidades.OrderBy(x => x.Nome);
                    ltvCidades.DataBind();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var nome = txtNome.Text.Trim();
            var sigla = txtSigla.Text.Trim();

            if (Estado == null)
            {
                Estado = new Estado(nome, sigla);
                Uow.EstadoRepository.Adicionar(Estado);
            }
            else
            {
                Estado.Set(nome, sigla);
            }

            foreach (ListViewItem item in ltvCidades.Items)
            {
                var txtNomeCidade = (TextBox)item.FindControl("txtNomeCidade");
                var txtCodigoTom = (TextBox)item.FindControl("txtCodigoTom");

                var id = Convert.ToInt32(ltvCidades.DataKeys[item.DataItemIndex].Values["Id"]);
                var nomeCidade = txtNomeCidade.Text.Trim();
                var codigoTom = !string.IsNullOrEmpty(txtCodigoTom.Text) ? Convert.ToInt32(txtCodigoTom.Text) : 0;

                if (item.Visible)
                {
                    if (id == 0)
                    {
                        var cidade = new Cidade(Estado, nomeCidade, codigoTom);
                        Uow.CidadeRepository.Adicionar(cidade);
                    }
                    else
                    {
                        var cidade = Uow.CidadeRepository.Procurar(id);
                        cidade.Set(Estado, nomeCidade, codigoTom);
                    }
                }
                else
                {
                    var cidade = Uow.CidadeRepository.Procurar(id);

                    if (cidade != null)
                    {
                        Uow.CidadeRepository.Deletar(x => x.Id == id);
                    }
                }
            }

            if (Estado.Valid)
            {
                Uow.Commit();

                Response.Redirect("estados.aspx");
            }
            else
            {
                ltvNotifications.DataSource = Estado.Notifications;
                ltvNotifications.DataBind();
            }
        }

        protected void btnAdicionarCidade_Click(object sender, EventArgs e)
        {
            var cidades = new List<Cidade>();

            cidades.Add(new Cidade());

            foreach (ListViewItem item in ltvCidades.Items)
            {
                var txtNomeCidade = (TextBox)item.FindControl("txtNomeCidade");
                var txtCodigoTom = (TextBox)item.FindControl("txtCodigoTom");

                var id = Convert.ToInt32(ltvCidades.DataKeys[item.DataItemIndex].Values["Id"]);
                var nomeCidade = txtNomeCidade.Text.Trim();
                var codigoTom = Convert.ToInt32(txtCodigoTom.Text);
                var excluir = !item.Visible;

                cidades.Add(new Cidade() { Id = id, Nome = nomeCidade, CodigoTom = codigoTom, Excluir = excluir });
            }

            ltvCidades.DataSource = cidades;
            ltvCidades.DataBind();
        }

        protected void ltvCidades_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            ltvCidades.Items[e.ItemIndex].Visible = false;
        }

        protected void ltvCidades_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var cidade = (Cidade)e.Item.DataItem;

                var txtNomeCidade = (TextBox)e.Item.FindControl("txtNomeCidade");
                var txtCodigoTom = (TextBox)e.Item.FindControl("txtCodigoTom");

                txtNomeCidade.Text = cidade.Nome;
                txtCodigoTom.Text = cidade.CodigoTom > 0 ? cidade.CodigoTom.ToString() : string.Empty;

                e.Item.Visible = !cidade.Excluir;
            }
        }
    }
}