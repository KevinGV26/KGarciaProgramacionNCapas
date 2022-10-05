using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {

        public static  ML.Result AddProductEF(ML.Producto producto)
        {
            ML.Result result=new ML.Result();
            try
            {
                using(DL_EF.KGarciaProgramacionNCapasEntities context=new DL_EF.KGarciaProgramacionNCapasEntities())
                {
                    var consulta = context.ProductoAdd(producto.NombreProducto,producto.PrecioUnitario,producto.Stock,
                        producto.Proveedor.IdProveedor,producto.Departamento.IdDepartamento,producto.Descripcion,null);
                    
                    if(consulta>=1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage= ex.Message;    
            }
            return result;
        }
    
        public static ML.Result UpdateProductEF(ML.Producto producto)
        {
            ML.Result result= new ML.Result();
            try
            {
                using(DL_EF.KGarciaProgramacionNCapasEntities context= new DL_EF.KGarciaProgramacionNCapasEntities())
                {
                    var query = context.ProductoUpdate(producto.IdProducto, producto.NombreProducto, producto.PrecioUnitario,
                        producto.Stock, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento, producto.Descripcion, null);
                
                    if(query>=1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al actualizar el registro";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;

            }
            return result;
        }

        public static ML.Result DeleteProductEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KGarciaProgramacionNCapasEntities context = new DL_EF.KGarciaProgramacionNCapasEntities())
                {
                    var consulta = context.ProductoDelete(producto.IdProducto);

                    if (consulta >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar el registro";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    
        public static ML.Result GetAllProductEF()
        {
            ML.Result result= new ML.Result();

            try
            {
                using(DL_EF.KGarciaProgramacionNCapasEntities context=new DL_EF.KGarciaProgramacionNCapasEntities())
                {
                    var query = context.ProductoGetAll().ToList();

                    result.Objects = new List<object>();

                    if(query !=null)
                    {
                        foreach(var obj in query)
                        {
                            ML.Producto producto= new ML.Producto();
                            
                            producto.IdProducto = obj.IdProducto;
                            producto.NombreProducto = obj.Nombre;
                            producto.PrecioUnitario=obj.PrecioUnitario;
                            producto.Stock=obj.Stock;
                            producto.Proveedor=new ML.Proveedor();
                            producto.Proveedor.IdProveedor = obj.IdProveedor.Value;
                            producto.Departamento=new ML.Departamento();
                            producto.Departamento.IdDepartamento = obj.IdDepartamento.Value;
                            producto.Descripcion =obj.Descripcion;
                              
                           //guardarlos en la lista
                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;

                        result.ErrorMessage = "erro al mostrar los productos";

                    } 
                }
            }
            catch(Exception ex)
            {
                result.Correct=false;
                result.ErrorMessage=ex.Message;
            }

            return result;
        }
    
        public static ML.Result GetByIdProductEF(int IdProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.KGarciaProgramacionNCapasEntities context= new DL_EF.KGarciaProgramacionNCapasEntities())
                {
                    var query = context.ProductoGetById(IdProducto).FirstOrDefault();

                    result.Objects = new List<object>();

                    if(query != null)
                    {
                        ML.Producto producto = new ML.Producto();
                        producto.IdProducto = query.IdProducto;
                        producto.NombreProducto = query.Nombre;
                        producto.PrecioUnitario=query.PrecioUnitario;
                        producto.Stock=query.Stock;
                        //propiedad de navegacón
                        producto.Proveedor=new ML.Proveedor();
                        producto.Proveedor.IdProveedor = query.IdProveedor.Value;
                        //Propiedad de navegación
                        producto.Departamento = new ML.Departamento();
                        producto.Departamento.IdDepartamento=query.IdDepartamento.Value;    
                        producto.Descripcion=query.Descripcion;
                        //.object porque solo queremos un dato
                        result.Object=producto;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al mostrar el producto";
                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
            }
            return result;
        }
    }
}