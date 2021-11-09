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
    public class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> alumnos = new List<AlumnoInscripcion>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumnos = new SqlCommand("select * from alumnos_inscripciones", sqlConn);

                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();

                while (drAlumnos.Read())
                {
                    AlumnoInscripcion alu = new AlumnoInscripcion();

                    alu.ID = (int)drAlumnos["id_inscripcion"];
                    alu.IDAlumno = (int)drAlumnos["id_alumno"];
                    alu.IDCurso = (int)drAlumnos["id_curso"];
                    alu.Condicion = (string)drAlumnos["condicion"];
                    alu.Nota = (int)drAlumnos["nota"];

                    alumnos.Add(alu);
                }

                drAlumnos.Close();
            }
            catch (Exception Ex)
            {
                Exception NoDBConn =
                new Exception("Error al recuperar lista de alumnos", Ex);
                throw NoDBConn;
            }

            return alumnos;
        }

        public List<AlumnoInscripcion> GetAllxIdCurso(int idCurso)
        {
            List<AlumnoInscripcion> alumnos = new List<AlumnoInscripcion>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumnos = new SqlCommand("select * from alumnos_inscripciones where id_curso=@idCurso", sqlConn);
                cmdAlumnos.Parameters.Add("@idCurso", SqlDbType.Int).Value = idCurso;
                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();

                while (drAlumnos.Read())
                {
                    AlumnoInscripcion alu = new AlumnoInscripcion();

                    alu.ID = (int)drAlumnos["id_inscripcion"];
                    alu.IDAlumno = (int)drAlumnos["id_alumno"];
                    alu.IDCurso = (int)drAlumnos["id_curso"];
                    alu.Condicion = (string)drAlumnos["condicion"];
                    alu.Nota = (int)drAlumnos["nota"];

                    alumnos.Add(alu);
                }

                drAlumnos.Close();
            }
            catch (Exception Ex)
            {
                Exception NoDBConn =
                new Exception("Error al recuperar lista de alumnos", Ex);
                throw NoDBConn;
            }

            return alumnos;
        }

        public Business.Entities.AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion alu = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnos = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion = @id", sqlConn);
                cmdAlumnos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();

                if (drAlumnos.Read())
                {
                    alu.ID = (int)drAlumnos["id_inscripcion"];
                    alu.IDAlumno = (int)drAlumnos["id_alumno"];
                    alu.IDCurso = (int)drAlumnos["id_curso"];
                    alu.Condicion = (string)drAlumnos["condicion"];
                    alu.Nota = (int)drAlumnos["nota"];
                }
                drAlumnos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return alu;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete =
                    new SqlCommand("delete from alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(AlumnoInscripcion alumno)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE alumnos_inscripciones SET " +
                    "id_alumno = @id_alumno, condicion = @condicion, nota = @nota " +
                    "WHERE id_inscripcion = @id_inscripcion", sqlConn);
                
                //cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = alumno.ID;
                cmdSave.Parameters.Add("@id_inscripcion", SqlDbType.Int).Value = alumno.ID;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumno.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumno.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alumno.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alumno.Nota;

                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(AlumnoInscripcion alumno)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into alumnos_inscripciones (id_alumno, id_curso, condicion, nota) " +
                    "values (@id_alumno, @id_curso, @condicion, @nota) " +
                    "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumno.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumno.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alumno.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.VarChar, 50).Value = alumno.Nota;
                alumno.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //alumno.ID = 4;
                //así se obtiene el ID que asignó al BD automaticamente

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al manejar (agregar) el alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            
        }
            
        public void Save(AlumnoInscripcion alumno)
        {
            if (alumno.State == BusinessEntities.States.New)
            {
                this.Insert(alumno);
            }
            else if (alumno.State == BusinessEntities.States.Deleted)
            {
                this.Delete(alumno.ID);
            }
            else if (alumno.State == BusinessEntities.States.Modified)
            {
                this.Update(alumno);
            }
            alumno.State = BusinessEntities.States.Unmodified;
        }
    }
}
