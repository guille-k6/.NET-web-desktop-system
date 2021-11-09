using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        private Data.Database.UsuarioAdapter _usuarioData;
        public Data.Database.UsuarioAdapter UsuarioData
        {
            get { return _usuarioData; }
            set { _usuarioData = value; }
        }
        //public UsuarioLogic()
        //{
        //    this.UsuarioData = new Data.Database.UsuarioAdapter();
        //}

        public List<Usuario> GetAll()
        {
            try
            {
                UsuarioAdapter UsuarioData = new UsuarioAdapter();
                return UsuarioData.GetAll();
            }
            catch (Exception)
            {
                //throw;
                // Acá habria que logear (registrar) la verdadera excepcion
                throw new Exception("No se pudieron consultar los usuarios.");
            }
        }

        public Business.Entities.Usuario GetOne(int id) 
        {
            try
            {
                UsuarioAdapter UsuarioData = new UsuarioAdapter();
                return UsuarioData.GetOne(id);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo recuperar el usuario seleccionado.");
            }
        }

        public Business.Entities.Usuario GetbyNomUsuario(string nomUsu)
        {
            //try
            //{
            //    UsuarioAdapter UsuarioData = new UsuarioAdapter();
            //    return UsuarioData.GetbyNomUsuario(nomUsu);
            //}
            //catch (Exception)
            //{
            //    throw new Exception("No se pudo recuperar el usuario seleccionado.");
            //}
            UsuarioAdapter UsuarioData = new UsuarioAdapter();
            return UsuarioData.GetbyNomUsuario(nomUsu);
        }

        public void Delete(int id)
        {
            try
            {
                UsuarioAdapter UsuarioData = new UsuarioAdapter();
                UsuarioData.Delete(id);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo eliminar el usuario seleccionado.");
            }
        }

        public void Save(Business.Entities.Usuario usu)
        {
            //try
            {
                UsuarioAdapter UsuarioData = new UsuarioAdapter();
                UsuarioData.Save(usu);
            }
            //catch (Exception)
            {
            //    throw new Exception("No se pudo guardar el usuario.");
            }
        }
    }
}