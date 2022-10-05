using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {



            int numero = 0;

            Console.WriteLine("Que desea hacer");

            Console.WriteLine("1 Insertar usuario desde el servicio");
            Console.WriteLine("2 Actualizar usuario");
            Console.WriteLine("3 Eliminar usuario");
            Console.WriteLine("4 Leer/Mostrar usuario");
            Console.WriteLine("5 Mostrar por Id usuario");
            Console.WriteLine(".....");
            Console.WriteLine("Acciones para producto");
            Console.WriteLine("6 Insertar producto");
            Console.WriteLine("7 Actualizar producto");
            Console.WriteLine("8 Eliminar producto");
            Console.WriteLine("9 Mostrar productos");
            Console.WriteLine("10 Mostrar prodcuto por Id");
            Console.WriteLine("11 saludar servicio");
            Console.WriteLine("12 Suma");
            Console.WriteLine("13  Resta");
            numero = Convert.ToInt32(Console.ReadLine());

            switch (numero)
            {
                case 1:
                    PL.Usuario.Add();
                    break;
                case 2:
                    PL.Usuario.Update();
                    break;
                case 3:
                    PL.Usuario.Delete();
                    break;
                case 4:
                    PL.Usuario.GetAll();
                    break;
                case 5:
                    PL.Usuario.GetById();
                    break;
                case 6:
                    PL.Producto.AddProduct();
                    break;
                case 7:
                    PL.Producto.UpdateProduct();
                    break;
                case 8:
                    PL.Producto.DeleteProduct();
                    break;
                case 9:
                    PL.Producto.GetAllProduct();
                    break;
                case 10:
                    PL.Producto.GetByIdProduct();
                    break;
                case 11:
                    ServiceSaludar.Service1Client obj = new ServiceSaludar.Service1Client();

                    Console.WriteLine("Escribe tu nombre");

                    var respuesta = obj.Saludar(Console.ReadLine());

                    Console.WriteLine(respuesta);
                    break;
                case 12:
                    OperacionesService.OperacionesClient suma = new OperacionesService.OperacionesClient();
                    Console.WriteLine("escribe el numero 1: ");
                    int suma1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("escribe el numero 2: ");
                    int suma2 = int.Parse(Console.ReadLine());
                    var respuesta2 = suma.Suma(suma1, suma2);
                    Console.WriteLine(respuesta2);
                    Console.ReadLine();
                    break;
                case 13:            
                    OperacionesService.OperacionesClient resta = new OperacionesService.OperacionesClient();
                    Console.WriteLine("escribe el numero 1: ");
                    int numero1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("escribe el numero 2: ");
                    int numero2 = int.Parse(Console.ReadLine());
                    var resultado = resta.Resta(numero1, numero2);
                    Console.WriteLine(resultado);
                    Console.ReadLine();
                    break;
                case 14:

                    OperacionesService.OperacionesClient Multiplicacion = new OperacionesService.OperacionesClient();
                    Console.WriteLine("escribe el numero 1: ");
                    int num1= int.Parse(Console.ReadLine());
                    Console.WriteLine("escribe el numero 2: ");
                    int num2 = int.Parse(Console.ReadLine());
                    var resultadoMultplicacion = Multiplicacion.Multiplicacion(num1, num2);
                    Console.WriteLine(resultadoMultplicacion);
                    Console.ReadLine();
                    break;
                case 15:
                    OperacionesService.OperacionesClient Division = new OperacionesService.OperacionesClient();
                    Console.WriteLine("escribe el numero 1: ");
                    double divnumero1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("escribe el numero 2: ");
                    double Divnumero2 = double.Parse(Console.ReadLine());
                    var ResultadoDivision = Division.Division(divnumero1, Divnumero2);
                    Console.WriteLine(ResultadoDivision);
                    Console.ReadLine();
                    break;

                    

            }
        }
    }
}
