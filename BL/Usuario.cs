using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Globalization;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "INSERT INTO [Usuario] ([Nombre],[ApellidoPaterno],[ApellidoMaterno],[Email])VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @Email)";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[3].Value = usuario.Email;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

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


        public static ML.Result Update(ML.Usuario usuario)
        { 
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UPDATE [Usuario] SET [Nombre] = @Nombre,[ApellidoPaterno] = @ApellidoPaterno,[ApellidoMaterno] = @ApellidoMaterno,[Email] = @Email WHERE [IdUsuario]=@IdUsuario";
                    using(SqlCommand cmd=new SqlCommand())
                    {
                        cmd.Connection = contex;

                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[4].Value = usuario.Email;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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

        public static ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context=new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "DELETE FROM [Usuario] WHERE  [IdUsuario]=@IdUsuario";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection =context;

                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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


        public static ML.Result AddSP(ML.Usuario usuario)
        {
        
            ML.Result result=new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UsuarioAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[3].Value = usuario.Email;

                        collection[4]=new SqlParameter("IdRol",SqlDbType.Int);
                        collection[4].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();


                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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

        public static ML.Result UpdateSP(ML.Usuario usuario)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UsuarioUpdate";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;   
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0]=new SqlParameter("IdUsuario",SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("Nombre",SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[4].Value = usuario.Email;
                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();


                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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

        public static ML.Result DeleteSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result(); 
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UsuarioDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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

        public static ML.Result GetAllSP()
        {
            ML.Result result=new ML.Result();
            try
            {
                using(SqlConnection context= new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UsuarioGetAll";
                    using(SqlCommand cmd= new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType= CommandType.StoredProcedure;

                        DataTable tableuser= new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableuser);

                        if(tableuser.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach(DataRow row in tableuser.Rows)
                            {
                                ML.Usuario usuario= new ML.Usuario();

                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.Nombre=row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno= row[3].ToString(); 
                                usuario.Email=row[4].ToString();

                                usuario.Rol = new ML.Rol();

                                usuario.Rol.IdRol=int.Parse(row[5].ToString());      
                                
                                result.Objects.Add(usuario);

                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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
    
        public static ML.Result GetByIdSP(int IdUsuario)
        {
            ML.Result result=new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UsuarioById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableUsuario = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            DataRow row = tableUsuario.Rows[0];

                            ML.Usuario usuario= new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.Email = row[4].ToString();

                            usuario.Rol = new ML.Rol();

                            usuario.Rol.IdRol = int.Parse(row[5].ToString());

                            result.Object = usuario; //BOXING 

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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

        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KGarciaProgramacionNCapasEntities context = new DL_EF.KGarciaProgramacionNCapasEntities())
                {

                    var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno, usuario.Email, usuario.Rol.IdRol, usuario.Password,
                        usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.FechaNacimiento, usuario.Curp,
                        null, usuario.UserName,null,usuario.Direccion.Calle,usuario.Direccion.NumeroInterior,
                        usuario.Direccion.NumeroExterior,usuario.Direccion.Colonia.IdColonia);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";

                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }


        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.KGarciaProgramacionNCapasEntities context=new DL_EF.KGarciaProgramacionNCapasEntities())
                {
                    var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre,
                        usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email,
                        usuario.Rol.IdRol, usuario.Password, usuario.Sexo, usuario.Telefono,
                        usuario.Celular, usuario.FechaNacimiento, usuario.Curp, null,usuario.UserName,null,usuario.Direccion.IdDireccion,usuario.Direccion.Calle,usuario.Direccion.NumeroInterior
                        ,usuario.Direccion.NumeroExterior,usuario.Direccion.Colonia.IdColonia);

                    if(query >=1)
                    {
                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó el registro";

                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;

        }

        
        public static ML.Result DeleteEF(ML.Usuario usuario)
        {
            ML.Result result=new ML.Result();

            try
            {
                using(DL_EF.KGarciaProgramacionNCapasEntities context= new DL_EF.KGarciaProgramacionNCapasEntities())
                {
                    var query = context.UsuarioDelete(usuario.IdUsuario);

                    if(query >=1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se elimino el registro";
                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }
    
        public static ML.Result GetAllEF()
        {
            ML.Result result= new ML.Result();
            try
            {
                using(DL_EF.KGarciaProgramacionNCapasEntities context= new DL_EF.KGarciaProgramacionNCapasEntities())
                {
                    var query = context.UsuarioGetAll("","","").ToList();
                    result.Objects = new List<object>();

                    if(query != null)
                    {
                        foreach(var obj in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario =obj.IdUsuario ;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.Email = obj.Email;
                            usuario.Rol=new ML.Rol();
                            usuario.Rol.IdRol = obj.IdRol.Value;
                            usuario.Rol.Nombre = obj.NombreRol;
                            usuario.Password = obj.password;
                            usuario.Sexo = obj.sexo;
                            usuario.Telefono=obj.Telefono;
                            usuario.Celular = obj.Celular;
                            usuario.FechaNacimiento= obj.FechaNacimiento.ToString();
                            usuario.Curp = obj.Curp;
                            usuario.UserName = obj.UserName;
 
                           

                            usuario.Direccion=new ML.Direccion();
                            usuario.Direccion.IdDireccion = obj.IdDireccion;
                            usuario.Direccion.Calle = obj.Calle;
                            usuario.Direccion.NumeroInterior=obj.NumeroInterior;
                            usuario.Direccion.NumeroExterior=obj.NumeroExterior;

                            usuario.Direccion.Colonia=new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = obj.IdColonia.Value;
                            usuario.Direccion.Colonia.Nombre = obj.NombreColonia;

                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio.Value;
                            usuario.Direccion.Colonia.Municipio.Nombre = obj.NombreMunicipio;

                            usuario.Direccion.Colonia.Municipio.Estado=new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = obj.IdEstado.Value;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = obj.NombreEstado;

                            usuario.Direccion.Colonia.Municipio.Estado.Pais= new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais=obj.IdPais.Value;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = obj.NombrePais;

       

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }

                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }

        public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.KGarciaProgramacionNCapasEntities context=new DL_EF.KGarciaProgramacionNCapasEntities())
                {
                    var query = context.UsuarioById(IdUsuario).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario= query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.Email = query.Email;
                        //instanciar la clase rol y poner value
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.IdRol.Value;
                        usuario.Password = query.password;
                        usuario.Sexo = query.sexo;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.FechaNacimiento = query.FechaNacimiento.ToString();
                        usuario.Curp = query.Curp;
                        usuario.UserName = query.UserName;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = query.IdDireccion;

                        usuario.Direccion.Calle = query.Calle;
                        usuario.Direccion.NumeroInterior = query.NumeroInterior;
                        usuario.Direccion.NumeroExterior = query.NumeroExterior;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = query.IdColonia.Value;
                        usuario.Direccion.Colonia.Nombre = query.NombreColonia;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = query.IdMunicipio.Value;
                        usuario.Direccion.Colonia.Municipio.Nombre = query.NombreMunicipio;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = query.IdEstado.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = query.NombreEstado;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = query.IdPais.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = query.NombrePais;



                        result.Object = usuario;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener el registro solicitado";

                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;
        }

        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KGarciaProgramacionNCapasEntities context = new DL_EF.KGarciaProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioLinq = new DL_EF.Usuario();

                    usuarioLinq.Nombre = usuario.Nombre;
                    usuarioLinq.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioLinq.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioLinq.Email = usuario.Email;
                    usuarioLinq.IdRol = usuario.Rol.IdRol;
                    usuarioLinq.password = usuario.Password;
                    usuarioLinq.sexo = usuario.Sexo;
                    usuarioLinq.Telefono = usuario.Telefono;
                    usuarioLinq.Celular = usuario.Celular;
                    usuarioLinq.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    usuarioLinq.Curp = usuario.Curp;
                    usuarioLinq.UserName = usuario.UserName;

                    if (usuarioLinq != null)
                    {
                        context.Usuarios.Add(usuarioLinq);
                        context.SaveChanges();
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

        public static ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.KGarciaProgramacionNCapasEntities context = new DL_EF.KGarciaProgramacionNCapasEntities())
                {
                    var query = (from a in context.Usuarios
                                 where a.IdUsuario == usuario.IdUsuario
                                 select a).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = usuario.Nombre;
                        query.ApellidoPaterno = usuario.ApellidoPaterno;
                        query.ApellidoMaterno=usuario.ApellidoMaterno;
                        query.Email = usuario.Email;
                        query.IdRol=usuario.Rol.IdRol;
                        query.password = usuario.Password;
                        query.sexo = usuario.Sexo;
                        query.Telefono= usuario.Telefono;
                        query.Celular = usuario.FechaNacimiento;
                        query.Curp=usuario.Curp;
                        query.UserName = usuario.UserName;
                        context.SaveChanges();
                        result.Correct = true;
                    }


                }
            }catch(Exception ex)
            {
                result.Correct = false; 
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result DeleteLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.KGarciaProgramacionNCapasEntities context=new DL_EF.KGarciaProgramacionNCapasEntities())
                {
                    var query=(from DeleteLINQ in context.Usuarios 
                               where DeleteLINQ.IdUsuario==usuario.IdUsuario select DeleteLINQ).First();


                    if(query!=null)
                    {
                        result.Correct = true;
                        context.Usuarios.Remove(query);
                        context.SaveChanges();
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se elimino el registro";
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

        public static ML.Result GetAllLINQ()
        {
            ML.Result result=new ML.Result();       
            try
            {
                using(DL_EF.KGarciaProgramacionNCapasEntities context=new DL_EF.KGarciaProgramacionNCapasEntities())
                {
                    var UsuarioList = (from usuario in context.Usuarios
                                       select new
                                       {
                                           usuario.IdUsuario,
                                           usuario.Nombre,
                                           usuario.ApellidoPaterno,
                                           usuario.ApellidoMaterno,
                                           usuario.Email,
                                           usuario.IdRol,
                                           usuario.password,
                                           usuario.sexo,
                                           usuario.Telefono,
                                           usuario.Celular,
                                           usuario.FechaNacimiento,
                                           usuario.Curp,
                                           usuario.UserName

                                       }).ToList();
                    if (UsuarioList.Count > 1)
                    {
                        result.Objects = new List<object>();
                        foreach (var user in UsuarioList)
                        {
                           ML.Usuario usuario1=new ML.Usuario();

                            usuario1.IdUsuario = user.IdUsuario;
                            usuario1.Nombre = user.Nombre;
                            usuario1.ApellidoPaterno = user.ApellidoPaterno;
                            usuario1.ApellidoMaterno = user.ApellidoMaterno;
                            usuario1.Email = user.Email;
                            usuario1.Rol = new ML.Rol();
                            usuario1.Rol.IdRol = user.IdRol.Value;
                            usuario1.Password = user.password;
                            usuario1.Sexo = user.sexo;
                            usuario1.Telefono = user.Telefono;
                            usuario1.Celular = user.Celular;
                            //no se parcea
                            usuario1.FechaNacimiento=user.FechaNacimiento.ToString();
                            usuario1.Curp = user.Curp;
                            usuario1.UserName= user.UserName;
                            result.Objects.Add(usuario1);

                        }
                        result.Correct = true;
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

        public static ML.Result GetByIdLINQ(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.KGarciaProgramacionNCapasEntities context = new DL_EF.KGarciaProgramacionNCapasEntities())
                {
                    var obj = context.UsuarioById(IdUsuario).FirstOrDefault();


                    if(obj!=null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario= obj.IdUsuario;
                        usuario.Nombre=obj.Nombre;
                        usuario.ApellidoPaterno = obj.ApellidoPaterno;
                        usuario.ApellidoPaterno = obj.ApellidoMaterno;
                        usuario.Email=obj.Email;
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = obj.IdRol.Value;
                        usuario.Password = obj.password;
                        usuario.Sexo = obj.sexo;
                        usuario.Telefono = obj.Telefono;
                        usuario.Celular = obj.Celular;
                        usuario.FechaNacimiento = obj.FechaNacimiento.ToString();
                        usuario.Curp = obj.Curp;
                        usuario.UserName = obj.UserName;
                        result.Object = usuario;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct=false;
                        result.ErrorMessage = "Error";
                    }

                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}