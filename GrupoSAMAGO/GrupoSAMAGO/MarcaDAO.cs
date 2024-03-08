using System;
using System.Collections.Generic;
using System.Linq;

namespace GrupoSAMAGO
{
    public class MarcaDAO
    {
        public static Marca ListarMarcas(int marcaID)
        {
            Marca marca = null;

            using (var ctx = new CSSMGDBEntities())
            {
                marca = ctx.Marcas.FirstOrDefault(
                        x => x.IdMarca == marcaID
                    );
            }

            return marca;
        }

        public static List<Marca> ListarMarcas()
        {
            List<Marca> marcas = null;
            try
            {
                using (var ctx = new CSSMGDBEntities())
                {
                    marcas = ctx.Marcas.OrderBy(
                        x => x.IdMarca).ToList();
                }
            }
            catch (Exception )
            {
            }
            return marcas;
        }
    }
}