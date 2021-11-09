using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        private PlanAdapter _planData;
        public PlanAdapter PlanData 
        { 
            get { return _planData; } 
            set { _planData = value; } 
        }

        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }
        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }
        public Plan GetOne(int ID)
        {
            return PlanData.GetOne(ID);
        }
        public void Delete(int ID)
        {
            PlanData.Delete(ID);
        }
        public void Save(Plan pln)
        {
            PlanData.Save(pln);
        }
    }
}
