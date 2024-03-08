using System;
using System.Collections.Generic;
using System.Linq;

namespace GrupoSAMAGO
{
    public class CambioDAO
    {
        public static Cambio ListarCambios(int idVeiculo)
        {
            Cambio cambio = null;

            using (var ctx = new CSSMGDBEntities())
            {
                cambio = ctx.Cambios.FirstOrDefault(
                        x => x.IdCambio== idVeiculo
                    );
            }

            return cambio;
        }

        public static List<Cambio> ListarCambios()
        {
            List<Cambio> cambio = null;
            using (var ctx = new CSSMGDBEntities())
            {
                cambio = ctx.Cambios.OrderBy(x => x.Descricao).ToList();
            }
            return cambio;
        }

        public static List<Cambio> ListarCambiosDDL(int idVeiculo)
        {
            List<Cambio> cambio = null;

            using (var ctx = new CSSMGDBEntities())
            {
                cambio = ctx.Cambios.Where(x => x.IdCambio == idVeiculo).OrderBy(
                        x => x.IdCambio
                    ).ToList();
            }

            return cambio;
        }
    }
}