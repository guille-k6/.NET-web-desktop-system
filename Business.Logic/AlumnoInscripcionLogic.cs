using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic
    {
        private Data.Database.AlumnoInscripcionAdapter _alumnoData;
        public Data.Database.AlumnoInscripcionAdapter AlumnoData
        {
            get { return _alumnoData; }
            set { _alumnoData = value; }
        }
        public AlumnoInscripcionLogic()
        {
            this.AlumnoData = new Data.Database.AlumnoInscripcionAdapter();
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return AlumnoData.GetAll();
        }

        public List<AlumnoInscripcion> GetAllxIdCurso(int idCurso)
        {
            return AlumnoData.GetAllxIdCurso(idCurso);
        }

        public Business.Entities.AlumnoInscripcion GetOne(int id)
        {
            return AlumnoData.GetOne(id);
        }

        public void Delete(int id)
        {
            AlumnoData.Delete(id);
        }

        public void Save(Business.Entities.AlumnoInscripcion alu)
        {
            if (alu.State == BusinessEntities.States.New)
            {
                try
                {
                    ValidarLogic(alu.IDCurso, BusinessEntities.States.New);
                    AlumnoData.Save(alu);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message); // acá tira el error de que no hay cupo de ValidarLogic
                }
            }
            else
            {
                try
                {
                    ValidarLogic(alu.IDCurso, BusinessEntities.States.Modified);
                    AlumnoData.Save(alu);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }


        }

        public void ValidarLogic(int idCurso, Business.Entities.Curso.States estado)
        {
            CursoAdapter curAdapter = new CursoAdapter();
            var losCursos = new List<Business.Entities.Curso>();
            losCursos = curAdapter.GetAll();
            foreach (Business.Entities.Curso element in losCursos)
            {
                if (element.ID == Convert.ToInt32(idCurso))
                {
                    Curso elCurso = new Curso();
                    elCurso = curAdapter.GetOne(element.ID);
                    if(elCurso.Cupo > 0 && estado == BusinessEntities.States.New)
                    {
                        elCurso.Cupo = elCurso.Cupo - 1;
                        elCurso.State = Curso.States.Modified;
                        curAdapter.Save(elCurso);
                    }
                    else if(elCurso.Cupo > 0 && estado == BusinessEntities.States.Modified)
                    {
                        elCurso.State = Curso.States.Modified;
                        curAdapter.Save(elCurso);
                    }
                    else
                    {
                        throw new Exception("No hay cupo disponible para el curso: " + elCurso.ID.ToString());
                    }
                }
            }
        }


    }
}
