using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml;
using Business.Entities;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        private Data.Database.EspecialidadAdapter _especialidadData;
        public Data.Database.EspecialidadAdapter EspecialidadData
        {
            get { return _especialidadData; }
            set { _especialidadData = value; }
        }
        public EspecialidadLogic()
        {
            this.EspecialidadData = new Data.Database.EspecialidadAdapter();
        }

        public List<Especialidad> GetAll()
        {
            try
            {
                return EspecialidadData.GetAll();
            }
            catch (Exception)
            {
                //throw;
                // Acá habria que logear (registrar) la verdadera excepcion
                throw new Exception("No se pudieron consultar las especialidades.");
            }
        }

        public Business.Entities.Especialidad GetOne(int id)
        {
            try
            {
                return EspecialidadData.GetOne(id);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo recuperar la especialidad seleccionada.");
            }
        }

        public void Delete(int id)
        {
            try
            {
                EspecialidadData.Delete(id);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo eliminar la especialidad seleccionada.");
            }
        }

        public void Save(Business.Entities.Especialidad esp)
        {
            EspecialidadData.Save(esp);

            //try
            //{
            //    EspecialidadData.Save(esp);
            //}
            //catch (Exception)
            //{
            //    throw new Exception("No se pudo guardar la especialidad.");
            //}
        }
    }
}
