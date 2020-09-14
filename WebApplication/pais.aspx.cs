using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using WebApplication.Entities;
using WebApplication.Infra.Context;
using System.Collections.Generic;

namespace WebApplication
{
    public partial class PgPais : Page
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
            IQueryable<Pai> pais = DB.Pais;

            var nomPai = Request.QueryString["nomPai"];
            var nomMae = Request.QueryString["nomMae"];

            if (!string.IsNullOrEmpty(nomPai))
            {
                txtNomePai.Text = nomPai;

                pais = pais.Where(x => x.NomePai.Contains(nomPai));
            }

            if (!string.IsNullOrEmpty(nomMae))
            {
                txtNomeMae.Text = nomMae;

                pais = pais.Where(x => x.NomeMae.Contains(nomMae));
            }

            grvPais.DataSource = pais.ToList();
            grvPais.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Response.Redirect($"pais.aspx?nomPai={txtNomePai.Text}&nomMae={txtNomeMae.Text}");
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"pais.aspx");
        }

        protected void grvPais_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(grvPais.DataKeys[e.RowIndex].Value);

            var pai = DB.Pais
                .Include(x => x.Filhos)
                .FirstOrDefault(x => x.Id == id);

            var listaFilhos = pai.Filhos.ToList();

            foreach (Filho registro in listaFilhos)
            {

                var filho = DB.Filhos.Find(registro.Id);

                DB.Filhos.Remove(filho);
            }

            DB.Pais.Remove(pai);
            DB.SaveChanges();
            CarregarRegistros();
        }
    }
}