using SIMEDECON.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SIMEDECON.Models.ViewModel
{
    [DataContract(IsReference = true)]
    public class AtletaView
    {
        public Datos_Atleta Model { get; set; }

        [Display(Name = "Foto Atleta")]
        public HttpPostedFileBase ImageFile { get; set; }

        public virtual Equipo_Deportivo equip { get; set; }
    }
}