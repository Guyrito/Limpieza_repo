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
    
    public partial class Actividad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Actividad()
        {
            this.Act_de_mejora = new HashSet<Act_de_mejora>();
            this.Alerta = new HashSet<Alerta>();
            this.Asesoria = new HashSet<Asesoria>();
            this.Capacitacion = new HashSet<Capacitacion>();
        }
    
        public int id_act { get; set; }
        public System.DateTime Fecha_act { get; set; }
        public System.DateTime Hora_act { get; set; }
        public Nullable<int> Contador { get; set; }
        public int Prof_id_profe { get; set; }
        public int Cliente_id_emp { get; set; }
        public string Tipo_actividad { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<int> Retraso { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Act_de_mejora> Act_de_mejora { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Profesional Profesional { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alerta> Alerta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asesoria> Asesoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Capacitacion> Capacitacion { get; set; }
        public virtual Visita Visita { get; set; }
    }
}
