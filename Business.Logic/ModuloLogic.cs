using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class ModuloLogic : BusinessLogic
    {
        ModuloAdapter _moduloData;

        public ModuloAdapter ModuloData 
        {
            get { return _moduloData; }
            set { _moduloData = value; } 
        }

        public ModuloLogic()
        {
            ModuloData = new ModuloAdapter();
        }
        public List<Modulo> GetAll()
        {
            return ModuloData.GetAll();
        }
        public Modulo GetOne(int ID)
        {
            return ModuloData.GetOne(ID);
        }
        public void Delete(int ID)
        {
            ModuloData.Delete(ID);
        }
        public void Save(Modulo modulo)
        {
            ModuloData.Save(modulo);
        }
    }
}
