using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Proveedor
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KGarciaProgramacionNCapasEntities context = new DL_EF.KGarciaProgramacionNCapasEntities())
                {
                    var query = context.ProveedorGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Proveedor proveedor=new ML.Proveedor();
            

                            proveedor.IdProveedor = obj.IdProveedor;
                            proveedor.Telefono = obj.Telefono;
                            proveedor.Nombre = obj.nombre;
                            result.Objects.Add(proveedor);
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
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
