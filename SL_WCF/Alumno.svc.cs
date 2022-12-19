using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Alumno" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Alumno.svc or Alumno.svc.cs at the Solution Explorer and start debugging.
    public class Alumno : IAlumno
    {
        public SL_WCF.Result GetAll()
        {
            ML.Result result = BL.Alumno.GetAllLQ();
            return new SL_WCF.Result { Correct = result.Correct, Ex = result.Ex, Message = result.Message, Object = result.Object, Objects = result.Objects };
        }
        public SL_WCF.Result GetById(int IdAlumno)
        {
            ML.Result result = BL.Alumno.GetByIdLQ(IdAlumno);
            return new SL_WCF.Result { Correct = result.Correct, Ex = result.Ex, Message = result.Message, Object = result.Object, Objects = result.Objects };
        }
        public SL_WCF.Result Add(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.AddLQ(alumno);
            return new SL_WCF.Result { Correct = result.Correct, Ex = result.Ex, Message = result.Message, Object = result.Object, Objects = result.Objects };
        }

        public SL_WCF.Result Update(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.UpdateLQ(alumno);
            return new SL_WCF.Result { Correct = result.Correct, Ex = result.Ex, Message = result.Message, Object = result.Object, Objects = result.Objects };
        }

        public SL_WCF.Result Delete(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.DeleteLQ(alumno);
            return new SL_WCF.Result { Correct = result.Correct, Ex = result.Ex, Message = result.Message, Object = result.Object, Objects = result.Objects };
        }
    }
}
