using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ModuloUsuarioAdapter : Adapter
    {
        public List<ModuloUsuario> GetAll()
        {
            List<ModuloUsuario> moduloUsuarios = new List<ModuloUsuario>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdModuloUsuarios = new SqlCommand("select * from modulos_usuarios", sqlConn);

                SqlDataReader drModuloUsuarios = cmdModuloUsuarios.ExecuteReader();

                while (drModuloUsuarios.Read())
                {
                    ModuloUsuario mod = new ModuloUsuario();

                    mod.ID = (int)drModuloUsuarios["id_modulo_usuario"];
                    mod.IdModulo = (int)drModuloUsuarios["id_modulo"];
                    mod.IdUsuario = (int)drModuloUsuarios["id_usuario"];
                    mod.PermiteAlta = (bool)drModuloUsuarios["alta"];
                    mod.PermiteBaja = (bool)drModuloUsuarios["baja"];
                    mod.PermiteConsulta = (bool)drModuloUsuarios["consulta"];
                    mod.PermiteModificacion = (bool)drModuloUsuarios["modificacion"];

                    moduloUsuarios.Add(mod);
                }

                drModuloUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception NoDBConn =
                new Exception("Error al recuperar lista de modulos de usuarios", Ex);
                throw NoDBConn;
            }

            return moduloUsuarios;
        }

        public Business.Entities.ModuloUsuario GetOne(int ID)
        {
            ModuloUsuario mod = new Business.Entities.ModuloUsuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModuloUsuarios = new SqlCommand("select * from modulos_usuarios where id_modulo_usuario = @id", sqlConn);
                cmdModuloUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModuloUsuarios = cmdModuloUsuarios.ExecuteReader();

                if (drModuloUsuarios.Read())
                {
                    mod.ID = (int)drModuloUsuarios["id_modulo_usuario"];
                    mod.IdModulo = (int)drModuloUsuarios["id_modulo"];
                    mod.IdUsuario = (int)drModuloUsuarios["id_usuario"];
                    mod.PermiteAlta = (bool)drModuloUsuarios["alta"];
                    mod.PermiteBaja = (bool)drModuloUsuarios["baja"];
                    mod.PermiteConsulta = (bool)drModuloUsuarios["consulta"];
                    mod.PermiteModificacion = (bool)drModuloUsuarios["modificacion"];
                }
                drModuloUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de modulo de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return mod;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete =
                    new SqlCommand("delete modulos_usuarios where id_modulo_usuario=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar modulo de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(ModuloUsuario moduloUsuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE modulos_usuarios SET id_modulo = @id_modulo, " +
                    "id_usuario = @id_usuario, alta = @alta, baja = @baja, " +
                    "modificacion = @modificacion, consulta = @consulta " +
                    "WHERE id_modulo_usuario = @id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = moduloUsuario.ID;
                cmdSave.Parameters.Add("@id_modulo", SqlDbType.VarChar, 50).Value = moduloUsuario.IdModulo;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.VarChar, 50).Value = moduloUsuario.IdUsuario;
                cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = moduloUsuario.PermiteAlta;
                cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = moduloUsuario.PermiteBaja;
                cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = moduloUsuario.PermiteModificacion;
                cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = moduloUsuario.PermiteConsulta;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del modulo de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(ModuloUsuario moduloUsuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, " +
                    "consulta) values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, " +
                    "@consulta) select @@identity", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = moduloUsuario.ID;
                cmdSave.Parameters.Add("@id_modulo", SqlDbType.VarChar, 50).Value = moduloUsuario.IdModulo;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.VarChar, 50).Value = moduloUsuario.IdUsuario;
                cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = moduloUsuario.PermiteAlta;
                cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = moduloUsuario.PermiteBaja;
                cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = moduloUsuario.PermiteModificacion;
                cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = moduloUsuario.PermiteConsulta;
                moduloUsuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //así se obtiene el ID que asignó al BD automaticamente

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al manejar el modulo de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(ModuloUsuario moduloUsuario)
        {
            if (moduloUsuario.State == BusinessEntities.States.New)
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

                this.Insert(moduloUsuario);
            }
            else if (moduloUsuario.State == BusinessEntities.States.Deleted)
            {
                this.Delete(moduloUsuario.ID);
            }
            else if (moduloUsuario.State == BusinessEntities.States.Modified)
            {
                //Usuarios[Usuarios.FindIndex(delegate(Usuario u) { return u.ID == usuario.ID; })]=usuario;

                this.Update(moduloUsuario);
            }
            moduloUsuario.State = BusinessEntities.States.Unmodified;
        }
    }
}
