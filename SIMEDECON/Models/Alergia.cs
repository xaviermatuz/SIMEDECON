//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIMEDECON.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alergia
    {
        public int ID { get; set; }
        public int ID_Atleta { get; set; }
        public string Alergia1 { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime Fecha_de_Registro { get; set; }
        public Nullable<System.DateTime> Fecha_de_Actualizacion { get; set; }
        public bool Estado { get; set; }
    
        public virtual Datos_Atleta Datos_Atleta { get; set; }
    }
}
