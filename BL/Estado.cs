using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        static public ML.Result EstadoGetByIdPais(int IdPais)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KGarciaProgramacionNCapasEntities context = new DL_EF.KGarciaProgramacionNCapasEntities())
                {
                    var query = context.EstadoGetByIdPais(IdPais).ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Estado estado = new ML.Estado();
                            estado.Nombre = obj.Nombre;
                            estado.IdEstado = obj.IdEstado;
                            estado.Pais = new ML.Pais();
                            estado.Pais.IdPais = obj.IdPais.Value;
                            result.Objects.Add(estado);
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

                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}