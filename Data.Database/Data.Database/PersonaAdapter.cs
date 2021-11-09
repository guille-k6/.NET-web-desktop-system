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
    public class PersonaAdapter : Adapter
    {
        public List<Personas> GetAll()
        {
            List<Personas> personas = new List<Personas>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas", sqlConn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Personas per = new Personas();

                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.TipoPersona = (Personas.TiposPersonas)((int)drPersonas["tipo_persona"]);
                    per.IDPlan = (int)drPersonas["id_plan"];

                    personas.Add(per);
                }

                drPersonas.Close();
            }
            catch (Exception ex)
            {
                Exception nodbconn =
                new Exception("error al recuperar lista de personas", ex);
                throw nodbconn;
            }
            return personas;           
        }

        public Business.Entities.Personas GetOne(int ID)
        {
            Personas per = new Personas();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona = @id", sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.TipoPersona = (Personas.TiposPersonas)((int)drPersonas["tipo_persona"]);
                    per.IDPlan = (int)drPersonas["id_plan"];
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return per;
        }

        public void Delete(int ID)
        {
            //try
            {
                this.OpenConnection();
                SqlCommand cmdDelete =
                    new SqlCommand("delete personas where id_persona=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
           // catch (Exception Ex)
            {
           //     Exception ExcepcionManejada =
           //         new Exception("Error al eliminar persona", Ex);
           //     throw ExcepcionManejada;
            }
           // finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Personas persona)
        {
            try
            {
                this.OpenConnection();


                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE personas SET nombre = @nombre, apellido = @apellido, direccion = @direccion, " +
                    "email = @email, telefono = @telefono, fecha_nac = @fecha_nac, legajo = @legajo, " +
                    "tipo_persona = @tipo_persona, id_plan = @id_plan " +
                    "WHERE id_persona = @id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Personas persona)
        {
            //try
            //{
            //    this.OpenConnection();
            //    SqlCommand cmdSave = new SqlCommand(
            //        "insert into personas (nombre, apellido, direccion, email, telefono, fecha_nac, legajo, " +
            //        "tipo_persona, id_plan) values (@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, " +
            //        "@tipo_persona, @id_plan) " +
            //        "select @@identity", sqlConn);
            //    cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
            //    cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
            //    cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
            //    cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
            //    cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
            //    cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
            //    cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
            //    cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
            //    cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
            //    persona.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            //    //así se obtiene el ID que asignó al BD automaticamente

            //}
            //catch (Exception Ex)
            //{
            //    Exception ExcepcionManejada = new Exception("Error al manejar la persona", Ex);
            //    throw ExcepcionManejada;
            //}
            //finally
            //{
            //    this.CloseConnection();
            //}

            this.OpenConnection();
            SqlCommand cmdSave = new SqlCommand(
                "insert into personas (nombre, apellido, direccion, email, telefono, fecha_nac, legajo, " +
                "tipo_persona, id_plan) values (@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, " +
                "@tipo_persona, @id_plan) " +
                "select @@identity", sqlConn);
            cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
            cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
            cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
            cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
            cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
            cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
            cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
            cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = Convert.ToInt32(persona.TipoPersona);
            cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
            persona.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
        }

        public void Save(Personas persona)
        {
            if (persona.State == BusinessEntities.States.New)
            {

                this.Insert(persona);
            }
            else if (persona.State == BusinessEntities.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntities.States.Modified)
            {

                this.Update(persona);
            }
            persona.State = BusinessEntities.States.Unmodified;
        }
    }
}
