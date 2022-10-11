using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWeb5.Models.ViewModels
{
    public class PersonasViewModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido Paterno")]
        public string Ap_Pat { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido Materno")]
        public string Ap_Mat { get; set; }

        [Required]

        public int Edad { get; set; }

        [Required]
        public bool Activo { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        //[]
        [Display(Name = "Fecha de Creacion")]
        public DateTime Create_at { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Modificacion")]
        public DateTime Update_at { get; set; }

    }
}