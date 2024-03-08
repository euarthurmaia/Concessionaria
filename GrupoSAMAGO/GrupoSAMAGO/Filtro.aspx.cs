using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GrupoSAMAGO
{
    public partial class Filtro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                List<Veiculo> veiculos = VeiculoDAO.ListarVeiculos();
                List<Marca> marcas = MarcaDAO.ListarMarcas();
                List<Combustivel> combustivel = CombustivelDAO.ListarDescricaoCombustiveis();
                List<Cambio> cambio = CambioDAO.ListarCambios();
                List<Cor> cor = CorDAO.ListarCores();


                PreencherDDLMarcas(marcas);
                AtualizarLvFiltro(veiculos);
                PreencherRBLCambio(cambio);
                PreencherRBLCor(cor);


                PreencherRBLCombustivel(combustivel);

                ValorMax.Attributes["placeholder"] = "ATÉ...";
                ValorMin.Attributes["placeholder"] = "DE...";
                AnoMaior.Attributes["placeholder"] = "ATÉ...";
                AnoMenor.Attributes["placeholder"] = "DE...";
                KmMaior.Attributes["placeholder"] = "ATÉ...";
                KmMenor.Attributes["placeholder"] = "DE...";
                RadioButtonCambio.SelectedIndex = 0;
                RadioButtonCombustivel.SelectedIndex = 0;
                RadioButtonCor.SelectedIndex = 0;

                var queryString_Marca = Request.QueryString["marca"];
                var queryString_Nome = Request.QueryString["nome"];
                var queryString_Cambio = Request.QueryString["cambio"];
                var queryString_NomeVeiculo = Request.QueryString["nomeveiculo"];


                int nome = 0, marca = 0, cambioid = 0;
                List<Veiculo> valores = null;

                if (queryString_NomeVeiculo != null)
                {
                    valores = VeiculoDAO.BuscaPorNome(queryString_NomeVeiculo);
                }
                else
                {

                    if (queryString_Marca != "")
                    {
                        marca = Convert.ToInt32(queryString_Marca);
                    }
                    if (queryString_Nome != "")
                    {
                        nome = Convert.ToInt32(queryString_Nome);
                    }
                    if (queryString_Cambio != "")
                    {
                        cambioid = Convert.ToInt32(queryString_Cambio);
                    }

                    DDLMarcasCarros.SelectedIndex = marca;
                    RadioButtonCambio.SelectedIndex = cambioid;

                    valores = VeiculoDAO.VerVeiculos(marca, nome, cambioid);
                }
                AtualizarLvFiltro(valores);
            }
        }

        private void PreencherRBLCor(List<Cor> cor)
        {
            RadioButtonCor.DataSource = cor;
            RadioButtonCor.DataTextField = "Descricao";
            RadioButtonCor.DataValueField = "IdCor";
            RadioButtonCor.DataBind();
            RadioButtonCor.Items.Insert(0, "TODOS");
        }

        private void PreencherRBLCambio(List<Cambio> cambio)
        {
            RadioButtonCambio.DataSource = cambio;
            RadioButtonCambio.DataTextField = "Descricao";
            RadioButtonCambio.DataValueField = "IdCambio";
            RadioButtonCambio.DataBind();
            RadioButtonCambio.Items.Insert(0, "TODOS");
        }

        private void PreencherRBLCombustivel(List<Combustivel> combustivel)
        {
            RadioButtonCombustivel.DataSource = combustivel;
            RadioButtonCombustivel.DataTextField = "Descricao";
            RadioButtonCombustivel.DataValueField = "IdCombustivel";
            RadioButtonCombustivel.DataBind();
            RadioButtonCombustivel.Items.Insert(0, "TODOS");
        }

        private void AtualizarLvFiltro(List<Veiculo> veiculos)
        {
            lvFiltro.DataSource = veiculos;
            lvFiltro.DataBind();
        }

        private void PreencherDDLMarcas(List<Marca> marcas)
        {
            DDLMarcasCarros.DataSource = marcas;
            DDLMarcasCarros.DataTextField = "Descricao";
            DDLMarcasCarros.DataValueField = "IdMarca";
            DDLMarcasCarros.DataBind();
            DDLMarcasCarros.Items.Insert(0, "TODAS");
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            var marca = DDLMarcasCarros.SelectedValue;
            var valormax = ValorMax.Text;
            var valormin = ValorMin.Text;
            var anoMaior = AnoMaior.Text;
            var anoMenor = AnoMenor.Text;
            var kmMaior = KmMaior.Text;
            var kmMenor = KmMenor.Text;
            var combustivel = RadioButtonCombustivel.SelectedValue;
            var cambio = RadioButtonCambio.SelectedValue;
            var cor = RadioButtonCor.SelectedValue;



            var valores = VeiculoDAO.ListarVeiculosFiltrados(marca, valormax, valormin, anoMaior, anoMenor,
                kmMaior, kmMenor, combustivel, cambio, cor);

            AtualizarLvFiltro(valores);
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

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            DDLMarcasCarros.SelectedIndex = 0;

            ValorMax.Text = "";
            ValorMin.Text = "";
            AnoMaior.Text = "";
            AnoMenor.Text = "";
            KmMaior.Text = "";
            KmMenor.Text = "";
            RadioButtonCambio.SelectedIndex = 0;
            RadioButtonCombustivel.SelectedIndex = 0;
            RadioButtonCor.SelectedIndex = 0;

            List<Veiculo> veiculo = VeiculoDAO.ListarVeiculos();
            AtualizarLvFiltro(veiculo);

        }
    }
}