using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", sqlConn);

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];


                    usuarios.Add(usr);
                }

                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception NoDBConn =
                new Exception("Error al recuperar lista de usuarios", Ex);
                throw NoDBConn;
            }

            return usuarios;
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_persona = @id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];
                    usr.IDPersona = (int)drUsuarios["id_persona"];
                }
                drUsuarios.Close();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", Ex);
                    throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return usr;
        }

        public Business.Entities.Usuario GetbyNomUsuario(string nomUsu)
        {
            Usuario usr = new Usuario();
            //try
            //{
            //    this.OpenConnection();
            //    SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where nombre_usuario = @nom_usu", sqlConn);
            //    cmdUsuarios.Parameters.Add("@nom_usu", SqlDbType.VarChar, 50).Value = nomUsu;
            //    SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

            //    if (drUsuarios.Read())
            //    {
            //        usr.ID = (int)drUsuarios["id_usuario"];
            //        usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
            //        usr.Clave = (string)drUsuarios["clave"];
            //        usr.Habilitado = (bool)drUsuarios["habilitado"];
            //        usr.Nombre = (string)drUsuarios["nombre"];
            //        usr.Apellido = (string)drUsuarios["apellido"];
            //        usr.EMail = (string)drUsuarios["email"];
            //        usr.IDPersona = (int)drUsuarios["id_persona"];
            //    }
            //    drUsuarios.Close();
            //}
            //catch (Exception Ex)
            //{
            //    Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", Ex);
            //    throw ExcepcionManejada;
            //}
            //finally
            //{
            //    this.CloseConnection();
            //}
            this.OpenConnection();
            SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where nombre_usuario = @nom_usu", sqlConn);
            cmdUsuarios.Parameters.Add("@nom_usu", SqlDbType.VarChar, 50).Value = nomUsu;
            SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

            if (drUsuarios.Read())
            {
                usr.ID = (int)drUsuarios["id_usuario"];
                usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                usr.Clave = (string)drUsuarios["clave"];
                usr.Habilitado = (bool)drUsuarios["habilitado"];
                usr.Nombre = (string)drUsuarios["nombre"];
                usr.Apellido = (string)drUsuarios["apellido"];
                usr.EMail = (string)drUsuarios["email"];
                usr.IDPersona = (int)drUsuarios["id_persona"];
            }
            drUsuarios.Close();
            return usr;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete =
                    new SqlCommand("delete usuarios where id_persona=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update (Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                

                if (usuario.Clave == "")
                {
                    SqlCommand cmdSave = new SqlCommand(
                        "UPDATE usuarios SET nombre_usuario = @nombre_usuario, " +
                        "habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email " +
                        "WHERE id_usuario = @id", sqlConn);

                    cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                    cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                    cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                    cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                    cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                    cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.EMail;

                    cmdSave.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmdSave = new SqlCommand(
                        "UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave, " +
                        "habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email " +
                        "WHERE id_usuario = @id", sqlConn);

                    cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                    cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                    cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                    cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                    cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                    cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                    cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.EMail;

                    cmdSave.ExecuteNonQuery();
                }
                
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into usuarios (nombre_usuario, clave, habilitado, nombre, apellido, email, id_persona) " +
                    "values (@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email, @idpersona) " +
                    "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit, 50).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.EMail;
                cmdSave.Parameters.Add("@idpersona", SqlDbType.Int).Value = usuario.IDPersona;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //así se obtiene el ID que asignó al BD automaticamente

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al manejar el usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntities.States.New)
            {
                //int NextID = 0;
                //foreach (Usuario usr in Usuarios)
                //{
                //    if (usr.ID > NextID)
                //    {
                //        NextID = usr.ID;
                //    }
                //}
                //usuario.ID = NextID + 1;
                //Usuarios.Add(usuario);

                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntities.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntities.States.Modified)
            {
                //Usuarios[Usuarios.FindIndex(delegate(Usuario u) { return u.ID == usuario.ID; })]=usuario;

                this.Update(usuario);
            }
            usuario.State = BusinessEntities.States.Unmodified;            
        }
    }
}
