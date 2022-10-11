using AppWeb5.Models;
using AppWeb5.Models.ViewModels;

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace AppWeb5.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Index()
        {
            List<ListTablaViewModel> lst;
            using (Proyecto_2022Entities2 db = new Proyecto_2022Entities2())
            //SqlConnection SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            //SqlConnection connection = SqlConnection;
            //string query = "select * from [01_0_Personas]";
            //SqlCommand cmd = new SqlCommand(query, connection);
            //connection.Open();

            {
                lst = (from d in db.C01_0_Personas
                           select new ListTablaViewModel
                           {
                               id = d.ID,
                               nombre = d.Nombre,
                               Ap_Pat = d.Apellido_Paterno,
                               Ap_Mat = d.Apellido_Materno,
                               Edad = d.Edad,
                               Activo = d.Activo
                           }
                           ).ToList();
                    
                    }
            return View(lst);
        }





 
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(PersonasViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    using (Proyecto_2022Entities2 db = new Proyecto_2022Entities2())
                    {
                        var oTabla = new C01_0_Personas();
                        ////oTabla.ID = model.id;
                        oTabla.Nombre = model.nombre;
                        oTabla.Apellido_Paterno = model.Ap_Pat;
                        oTabla.Apellido_Materno = model.Ap_Mat;
                        oTabla.Edad = model.Edad;
                        oTabla.Activo = model.Activo;
                        oTabla.Create_at = DateTime.Now;
                        
                        oTabla.Update_at = DateTime.Now;

                        db.C01_0_Personas.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("/Personas");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }




        public ActionResult Editar(int id)
        {
            PersonasViewModel model = new PersonasViewModel();
            using (Proyecto_2022Entities2 db = new Proyecto_2022Entities2()) 
            {
                var oTabla = db.C01_0_Personas.Find(id);
                model.nombre = oTabla.Nombre;
                model.Ap_Pat = oTabla.Apellido_Paterno;
                model.Ap_Mat = oTabla.Apellido_Materno;
                model.Edad= oTabla.Edad;
                model.Activo = oTabla.Activo;
                model.id = oTabla.ID;

            }
                return View(model);
        }
        [HttpPost]
        public ActionResult Editar(PersonasViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Proyecto_2022Entities2 db = new Proyecto_2022Entities2())
                    {
                        var oTabla = db.C01_0_Personas.Find(model.id);
                        ////oTabla.ID = model.id;
                        oTabla.Nombre = model.nombre;
                        oTabla.Apellido_Paterno = model.Ap_Pat;
                        oTabla.Apellido_Materno = model.Ap_Mat;
                        oTabla.Edad = model.Edad;
                        oTabla.Activo = model.Activo;
                        //oTabla.Create_at = DateTime.Now;

                        oTabla.Update_at = DateTime.Now;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/Personas");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            
            using (Proyecto_2022Entities2 db = new Proyecto_2022Entities2())
            {
                
                var oTabla = db.C01_0_Personas.Find(id);
                db.C01_0_Personas.Remove(oTabla);
                db.SaveChanges();

            }
            return Redirect("/Personas");
        }



    }
}