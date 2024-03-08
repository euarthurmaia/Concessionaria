using System;
using System.Collections.Generic;
using System.Linq;

namespace GrupoSAMAGO
{
    public class CombustivelDAO
    {
        public static Combustivel ListarCombustiveis(int idVeiculo)
        {
            Combustivel combustivel = null;

            using (var ctx = new CSSMGDBEntities())
            {
                combustivel = ctx.Combustivels.FirstOrDefault(
                        x => x.IdCombustivel == idVeiculo
                    );
            }

            return combustivel;
        }

        public static List<Combustivel> ListarDescricaoCombustiveis()
        {
            List<Combustivel> combustivel = null;

            using (var ctx = new CSSMGDBEntities())
            {
                combustivel = ctx.Combustivels.OrderBy(x => x.Descricao).ToList();
            }

            return combustivel;
        }
    }
}