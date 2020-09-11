using System;
using System.Linq;
using System.Web.UI;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication
{
    public partial class PgFornecedores : Page
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
            IQueryable<Fornecedor> fornecedores = DB.Fornecedores;

            var nom = Request.QueryString["nom"];
            var cnpj = Request.QueryString["cnpj"];

            if (!string.IsNullOrEmpty(nom))
            {
                txtNome.Text = nom;

                fornecedores = fornecedores.Where(x => x.Nome.Contains(nom));
            }

            if (!string.IsNullOrEmpty(cnpj))
            {
                txtCnpj.Text = cnpj;

                fornecedores = fornecedores.Where(x => x.Cnpj == cnpj);
            }

            grvFornecedores.DataSource = fornecedores.ToList();
            grvFornecedores.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Response.Redirect($"fornecedores.aspx?nom={txtNome.Text}&cnpj={txtCnpj.Text}");
        }
    }
}