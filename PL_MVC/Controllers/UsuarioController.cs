using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]

        //Obtener todos los registros
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();


            //ML.Result result = BL.Usuario.GetAllEF();

            //Usando el servicio
            CrudServicios.UsuarioClient obj = new CrudServicios.UsuarioClient();
            var result = obj.GetAllUsuario();

            if (result.correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                result.correct = false;
                result.ErrorMessage = "Ocurrio  un error";

            }
            return View(usuario);
        }

        [HttpGet]
        //Los muestra precargado
        public ActionResult Form(int ? IdUsuario)
        {
            // instanciamos el modelo
            ML.Usuario usuario=new ML.Usuario();


            //instanciamo el rol
            usuario.Rol = new ML.Rol();

            ML.Result resultrol = BL.Rol.GetAll();
            ML.Result resultPais = BL.Pais.GetAll();

            
            if (resultrol.Correct && resultPais.Correct)
            {
                if (IdUsuario == null)
                {//Add

                    usuario.Rol = new ML.Rol();
                    usuario.Rol.Roles = resultrol.Objects;
                    usuario.Direccion = new ML.Direccion();
                    usuario.Direccion.Colonia = new ML.Colonia();
                    usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                    usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                    usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                    return View(usuario);
                }
                else //Update
                {
                    CrudServicios.UsuarioClient obj=new CrudServicios.UsuarioClient();

                    var result = obj.GetByIdUsuario(IdUsuario.Value);

                    //ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);
                    if (result.correct)
                    {
                        usuario = ((ML.Usuario)result.Object);
                        ML.Result resultEstado = BL.Estado.EstadoGetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                        ML.Result resultMunicipio = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                        ML.Result resultColonia = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.Roles = resultrol.Objects;
                        usuario.Direccion.Colonia.Colonias= resultColonia.Objects;
                        usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipio.Objects;
                        usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstado.Objects;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;

                        return View(usuario);
                    }
                    else
                    {
                        result.correct = false;
                    }
                }
            }
            else
            {
                ViewBag.Mensaje = "Ocurrio un error al realizar la consulta" + resultrol.ErrorMessage;
                
            }
            return View("Modal");
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {

            if(usuario.IdUsuario==0)
            {//add
                //instanciamos el metodo result y asignamos la capa del metodo agregar
                //ML.Result result = BL.Usuario.AddEF(usuario);

                CrudServicios.UsuarioClient obj = new CrudServicios.UsuarioClient();
                var result = obj.AddUsuario(usuario);
                //Validamos
                if (result.correct)
                {
                    ViewBag.Mensaje = "Se inserto correctamente";
                }
                else
                {
                    result.correct = false;
                    ViewBag.Mensaje = "error al insertar"+result.ErrorMessage;
                    
                }
                return View("Modal");

            }
            else //Update
            {

                CrudServicios.UsuarioClient obj = new CrudServicios.UsuarioClient();

                var result = obj.UpdateUsuario(usuario);
                //ML.Result result = BL.Usuario.UpdateEF(usuario);

                usuario = (ML.Usuario)result.Object;
            }
            return View("Modal");
        }


        public ActionResult Delete(int IdUsuario)
        {
            //instaciamos el modelo
            ML.Usuario usuario = new ML.Usuario();

            //Indica que sera solo por medio del IdUsuario
            usuario.IdUsuario = IdUsuario;

            //Mandamos llamer  el metodo
            CrudServicios.UsuarioClient obj=new CrudServicios.UsuarioClient();

            var result = obj.DeleteUsuario(IdUsuario);
            //ML.Result result = BL.Usuario.DeleteEF(usuario);

            //Validacion
            if (result.correct)
            {
                ViewBag.Mensaje = "Eliminado Correctamente";
            }
            else
            {
                ViewBag.Mensaje = "Ocurrio un error al eliminar";
            }
            //Regresamos la vista del modal
            return View("Modal");
        }

        public JsonResult EstadoGetByIdPais(int IdPais)
        {
            ML.Result result = BL.Estado.EstadoGetByIdPais(IdPais);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MunicipioGetByIdEstado(int IdEstado)
        {
            ML.Result result = BL.Municipio.GetByIdEstado(IdEstado);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ColoniaGetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = BL.Colonia.GetByIdMunicipio(IdMunicipio);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
    }
}