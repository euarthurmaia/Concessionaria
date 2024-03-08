using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrupoSAMAGO
{
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                var queryString_ID = Request.QueryString["id"];
                if (queryString_ID != null)
                {
                    int id = Convert.ToInt32(queryString_ID);
                    PreencherDados(id);
                }
                else
                {
                    Response.Redirect("~/Inicio");
                }

            }
        }

        private void PreencherDados(int id)
        {
            Veiculo veiculo = VeiculoDAO.ListarVeiculos(id);
            Marca marca = MarcaDAO.ListarMarcas(veiculo.MarcaID);
            Cor cor = CorDAO.ListarCores(veiculo.CorID);
            Combustivel combustivel = CombustivelDAO.ListarCombustiveis(veiculo.CombustivelID);
            Cambio cambio = CambioDAO.ListarCambios(veiculo.CambioID);
            String NomeImagemVeiculoEsq = "~/img/Carros/" + veiculo.Nome.Replace(" ", "%20") + " ESQ.jpg";
            ImagemVeiculoEsq.ImageUrl = NomeImagemVeiculoEsq;
            String NomeImagemVeiculo = "~/img/Carros/" + veiculo.Nome.Replace(" ", "%20") + ".jpg";
            ImagemVeiculo.ImageUrl = NomeImagemVeiculo;
            String NomeImagemVeiculoDir = "~/img/Carros/" + veiculo.Nome.Replace(" ", "%20") + " DIR.jpg";
            ImagemVeiculoDir.ImageUrl = NomeImagemVeiculoDir;
            ImagemMarca.ImageUrl = "../img/Marcas/" + marca.Descricao.Replace(" ", "%20") + ".svg";
            txtNomeVeiculo.InnerText = veiculo.Nome + " " + veiculo.AnoFabricacao + " " + cor.Descricao;
            txtAnoModelo.InnerText = veiculo.AnoModelo;
            txtCor.InnerText = cor.Descricao;
            txtCombustivel.InnerText = combustivel.Descricao;
            txtQuilometragem.InnerText = veiculo.Quilometragem.ToString();
            txtCambio.InnerText = cambio.Descricao;
            txtFinalPlaca.InnerText = veiculo.FinalPlaca;
            txtDescricao.InnerText = veiculo.Descricao;
            txtValorContato.InnerText = "R$ " + veiculo.Valor.ToString();
        }
    }
}