using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb5.Models.ViewModels
{
    public class ListTablaViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string Ap_Pat { get; set; }
        public string Ap_Mat { get; set; }
        public int Edad { get; set; }
        public bool Activo { get; set; }
        public DateTime create_at { get; set; }
        public DateTime Update_at { get; set; }

    }
}