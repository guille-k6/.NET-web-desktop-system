using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        private MateriaAdapter _matData;

        public MateriaAdapter MatData 
        { 
            get { return _matData; }
            set { _matData = value; }
        }

        public MateriaLogic()
        {
            MatData = new MateriaAdapter();
        }

        public List<Materia> GetAll()
        {
            return MatData.GetAll();
        }
        public Materia GetOne(int ID)
        {
            return MatData.GetOne(ID);
        }
        public void Delete(int ID)
        {
            MatData.Delete(ID);
        }
        public void Save(Materia mat)
        {
            MatData.Save(mat);
        }
    }
}
