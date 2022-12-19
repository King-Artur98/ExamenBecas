using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        [HttpGet]
        public ActionResult GetAll(/*ML.Alumno alumno*/)
        {
            ServiceAlumno.AlumnoClient context = new ServiceAlumno.AlumnoClient();
            var result= context.GetAll( );
            //ML.Result result = BL.Alumno.GetAllLQ();

            ML.Alumno alumno = new ML.Alumno();
            alumno.Alumnos = new List<object>();
            if (result.Correct)
            {
                foreach (var obj in result.Objects)
                {
                    alumno.Alumnos.Add(obj);

                }
               
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
            }

            return View(alumno);
        }


        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {


            ML.Alumno alumno = new ML.Alumno();

            alumno.Beca = new ML.Beca();

            ML.Result resultBeca = BL.Becas.GetAllLQ();

            if (IdAlumno == null)
            {

                alumno.Beca.Becas = resultBeca.Objects;
                return View(alumno);

            }
            else
            {
                //GetById
                //ML.Result result = BL.Alumno.GetByIdLQ(IdAlumno.Value);

                ServiceAlumno.AlumnoClient context = new ServiceAlumno.AlumnoClient();
                var result = context.GetById(IdAlumno.Value);

                if (result.Correct)
                {
                    alumno = (ML.Alumno)result.Object;
                    alumno.Beca.Becas = resultBeca.Objects;


                    return View(alumno);

                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar el Alumno seleccionado";
                }
                return View(alumno);
            }
        }

        [HttpPost]
        //ADD
        public ActionResult Form(ML.Alumno alumno)
        {
            if (alumno.IdAlumno == 0)
            {
                //ML.Result result = BL.Alumno.AddLQ(alumno);

                ServiceAlumno.AlumnoClient context = new ServiceAlumno.AlumnoClient();
                var result = context.Add(alumno);


                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error:  " + result.Message;
                }

            }
            else
            {
                //ML.Result result = BL.Alumno.UpdateLQ(alumno);

                ServiceAlumno.AlumnoClient context = new ServiceAlumno.AlumnoClient();
                var result = context.Update(alumno);


                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "ERROR: " + result.Message;
                }
            }

            return PartialView("Modal");
        }

        //delete
        public ActionResult Delete(ML.Alumno alumno)
        {
            //ML.Result result = BL.Alumno.DeleteLQ(alumno);
            ServiceAlumno.AlumnoClient context = new ServiceAlumno.AlumnoClient();
            var result = context.Delete(alumno);
            if (result.Correct)
            {
                ViewBag.Message = result.Message;
            }
            else
            {
                ViewBag.Message = "ERROR: " + result.Message;
            }
            return PartialView("Modal");
        }



    }
}