using System;
using System.Linq;
using System.Web.UI;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication
{
    public partial class PgPessoas : Page
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
            IQueryable<Pessoa> pessoas = DB.Pessoas;

            var nom = Request.QueryString["nom"];
            var cpf = Request.QueryString["cpf"];

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

            if (!string.IsNullOrEmpty(nom))
            {
                txtNome.Text = nom;

                pessoas = pessoas.Where(x => x.Nome.Contains(nom));
            }

            if (!string.IsNullOrEmpty(cpf))
            {
                txtCpf.Text = cpf;

                pessoas = pessoas.Where(x => x.Cpf == cpf);
            }

            if (dataIni != null)
            {
                txtDataNascIni.Text = dataIni.Value.ToString("yyyy-MM-dd");

                pessoas = pessoas.Where(x => x.DataNascimento >= dataIni);
            }

            if (dataFim != null)
            {
                txtDataNascFim.Text = dataFim.Value.ToString("yyyy-MM-dd");

                pessoas = pessoas.Where(x => x.DataNascimento <= dataFim);
            }

            grvPessoas.DataSource = pessoas.ToList();
            grvPessoas.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Response.Redirect($"pessoas.aspx?nom={txtNome.Text}&cpf={txtCpf.Text}&dataIni={txtDataNascIni.Text}&dataFim={txtDataNascFim.Text}");
        }

        protected void grvPessoas_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(grvPessoas.DataKeys[e.RowIndex].Value);
            var pessoa = DB.Pessoas.Find(id);
            DB.Pessoas.Remove(pessoa);
            DB.SaveChanges();
            CarregarRegistros();
        }
    }
}