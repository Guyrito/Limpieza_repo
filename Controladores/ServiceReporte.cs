using PersistenciaBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class ServiceReporte : AbstractService<Reporte>
    {
        public override List<Reporte> GetEntities()
        {
            return nmaEn.Reporte.ToList<Reporte>();
        }

        public override Reporte GetEntity(object key)
        {
            return nmaEn.Reporte.Where(Reporte => Reporte.Id_reporte == (int)key).FirstOrDefault<Reporte>();
        }
    }
}
