using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Usuario" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Usuario.svc or Usuario.svc.cs at the Solution Explorer and start debugging.
    public class Usuario : IUsuario
    {

        public Result AddUsuario(ML.Usuario usuario)
        {

            ML.Result result = BL.Usuario.AddEF(usuario);

            return new Result { correct=result.Correct,ErrorMessage=result.ErrorMessage,ex=result.Ex};

        }
        public Result DeleteUsuario(int IdUsuario)
        {
            ML.Usuario usuario=new ML.Usuario();
            usuario.IdUsuario = IdUsuario;

            ML.Result result = BL.Usuario.DeleteEF(usuario);

            return new Result { correct = result.Correct, ErrorMessage = result.ErrorMessage, ex = result.Ex };
        }
        public Result UpdateUsuario(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.UpdateEF(usuario);

            return new Result { correct = result.Correct, ErrorMessage = result.ErrorMessage, ex = result.Ex };
        }

        public Result GetByIdUsuario(int IdUsuario)
        {
            ML.Result result = BL.Usuario.GetByIdEF(IdUsuario);

            return new Result { correct = result.Correct, ErrorMessage = result.ErrorMessage, ex = result.Ex,Objects=result.Objects,Object=result.Object };
        }

        public Result GetAllUsuario()
        {
            ML.Result result = BL.Usuario.GetAllEF();

            return new Result { correct = result.Correct, ErrorMessage = result.ErrorMessage, ex = result.Ex, Objects = result.Objects, Object = result.Object };
        }
    }
}
