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
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docenteCursos = new List<DocenteCurso>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdDocenteCursos = new SqlCommand("select * from docentes_cursos", sqlConn);

                SqlDataReader drDocenteCursos = cmdDocenteCursos.ExecuteReader();

                while (drDocenteCursos.Read())
                {
                    DocenteCurso docCur = new DocenteCurso();

                    docCur.ID = (int)drDocenteCursos["id_dictado"];
                    docCur.IDCurso = (int)drDocenteCursos["id_curso"];
                    docCur.IDDocente = (int)drDocenteCursos["id_docente"];
                    docCur.Cargo = (DocenteCurso.TiposCargos)drDocenteCursos["cargo"];

                    docenteCursos.Add(docCur);
                }

                drDocenteCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception NoDBConn =
                new Exception("Error al recuperar lista de cursos de docentes", Ex);
                throw NoDBConn;
            }

            return docenteCursos;
        }

        public Business.Entities.DocenteCurso GetOne(int ID)
        {
            DocenteCurso docCur = new Business.Entities.DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocenteCursos = new SqlCommand("select * from docentes_cursos where id_dictado = @id", sqlConn);
                cmdDocenteCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocenteCursos = cmdDocenteCursos.ExecuteReader();

                if (drDocenteCursos.Read())
                {
                    docCur.ID = (int)drDocenteCursos["id_dictado"];
                    docCur.IDCurso = (int)drDocenteCursos["id_curso"];
                    docCur.IDDocente = (int)drDocenteCursos["id_docente"];
                    docCur.Cargo = (DocenteCurso.TiposCargos)drDocenteCursos["cargo"];
                }
                drDocenteCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de curso del docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return docCur;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete =
                    new SqlCommand("delete docentes_cursos where id_dictado=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar curso del docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE docentes_cursos SET id_curso = @id_curso, " +
                    "id_docente = @id_docente, cargo = @cargo " +
                    "WHERE id_dictado = @id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = docenteCurso.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCurso.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.VarChar, 50).Value = docenteCurso.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = Convert.ToInt32(docenteCurso.Cargo);

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del curso del docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(DocenteCurso docenteCurso)
        {
            //try
            //{
            //    this.OpenConnection();
            //    SqlCommand cmdSave = new SqlCommand(
            //        "insert into docentes_cursos (id_curso, id_docente, cargo) " +
            //        "values (@id_curso, @id_docente, @cargo) " +
            //        "select @@identity", sqlConn);
            //    cmdSave.Parameters.Add("@id_curso", SqlDbType.VarChar, 50).Value = docenteCurso.IDCurso;
            //    cmdSave.Parameters.Add("@id_docente", SqlDbType.VarChar, 50).Value = docenteCurso.IDDocente;
            //    cmdSave.Parameters.Add("@cargo", SqlDbType.VarChar, 50).Value = docenteCurso.Cargo;
            //    docenteCurso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            //    //así se obtiene el ID que asignó al BD automaticamente

            //}
            //catch (Exception Ex)
            //{
            //    Exception ExcepcionManejada = new Exception("Error al manejar el curso del docente", Ex);
            //    throw ExcepcionManejada;
            //}
            //finally
            //{
            //    this.CloseConnection();
            //}
            this.OpenConnection();
            SqlCommand cmdSave = new SqlCommand(
                "insert into docentes_cursos (id_curso, id_docente, cargo) " +
                "values (@id_curso, @id_docente, @cargo) " +
                "select @@identity", sqlConn);
            cmdSave.Parameters.Add("@id_curso", SqlDbType.VarChar, 50).Value = docenteCurso.IDCurso;
            cmdSave.Parameters.Add("@id_docente", SqlDbType.VarChar, 50).Value = docenteCurso.IDDocente;
            cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = Convert.ToInt32(docenteCurso.Cargo);
            docenteCurso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
        }

        public void Save(DocenteCurso docenteCurso)
        {
            if (docenteCurso.State == BusinessEntities.States.New)
            {
                this.Insert(docenteCurso);
            }
            else if (docenteCurso.State == BusinessEntities.States.Deleted)
            {
                this.Delete(docenteCurso.ID);
            }
            else if (docenteCurso.State == BusinessEntities.States.Modified)
            {
                this.Update(docenteCurso);
            }
            docenteCurso.State = BusinessEntities.States.Unmodified;
        }
    }
}
