using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrupoSAMAGO
{
    public partial class Veiculo
    {

        public String getImagem;
        public String getInfoProduto;
        public String getAnoModelo;
        public String getValorVeiculo;
        public String getNomeVeiculo;
        public String getImagemMarcas;

        public String GetImagem
        {
            get
            {

                getImagem = "../img/Carros/" + this.Nome + ".jpg";
                return getImagem;
            }
        }

        public String GetInfoProduto
        {
            get
            {
                Cambio cambio = CambioDAO.ListarCambios(this.CambioID);
                Combustivel combustivel = CombustivelDAO.ListarCombustiveis(this.CombustivelID);

                getInfoProduto = this.Quilometragem + "KM / " + cambio.Descricao + " / " + combustivel.Descricao;
                return getInfoProduto;
            }
        }

        public String GetAnoModelo
        {
            get
            {
                getAnoModelo = this.AnoModelo;
                return getAnoModelo;
            }
        }

        public String GetValorVeiculo
        {
            get
            {
                getValorVeiculo = "R$ " + Convert.ToString(this.Valor);
                return getValorVeiculo;

            }
        }

        public String GetNomeVeiculo
        {
            get
            {
                getNomeVeiculo = this.Nome;
                return getNomeVeiculo;
            }
        }

        public String GetImagemMarcas
        {
            get
            {
                Marca marca = MarcaDAO.ListarMarcas(this.MarcaID);
                getImagemMarcas = "../img/Marcas/" + marca.Descricao + ".svg";
                return getImagemMarcas;
            }
        }

    }
}