using System;
using System.Linq;
using System.Web.UI;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication
{
    public partial class PgFornecedores : PaginaBase
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
            var nom = Request.QueryString["nom"];
            var cnpj = Request.QueryString["cnpj"];

            txtNome.Text = nom;
            txtCnpj.Text = cnpj;

            var fornecedores = Uow.FornecedorRepository.BuscarFornecedores(nom, cnpj);

            grvFornecedores.DataSource = fornecedores;
            grvFornecedores.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Response.Redirect($"fornecedores.aspx?nom={txtNome.Text}&cnpj={txtCnpj.Text}");
        }

        protected void grvFornecedores_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(grvFornecedores.DataKeys[e.RowIndex].Value);
            Uow.FornecedorRepository.Deletar(x => x.Id == id);
            Uow.Commit();
            CarregarRegistros();
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"fornecedores.aspx");
        }
    }
}