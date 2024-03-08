using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrupoSAMAGO
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }


        }


        protected void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            string consulta = txtConsulta.Text.Trim();

            var veiculos = VeiculoDAO.PesquisarVeiculos(consulta);

            gridResultados.DataSource = veiculos;
            gridResultados.DataBind();
        }

        protected void gridResultados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Selecionar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = gridResultados.Rows[index];

                // Obtenha o valor da coluna que contém a informação necessária para o redirecionamento.
                string valorRedirecionamento = selectedRow.Cells[1].Text; // Substitua o índice pela coluna correta.

                // Redirecione para a outra página, passando o valor necessário como parâmetro na URL.
                Response.Redirect("Filtros?nomeveiculo=" + valorRedirecionamento);
            }
        }
    }
}