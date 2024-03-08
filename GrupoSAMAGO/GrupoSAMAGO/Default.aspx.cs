using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrupoSAMAGO
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<Veiculo> veiculos = VeiculoDAO.ListarVeiculos();

                AtualizarLvVeiculos(veiculos);

                List<Marca> marcas = MarcaDAO.ListarMarcas();
                PreencherDDLMarcas(marcas);
                DDLCambio.Enabled = false;
                DDLNome.Enabled = false;
            }
        }

        private void PreencherDDLMarcas(List<Marca> marcas)
        {
            DDLMarcas.DataSource = marcas;
            DDLMarcas.DataTextField = "Descricao";
            DDLMarcas.DataValueField = "IdMarca";
            DDLMarcas.DataBind();
            DDLMarcas.Items.Insert(0, "MARCAS");
        }

        private void AtualizarLvVeiculos(List<Veiculo> veiculos)
        {
            try
            {
                lvVeiculos.DataSource = veiculos;
                lvVeiculos.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void lvVeiculos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            var ID = e.CommandArgument;
            var idnovo = Convert.ToInt32(ID);
            var Descricao = VeiculoDAO.ListarVeiculos(idnovo);

            if (ID != null)
            {
                this.Response.Redirect("~/Produtos?nome=" + Descricao.Nome + "&id=" + ID);
            }
        }

        protected void DDLMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var nomeMarca = DDLMarcas.SelectedValue;

            if (nomeMarca != "MARCAS")
            {
                var idmarca = Convert.ToInt32(nomeMarca);
                DDLNome.Enabled = true;
                List<Veiculo> veiculo = VeiculoDAO.ListarVeiculosDDL(idmarca);
                PreencherDDLNome(veiculo);
                DDLNome.SelectedIndex = 0;
                DDLCambio.Enabled = false;
            }
            else
            {
                DDLNome.Enabled = false;
                DDLCambio.Enabled = false;

            }

        }

        private void PreencherDDLNome(List<Veiculo> veiculo)
        {
            DDLNome.DataSource = veiculo;
            DDLNome.DataTextField = "Nome";
            DDLNome.DataValueField = "IdVeiculo";
            DDLNome.DataBind();
            DDLNome.Items.Insert(0, "VEÍCULOS");
        }

        protected void DDLNome_SelectedIndexChanged(object sender, EventArgs e)
        {
            var nomeVeiculo = DDLNome.SelectedValue;

            if (nomeVeiculo != "VEÍCULOS")
            {
                int idVeiculo = Convert.ToInt32(nomeVeiculo);
                Veiculo veiculo = VeiculoDAO.ListarVeiculos(idVeiculo);
                DDLCambio.Enabled = true;
                List<Cambio> cambio = CambioDAO.ListarCambiosDDL(veiculo.CambioID);
                PreencherDDLCambio(cambio);
                DDLCambio.SelectedIndex = 0;
            }
            else
            {
                DDLCambio.Enabled = false;
            }
        }

        private void PreencherDDLCambio(List<Cambio> cambio)
        {
            DDLCambio.DataSource = cambio;
            DDLCambio.DataTextField = "Descricao";
            DDLCambio.DataValueField = "IdCambio";
            DDLCambio.DataBind();
            DDLCambio.Items.Insert(0, "CÂMBIOS");
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {

            var nomeMarca = DDLMarcas.SelectedValue;
            if (nomeMarca == "MARCAS")
            {
                this.Response.Redirect("~/Filtros");
            }
            else
            {
                var nomeVeiculo = DDLNome.SelectedValue;
                if (nomeVeiculo == "VEÍCULOS")
                {
                    this.Response.Redirect("~/Filtros?marca=" + nomeMarca);
                }
                else
                {
                    var nomeCambio = DDLCambio.SelectedValue;
                    if (nomeCambio == "CÂMBIOS")
                    {
                        this.Response.Redirect("~/Filtros?marca=" + nomeMarca + "&nome=" + nomeVeiculo);
                    }
                    else
                    {
                        this.Response.Redirect("~/Filtros?marca=" + nomeMarca + "&nome=" + nomeVeiculo + "&cambio=" + nomeCambio);

                    }

                }

            }
        }
    }
}