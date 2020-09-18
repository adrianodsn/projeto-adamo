using System;

namespace WebApplication
{
    public partial class PgPessoas : PaginaBase
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
            var nome = Request.QueryString["nome"];
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

            txtNome.Text = nome;
            txtCpf.Text = cpf;

            if (dataIni != null) txtDataNascIni.Text = dataIni.Value.ToString("yyyy-MM-dd");
            if (dataFim != null) txtDataNascFim.Text = dataFim.Value.ToString("yyyy-MM-dd");

            var pessoas = Uow.PessoaRepository.BuscarPessoas(nome, cpf, dataIni, dataFim);

            grvPessoas.DataSource = pessoas;
            grvPessoas.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Response.Redirect($"pessoas.aspx?nome={txtNome.Text}&cpf={txtCpf.Text}&dataIni={txtDataNascIni.Text}&dataFim={txtDataNascFim.Text}");
        }

        protected void grvPessoas_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(grvPessoas.DataKeys[e.RowIndex].Value);
            Uow.PessoaRepository.Deletar(x => x.Id == id);
            Uow.Commit();
            CarregarRegistros();
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"pessoas.aspx");
        }
    }
}