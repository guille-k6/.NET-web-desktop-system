using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        ComisionAdapter _comAdapter;

        public ComisionAdapter ComAdapter 
        {
            get { return _comAdapter; }
            set { _comAdapter = value; } 
        }

        public ComisionLogic()
        {
            ComAdapter = new ComisionAdapter();
        }

        public List<Comision> GetAll()
        {
            return ComAdapter.GetAll();
        }
        public Comision GetOne(int ID)
        {
            return ComAdapter.GetOne(ID);
        }
        public void Delete(int ID)
        {
            ComAdapter.Delete(ID);
        }
        public void Save(Comision com)
        {
            ComAdapter.Save(com);
        }
    }
}
