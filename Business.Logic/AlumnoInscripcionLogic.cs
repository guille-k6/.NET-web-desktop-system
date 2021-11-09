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
            AlumnoData.Save(alu);
        }
    }
}
