using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Becas
    {
        public static ML.Result GetAllLQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenBecasEntities1 context = new DL.ExamenBecasEntities1())
                {
                    var query = from Becas in context.Beca select Becas;
                    result.Objects = new List<object>();
                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Beca beca = new ML.Beca();

                            beca.IdBeca = obj.IdBeca;
                            beca.Nombre = obj.Nombre;
                  


                            result.Objects.Add(beca);
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


    }
}
