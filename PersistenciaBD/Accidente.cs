//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersistenciaBD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Accidente
    {
        public string Tipo_acc { get; set; }
        public string Descripcion_acc { get; set; }
        public string Gravedad_acc { get; set; }
        public int Alerta_id_alerta { get; set; }
        public int Profesional_id_prof { get; set; }
    
        public virtual Alerta Alerta { get; set; }
    }
}
