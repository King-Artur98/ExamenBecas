using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Result GetAllLQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenBecasEntities1 context = new DL.ExamenBecasEntities1())
                {
                    var query = from Alumno in context.Alumno select Alumno;
                    result.Objects = new List<object>();
                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Alumno alumno = new ML.Alumno();

                            alumno.IdAlumno = obj.IdAlumno;
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumno.ApellidoMaterno = obj.ApellidoMaterno;
                            alumno.Genero = (bool)obj.Genero;
                            alumno.Edad = (int)obj.Edad;


                            alumno.Beca = new ML.Beca();
                            alumno.Beca.IdBeca = (int)obj.IdBeca;
                            alumno.Beca.Nombre = obj.Beca.Nombre;


                            result.Objects.Add(alumno);
                            result.Message = "Exito";
                            result.Correct = true;
                        }
                    }
                    else
                    {
                        result.Message = " Sin Exito";
                        result.Correct = false;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                throw;
            }
            return result;
        }

        public static ML.Result GetByIdLQ(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenBecasEntities1 context = new DL.ExamenBecasEntities1())
                {
                    var query = (from Alumno in context.Alumno where Alumno.IdAlumno == IdAlumno select Alumno).Single();
                    result.Objects = new List<object>();
                    if (query != null)
                    {

                        ML.Alumno alumno = new ML.Alumno();

                        alumno.IdAlumno = query.IdAlumno;
                        alumno.Nombre = query.Nombre;
                        alumno.ApellidoPaterno = query.ApellidoPaterno;
                        alumno.ApellidoMaterno = query.ApellidoMaterno;
                        alumno.Genero = (bool)query.Genero;
                        alumno.Edad = (int)query.Edad;


                        alumno.Beca = new ML.Beca();
                        alumno.Beca.IdBeca = (int)query.IdBeca;
                        alumno.Beca.Nombre = query.Beca.Nombre;

                        result.Object = alumno; //boxing del obj

                        result.Correct = true;

                    }
                    else
                    {

                        result.Correct = false;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                throw;
            }
            return result;
        }

        public static ML.Result AddLQ(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenBecasEntities1 context = new DL.ExamenBecasEntities1())
                {
                    DL.Alumno alumno1 = new DL.Alumno();
                    alumno1.Nombre = alumno.Nombre;
                    alumno1.ApellidoPaterno = alumno.ApellidoPaterno;
                    alumno1.ApellidoMaterno = alumno.ApellidoMaterno;
                    alumno1.Genero = alumno.Genero;
                    alumno1.Edad = alumno.Edad;

                    alumno1.IdBeca = alumno.Beca.IdBeca;

                    context.Alumno.Add(alumno1);
                    context.SaveChanges();

                    result.Message = "Alumno Registrado con exito";
                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
                throw;
            }
            return result;
        }

        public static ML.Result UpdateLQ(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenBecasEntities1 context = new DL.ExamenBecasEntities1())
                {
                    var query = (from a in context.Alumno where a.IdAlumno == alumno.IdAlumno select a).SingleOrDefault();
                    if (query != null)
                    {
                        query.IdAlumno = alumno.IdAlumno;
                        query.Nombre = alumno.Nombre;
                        query.ApellidoMaterno = alumno.ApellidoMaterno;
                        query.Genero = alumno.Genero;
                        query.Edad = alumno.Edad;

                        query.IdBeca = alumno.Beca.IdBeca;

                        context.SaveChanges();
                        result.Message = "Alumno moficado con exito";
                        result.Correct = true;

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
                throw;
            }
            return result;
        }

        public static ML.Result DeleteLQ(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenBecasEntities1 context = new DL.ExamenBecasEntities1())
                {
                    var query = (from a in context.Alumno where a.IdAlumno == alumno.IdAlumno select a).First();

                    context.Alumno.Remove(query);
                    context.SaveChanges();

                    result.Message = "Alumno eliminado con exito";
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                throw;
            }
            return result;

        }





    }
}
