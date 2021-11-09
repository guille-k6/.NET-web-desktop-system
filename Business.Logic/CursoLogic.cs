using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;
using Data.Database;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        CursoAdapter _curAdapter;
        public CursoAdapter CurAdapter 
        {
            get { return _curAdapter; }
            set { _curAdapter = value; } 
        }

        public CursoLogic()
        {
            this.CurAdapter = new CursoAdapter();
        }
        public List<Curso> GetAll()
        {
            return CurAdapter.GetAll();
        }
        public Curso GetOne(int ID)
        {
            return CurAdapter.GetOne(ID);
        }
        public void Delete(int ID)
        {
            CurAdapter.Delete(ID);
        }
        public void Save(Curso cur)
        {
            CurAdapter.Save(cur);
        }
    }
}
