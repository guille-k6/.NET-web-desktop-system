using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class ModuloUsuarioLogic : BusinessLogic
    {
        private ModuloUsuarioAdapter _moduloUsuarioData;
        public ModuloUsuarioAdapter ModuloUsuarioData 
        {
            get { return _moduloUsuarioData; }
            set { _moduloUsuarioData = value; } 
        }

        public List<ModuloUsuario> GetAll()
        {
            ModuloUsuarioAdapter ModuloUsuarioData = new ModuloUsuarioAdapter();
            return ModuloUsuarioData.GetAll();
        }
        public ModuloUsuario GetOne(int ID)
        {
            ModuloUsuarioAdapter ModuloUsuarioData = new ModuloUsuarioAdapter();
            return ModuloUsuarioData.GetOne(ID);
        }
        public void Delete(int ID)
        {
            ModuloUsuarioAdapter ModuloUsuarioData = new ModuloUsuarioAdapter();
            ModuloUsuarioData.Delete(ID);
        }
        public void Save(ModuloUsuario mod)
        {
            ModuloUsuarioAdapter ModuloUsuarioData = new ModuloUsuarioAdapter();
            ModuloUsuarioData.Save(mod);
        }
    }
}
