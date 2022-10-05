using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {

        //metodos
        public static void Add()
        {


            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el nombre:");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el ApellidoPaterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el ApellidoMaterno");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el Email");
            usuario.Email = Console.ReadLine();

            usuario.Rol = new ML.Rol();

            Console.WriteLine("Ingrese el Id del Rol");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el passowrd");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Ingrese el sexo");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese el telefono");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese el celular");
            usuario.Celular=Console.ReadLine();

            Console.WriteLine("Ingrese su fecha de nacimiento");
            usuario.FechaNacimiento= Console.ReadLine();

            Console.WriteLine("Ingrese su curp");
            usuario.Curp= Console.ReadLine();

            Console.WriteLine("Username");
            usuario.UserName = Console.ReadLine();

            usuario.Direccion = new ML.Direccion();

            Console.WriteLine("Calle");
            usuario.Direccion.Calle = Console.ReadLine();

            Console.WriteLine("Numero Interior");
            usuario.Direccion.NumeroInterior = Console.ReadLine();

            Console.WriteLine("Numero Exterior");
            usuario.Direccion.NumeroExterior = Console.ReadLine();


            //Instanciar
            usuario.Direccion.Colonia = new ML.Colonia();

            Console.Write("Colonia");
            usuario.Direccion.Colonia.IdColonia=int.Parse(Console.ReadLine());






            //ML.Result result = BL.Usuario.Add(usuario);
            //ML.Result result = BL.Usuario.AddSP(usuario);
            //ML.Result result = BL.Usuario.AddEF(usuario);
            //ML.Result result = BL.Usuario.AddLINQ(usuario);

            ServiceReference1.UsuarioClient obj=new ServiceReference1.UsuarioClient();
            var result=obj.AddUsuario(usuario);

            if (result.correct)
            {
                Console.WriteLine("Registro exitoso");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al realizar la insercion");
            }
        }

        public  static void Update()
        {
            ML.Usuario usuario=new ML.Usuario();

            Console.WriteLine("Indique el id del usuario a modificar");

            usuario.IdUsuario = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el ApellidoPaterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el ApellidoMaterno");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el Email");
            usuario.Email = Console.ReadLine();

            usuario.Rol = new ML.Rol();

            Console.WriteLine("Ingrese el Id del Rol");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el passowrd");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Ingrese el sexo");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese el telefono");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese el celular");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingrese su fecha de nacimiento");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingrese su curp");
            usuario.Curp = Console.ReadLine();

            Console.WriteLine("Username");
            usuario.UserName = Console.ReadLine();

            usuario.Direccion = new ML.Direccion();

            Console.WriteLine("Calle");
            usuario.Direccion.Calle = Console.ReadLine();

            Console.WriteLine("Numero Interior");
            usuario.Direccion.NumeroInterior = Console.ReadLine();

            Console.WriteLine("Numero Exterior");
            usuario.Direccion.NumeroExterior = Console.ReadLine();


            //Instanciar
            usuario.Direccion.Colonia = new ML.Colonia();

            Console.WriteLine("Colonia");
            usuario.Direccion.Colonia.IdColonia = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.Update(usuario);
            //ML.Result result = BL.Usuario.UpdateSP(usuario);
            //ML.Result result = BL.Usuario.UpdateEF(usuario);
            //ML.Result result = BL.Usuario.UpdateLINQ(usuario);


            ServiceReference1.UsuarioClient obj = new ServiceReference1.UsuarioClient();
            var result = obj.UpdateUsuario(usuario);



            if (result.correct)
            {
                Console.WriteLine("Actualización exitoso");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Ocurrio un error al realizar la insercion");
            }
        }
        public static void Delete()
        {
            ML.Usuario usuario =new ML.Usuario();

            Console.WriteLine("Indique el id del usuario a eliminar");

            usuario.IdUsuario=Convert.ToInt32(Console.ReadLine());

            //ML.Result result=BL.Usuario.Delete(usuario);
            //ML.Result result = BL.Usuario.DeleteSP(usuario);

            //ML.Result result = BL.Usuario.DeleteEF(usuario);

            //ML.Result result = BL.Usuario.DeleteLINQ(usuario);
            ServiceReference1.UsuarioClient obj = new ServiceReference1.UsuarioClient();

            var result = obj.DeleteUsuario(usuario.IdUsuario);

            if (result.correct)
            {
                Console.WriteLine("Eliminado Correctamente");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Ocurrio un error al eliminar");
            }
        }
    
        public static void GetAll()
        {
            //ML.Result result = BL.Usuario.GetAllSP();

            //ML.Result result = BL.Usuario.GetAllEF();

            //ML.Result result=BL.Usuario.GetAllLINQ();

            ServiceReference1.UsuarioClient obj = new ServiceReference1.UsuarioClient();
            var result = obj.GetAllUsuario();
            if (result.correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    //imprimir los datos del objeto
                    Console.WriteLine("IdUsuario :" + usuario.IdUsuario);
                    Console.WriteLine(" ");
                    Console.WriteLine("Nombre: "+ usuario.Nombre);
                    Console.WriteLine(" ");
                    Console.WriteLine("ApellidoPaterno: " + usuario.ApellidoPaterno);
                    Console.WriteLine(" ");
                    Console.WriteLine("ApellidoMaterno: " + usuario.ApellidoMaterno);
                    Console.WriteLine(" ");
                    Console.WriteLine("Email: " + usuario.Email);
                    Console.WriteLine(" ");
                    Console.WriteLine("Rol: " + usuario.Rol.IdRol);
                    Console.WriteLine(" ");
                    Console.WriteLine("password: " + usuario.Password);
                    Console.WriteLine("Sexo: " + usuario.Sexo);
                    Console.WriteLine(" ");
                    Console.WriteLine("Telefono: " + usuario.Telefono);
                    Console.WriteLine(" ");
                    Console.WriteLine("Celular: " + usuario.Celular);
                    Console.WriteLine(" ");
                    Console.WriteLine("Fecha de nacimiento: " + usuario.FechaNacimiento);
                    Console.WriteLine(" ");
                    Console.WriteLine("Curp: " + usuario.Curp);
                    Console.WriteLine(" ");
                    Console.WriteLine("User Name: "+usuario.UserName);
                    Console.WriteLine("..........");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Ocurrio un error");

                Console.ReadKey();
            }
        }
    
        public static void GetById()
        {
            Console.WriteLine("Ingrese el id: ");

            //ML.Result result = BL.Usuario.GetByIdSP(int.Parse(Console.ReadLine()));
            //ML.Result result = BL.Usuario.GetByIdEF(int.Parse(Console.ReadLine()));

            ServiceReference1.UsuarioClient obj = new ServiceReference1.UsuarioClient();
            var result = obj.GetByIdUsuario(int.Parse(Console.ReadLine()));

            //ML.Result result = BL.Usuario.GetByIdLINQ(int.Parse(Console.ReadLine()));
            if (result.correct)
            {

                //unboxing
                ML.Usuario usuario = ((ML.Usuario)result.Object);
                Console.WriteLine("IdUsuario" + usuario.IdUsuario);
                Console.WriteLine("Nombre" + usuario.Nombre);
                Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
                Console.WriteLine("Apellido Materno:" + usuario.ApellidoMaterno);
                Console.WriteLine("Email: " + usuario.Email);
                Console.WriteLine("IdRol:" + usuario.Rol.IdRol);
                Console.WriteLine("password: " + usuario.Password);
                Console.WriteLine("Sexo: " + usuario.Sexo);
                Console.WriteLine("Telefono: " + usuario.Telefono);
                Console.WriteLine("Celular: " + usuario.Celular);
                Console.WriteLine("Fecha de nacimiento: " + usuario.FechaNacimiento);
                Console.WriteLine("Curp: " + usuario.Curp);
                Console.WriteLine("User Name: " + usuario.UserName);
                Console.WriteLine("..........");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ocurrio un error al realizar la consulta" + result.ErrorMessage);
                Console.ReadKey();

            }
        }
    
    
    }
}