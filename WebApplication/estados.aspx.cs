﻿using System;
using System.Linq;
using System.Web.UI;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication
{
    public partial class PgEstados : Page
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
            IQueryable<Estado> estados = DB.Estados;

            var nom = Request.QueryString["nom"];

            if (!string.IsNullOrEmpty(nom))
            {
                txtNome.Text = nom;

                estados = estados.Where(x => x.Nome.Contains(nom));
            }

            grvEstados.DataSource = estados.ToList();
            grvEstados.DataBind();
        }

        protected void grvEstados_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(grvEstados.DataKeys[e.RowIndex].Value);
            var estado = DB.Estados.Find(id);
            DB.Estados.Remove(estado);
            DB.SaveChanges();
            CarregarRegistros();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Response.Redirect($"estados.aspx?nom={txtNome.Text}");
        }
    }
}