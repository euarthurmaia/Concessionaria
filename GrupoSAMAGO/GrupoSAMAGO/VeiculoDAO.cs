using System;
using System.Collections.Generic;
using System.Linq;

namespace GrupoSAMAGO
{
    public class VeiculoDAO
    {
        public static List<Veiculo> ListarVeiculos()
        {
            List<Veiculo> veiculo = null;
            try
            {

                using (var ctx = new CSSMGDBEntities())
                {
                    veiculo = ctx.Veiculoes.OrderByDescending(
                        x => x.AnoModelo).ToList();
                }
            }
            catch (Exception)
            {
            }
            return veiculo;
        }

        public static string[] PesquisarVeiculos(string termoPesquisa)
        {
            try
            {
                using (var ctx = new CSSMGDBEntities())
                {
                    var resultados = ctx.Veiculoes
                        .Where(x => x.Nome != null && x.Nome.Contains(termoPesquisa))
                        .Select(x => x.Nome)
                        .ToList();

                    return resultados.ToArray();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Veiculo ListarVeiculos(int idVeiculo)
        {
            Veiculo veiculo = null;

            using (var ctx = new CSSMGDBEntities())
            {
                veiculo = ctx.Veiculoes.FirstOrDefault(
                        x => x.IdVeiculo == idVeiculo
                    );
            }

            return veiculo;
        }

        public static List<Veiculo> ListarVeiculosFiltrados(string marca, string valormax, string valormin, string anoMaior, string anoMenor, string kmMaior, string kmMenor, String combustivel, string cambio, string cor)
        {
            List<Veiculo> veiculo = null;
            try
            {

                using (var ctx = new CSSMGDBEntities())
                {

                    veiculo = ctx.Veiculoes.OrderByDescending(x => x.AnoModelo).ToList();

                    if (marca != "" && marca != "TODAS")
                    {
                        var MarcaConv = Convert.ToInt32(marca);
                        veiculo = veiculo.Where(x => x.MarcaID == MarcaConv).ToList();
                    }
                    if (valormax != "")
                    {
                        var valormaxConv = Convert.ToDecimal(valormax);
                        veiculo = veiculo.Where(x => x.Valor <= valormaxConv).ToList();
                    }
                    if (valormin != "")
                    {
                        var valorminConv = Convert.ToDecimal(valormin);
                        veiculo = veiculo.Where(x => x.Valor >= valorminConv).ToList();
                    }
                    if (anoMaior != "")
                    {
                        var anoMaiorConv = Convert.ToInt32(anoMaior);
                        veiculo = veiculo.Where(x => x.AnoFabricacao <= anoMaiorConv).ToList();
                    }
                    if (anoMenor != "")
                    {
                        var anoMenorConv = Convert.ToInt32(anoMenor);
                        veiculo = veiculo.Where(x => x.AnoFabricacao >= anoMenorConv).ToList();
                    }
                    if (kmMaior != "")
                    {
                        var kmMaiorConv = Convert.ToInt32(kmMaior);
                        veiculo = veiculo.Where(x => x.Quilometragem <= kmMaiorConv).ToList();
                    }
                    if (kmMenor != "")
                    {
                        var kmMenorConv = Convert.ToInt32(kmMenor);
                        veiculo = veiculo.Where(x => x.Quilometragem >= kmMenorConv).ToList();
                    }
                    if (combustivel != "" && combustivel != "TODOS")
                    {
                        var combustivelConv = Convert.ToInt32(combustivel);
                        veiculo = veiculo.Where(x => x.CombustivelID == combustivelConv).ToList();
                    }
                    if (cambio != "" && cambio != "TODOS")
                    {
                        var cambioConv = Convert.ToInt32(cambio);
                        veiculo = veiculo.Where(x => x.CambioID == cambioConv).ToList();
                    }
                    if (cor != "" && cor != "TODOS")
                    {
                        var CorConv = Convert.ToInt32(cor);
                        veiculo = veiculo.Where(x => x.CorID == CorConv).ToList();
                    }


                    //veiculo = veiculo.Where(x => x.AnoFabricacao >= anoMenor && x.AnoFabricacao <= anoMaior).ToList();
                }
            }
            catch (Exception)
            {
            }
            return veiculo;
        }

        public static List<Veiculo> BuscaPorNome(string queryString_NomeVeiculo)
        {
           List <Veiculo> veiculos = null;
            try
            {
                using (var ctx = new CSSMGDBEntities())
                {
                    veiculos = ctx.Veiculoes.Where(x => x.Nome == queryString_NomeVeiculo)
                        .OrderByDescending(x => x.AnoFabricacao).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return veiculos;
        }

        public static List<Veiculo> VerVeiculos(int marca, int nome, int cambioid)
        {
            List<Veiculo> veiculo = null;
            try
            {
                using (var ctx = new CSSMGDBEntities())
                {
                    veiculo = ctx.Veiculoes.OrderByDescending(x => x.AnoModelo).ToList();

                    if (marca != 0)
                    {
                        veiculo = veiculo.Where(x => x.MarcaID == marca).ToList();
                    }
                    if (nome != 0)
                    {
                        veiculo = veiculo.Where(x => x.IdVeiculo == nome).ToList();
                    }
                    if (cambioid != 0)
                    {
                        veiculo = veiculo.Where(x => x.CambioID == cambioid).ToList();
                    }
                }
            }
            catch (Exception)
            {
            }
            return veiculo;
        }

        public static List<Veiculo> ListarVeiculosDDL(int idmarca)
        {
            List<Veiculo> veiculo = null;

            using (var ctx = new CSSMGDBEntities())
            {
                veiculo = ctx.Veiculoes.Where(x => x.MarcaID == idmarca).OrderBy(
                        x => x.IdVeiculo
                    ).ToList();
            }

            return veiculo;
        }
    }
}