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
    
    public partial class Carrera_Deportiva_Familiar
    {
        public int ID { get; set; }
        public int ID_Atleta { get; set; }
        public string Evento { get; set; }
        public string FechayLugar { get; set; }
        public string Resultado { get; set; }
        public Nullable<System.DateTime> Fecha_de_Registro { get; set; }
        public Nullable<System.DateTime> Fecha_de_Actualizacion { get; set; }
        public Nullable<bool> Estado { get; set; }
    
        public virtual Datos_Atleta Datos_Atleta { get; set; }
    }
}
