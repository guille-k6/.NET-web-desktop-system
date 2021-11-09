using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class CursoDocenteLogic : BusinessLogic
    {
        private DocenteCursoAdapter docCursocAdapter;
        public DocenteCursoAdapter DocCursoAdapter 
        {
            get { return docCursocAdapter; }
            set { docCursocAdapter = value; } 
        }
        public List<DocenteCurso> GetAll()
        {
            DocCursoAdapter = new DocenteCursoAdapter();
            return DocCursoAdapter.GetAll();
        }
        public DocenteCurso GetOne(int ID)
        {
            DocCursoAdapter = new DocenteCursoAdapter();
            return DocCursoAdapter.GetOne(ID);
        }
        public void Delete(int ID)
        {
            DocCursoAdapter = new DocenteCursoAdapter();
            DocCursoAdapter.Delete(ID);
        }
        public void Save(DocenteCurso docCurso)
        {
            DocCursoAdapter = new DocenteCursoAdapter();
            DocCursoAdapter.Save(docCurso);
        }
    }
}
