using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
     public class AlumnoBeca
    {
        public static ML.Result AlumnoBecaGetByIdAlumnoLQ(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenBecasEntities1 context = new DL.ExamenBecasEntities1())
                {
                    var query = (from AlumnoBeca in context.AlumnoBeca
                                 join alumnoDatos in context.Alumno on AlumnoBeca.IdAlumno equals alumnoDatos.IdAlumno
                                 join becaDatos in context.Beca on AlumnoBeca.IdBeca equals becaDatos.IdBeca
                                 where AlumnoBeca.IdAlumno == alumnoDatos.IdAlumno
                                 where AlumnoBeca.IdBeca == becaDatos.IdBeca
                                 where AlumnoBeca.IdAlumno == IdAlumno 

                                 select new
                                 {
                                     IdAlumnoBeca = AlumnoBeca.IdAlumnoBeca,
                                     IdAlumnoDatos = alumnoDatos.IdAlumno,
                                     NombreAlumno = alumnoDatos.Nombre,
                                     ApellidoPaterno = alumnoDatos.ApellidoPaterno,
                                     ApellidoMaterno = alumnoDatos.ApellidoMaterno,
                                     Genero = alumnoDatos.Genero,
                                     Edad = alumnoDatos.Edad,
                                     IdBeca = becaDatos.IdBeca,
                                     BecaNombre = becaDatos.Nombre
                                 }
                                 
                                 ).ToList();
                    result.Objects = new List<object>();
                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.AlumnoBeca alumnoBeca = new ML.AlumnoBeca();

                            alumnoBeca.IdAlumnoBeca = obj.IdAlumnoBeca;

                            alumnoBeca.Alumno = new ML.Alumno();
                            alumnoBeca.Alumno.IdAlumno = obj.IdAlumnoDatos;
                            alumnoBeca.Alumno.Nombre = obj.NombreAlumno;
                            alumnoBeca.Alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumnoBeca.Alumno.ApellidoMaterno = obj.ApellidoMaterno;
                            alumnoBeca.Alumno.Genero = obj.Genero.Value;
                            alumnoBeca.Alumno.Edad = obj.Edad.Value;

                            alumnoBeca.Beca = new ML.Beca();
                            alumnoBeca.Beca.IdBeca = obj.IdBeca;
                            alumnoBeca.Beca.Nombre = obj.BecaNombre;

                            result.Objects.Add(alumnoBeca);

                        }

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


        public static ML.Result AddBeca(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ExamenBecasEntities1 context = new DL.ExamenBecasEntities1())
                {
                    DL.AlumnoBeca alumnobeca = new DL.AlumnoBeca();

                    alumnobeca.IdAlumno = alumno.IdAlumno;
                    alumnobeca.IdBeca = alumno.Beca.IdBeca;

                    context.AlumnoBeca.Add(alumnobeca);

                    var queryResult = context.SaveChanges();

                    if (queryResult > 0)
                    {
                        result.Correct = true;
                        result.Message = "Se ha agregado la beca";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se agregado la beca";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error; " + result.Ex;
            }


            return result;
        }

        public static ML.Result Delete(int IdBeca, int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ExamenBecasEntities1 context = new DL.ExamenBecasEntities1())
                {
                    var query = (from AlumnoBeca in context.AlumnoBeca
                                 where AlumnoBeca.IdAlumno == IdAlumno
                                 where AlumnoBeca.IdBeca == IdBeca
                                 select AlumnoBeca).First();

                    context.AlumnoBeca.Remove(query);
                    context.SaveChanges();
                }
                result.Message = "Se ha eliminado la beca del alumno";
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error; " + result.Ex;
            }
            return result;
        }

        public static ML.Result DeleteAllByIdAlumno(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenBecasEntities1 context = new DL.ExamenBecasEntities1())
                {
                    var query = (from AlumnoBeca in context.AlumnoBeca
                                 where AlumnoBeca.IdAlumno == IdAlumno

                                 select AlumnoBeca).ToList();

                    context.AlumnoBeca.RemoveRange(query);
                    context.SaveChanges();

                }

                result.Message = "Se ha eliminado la beca del alumno";
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Error; " + result.Ex;
            }

            return result;
        }


    }
}
