using System;
using System.Collections.Generic;
using System.Linq;

namespace GrupoSAMAGO
{
    public class CorDAO
    {
        public static List<Cor> ListarCores()
        {
            List<Cor> cor = null;
            using (var ctx = new CSSMGDBEntities())
            {
                cor = ctx.Cors.OrderBy(x => x.Descricao).ToList();
            }
            return cor;
        }

        public static Cor ListarCores(int corID)
        {
            Cor cor = null;

            using (var ctx = new CSSMGDBEntities())
            {
                cor = ctx.Cors.FirstOrDefault(
                        x => x.IdCor == corID
                    );
            }

            return cor;
        }
    }
}