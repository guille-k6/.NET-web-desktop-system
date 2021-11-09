using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic
    {
        private Data.Database.PersonaAdapter _personaData;
        public Data.Database.PersonaAdapter PersonaData
        {
            get { return _personaData; }
            set { _personaData = value; }
        }

        public PersonaLogic()
        {
            this.PersonaData = new Data.Database.PersonaAdapter();
        }

        public List<Personas> GetAll()
        {
            return PersonaData.GetAll();
        }

        public Business.Entities.Personas GetOne(int id)
        {
            return PersonaData.GetOne(id);
        }

        public void Delete(int id)
        {
            PersonaData.Delete(id);

        }

        public void Save(Business.Entities.Personas per)
        {
            PersonaData.Save(per);
        }
    }
}
