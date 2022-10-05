using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Producto
    {
        public static void AddProduct()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Nombre del producto: ");
            producto.NombreProducto =Console.ReadLine();

            Console.WriteLine("Precio unitario: ");
            producto.PrecioUnitario=int.Parse(Console.ReadLine());
            Console.WriteLine("Stock: ");
            producto.Stock=Convert.ToInt32(Console.ReadLine());

            producto.Proveedor=new ML.Proveedor();
            Console.WriteLine("Id del Proveedor: ");
            producto.Proveedor.IdProveedor = Convert.ToInt32(Console.ReadLine());   

            producto.Departamento=new ML.Departamento();
            Console.WriteLine("Id del Departamento: ");
            producto.Departamento.IdDepartamento = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Descripcion: ");
            producto.Descripcion = Console.ReadLine();

            ML.Result result = BL.Producto.AddProductEF(producto);


            if(result.Correct)
            {
                Console.WriteLine("Registro exitoso del producto");

            }
            else
            {
                Console.WriteLine("Ocurrio un eror");
            }
        }
    
        public static void UpdateProduct()
        {
            ML.Producto producto= new ML.Producto();

            Console.WriteLine("Digite el id del producto que desea actualizar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Nombre del producto");
            producto.NombreProducto=Console.ReadLine();

            Console.WriteLine("Nuevo Precio");
            producto.PrecioUnitario=int.Parse(Console.ReadLine());

            Console.WriteLine("Nuevo Stock");
            producto.Stock=int.Parse(Console.ReadLine());


            producto.Proveedor=new ML.Proveedor();
            Console.WriteLine("Nuevo id proveedor");
            producto.Proveedor.IdProveedor=int.Parse(Console.ReadLine()); 

            producto.Departamento=new ML.Departamento();
            Console.WriteLine("Nuevo Departamento");
            producto.Departamento.IdDepartamento=int.Parse(Console.ReadLine());

            Console.WriteLine("Nueva descripción");
            producto.Descripcion=Console.ReadLine();

            ML.Result result=BL.Producto.UpdateProductEF(producto); 

            if(result.Correct)
            {
                Console.WriteLine("Registro acutalizado exitosamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al actualizar el producto");
            }


        }
    
        public static void DeleteProduct()
        {
            ML.Producto producto=new ML.Producto();

            Console.WriteLine("Digite el id del usuario a elminar");
            producto.IdProducto = Convert.ToInt32(Console.ReadLine());


            ML.Result result=BL.Producto.DeleteProductEF(producto);

            if(result.Correct)
            {
                Console.WriteLine("Registro eliminado correactamente");

            }
            else
            {
                Console.WriteLine("Eror al intentar elminar el registro");
            }
        }
   
        public static void GetAllProduct()
        {
            ML.Result result = BL.Producto.GetAllProductEF();

            if(result.Correct)
            {
                foreach(ML.Producto producto in result.Objects)
                {
                    Console.WriteLine("Producto:" + producto.IdProducto);
                    Console.WriteLine("Nombre:" + producto.NombreProducto);
                    Console.WriteLine("Precio unitario:" + producto.PrecioUnitario);
                    Console.WriteLine("Stock: " + producto.Stock);
                    Console.WriteLine("IdProveedor: " + producto.Proveedor.IdProveedor);
                    Console.WriteLine("IdDepartamento: " + producto.Departamento.IdDepartamento);
                    Console.WriteLine("Descripcion: " + producto.Descripcion);
                    Console.WriteLine("......");
                }
            }
            else
            {
                Console.WriteLine("Ocurrio un error");
            }
        }
    
        public static void GetByIdProduct()
        {

            Console.WriteLine("Ponga el id del producto que quiere que se muestre");

            ML.Result result =BL.Producto.GetByIdProductEF(int.Parse(Console.ReadLine()));

            if (result.Correct)
            {
                ML.Producto producto = ((ML.Producto) result.Object);

                Console.WriteLine("Id del Producto:"+producto.IdProducto);
                Console.WriteLine("Nombre: " + producto.NombreProducto);
                Console.WriteLine("Precio Unitario: " + producto.PrecioUnitario);
                Console.WriteLine("Stock: " + producto.Stock);
                Console.WriteLine("Id Proveedor: "+ producto.Proveedor.IdProveedor);
                Console.WriteLine("Id Departamento" + producto.Departamento.IdDepartamento);
                Console.WriteLine("Descripcion: " + producto.Descripcion);
                Console.WriteLine(" ");

            }
            else
            {
              Console.WriteLine("Ocurrio un error al mostrar el producto solicidato"+ result.ErrorMessage);
            }

        }
    }
}
