using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios
    {
        private Business.Logic.UsuarioLogic _usuarioNegocio;
        public Business.Logic.UsuarioLogic UsuarioNegocio
        {
            get { return _usuarioNegocio; }
            set { _usuarioNegocio = value; }
        }
        public Usuarios()
        {
            this.UsuarioNegocio = new UsuarioLogic();
        }
        public void Menu()
        {
            Console.WriteLine("Ingrese opcion deseada: \n\n1– Listado General\n2- Consulta\n3- Agregar\n4- Modificar\n5- Eliminar\n6- Salir");
            int opc = Convert.ToInt32(Console.ReadLine());
                while ((opc >= 1) && (opc <= 5))
                {
                    switch (opc)
                    {
                        case 1:
                            this.ListadoGeneral();
                            break;
                        case 2:
                            this.Consultar();
                            break;
                        case 3:
                            this.Agregar();
                            break;

                        case 4:
                            this.Modificar();
                            break;
                        case 5:
                            this.Eliminar();
                            break;
                    }
                    Console.WriteLine("\nPresione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Ingrese opcion deseada: 1– Listado General\n2- Consulta\n3- Agregar\n4- Modificar\n5- Eliminar\n6- Salir");
                    opc = Convert.ToInt32(Console.ReadLine());

            }

        }
        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }

        }

        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: "+ usr.ID);
            Console.WriteLine("\t\tNombre: "+ usr.Nombre);
            Console.WriteLine("\t\tApellido: "+ usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: "+ usr.NombreUsuario);
            Console.WriteLine("\t\tClave: "+ usr.Clave);
            Console.WriteLine("\t\tEmail: "+ usr.EMail);
            Console.WriteLine("\t\tHabilitado: "+ usr.Habilitado);
            Console.WriteLine();
        }
        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero.");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
            }

        }
        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a modificar");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.Write("Ingrese nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.Write("Ingrese apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.Write("Ingrese nombre de usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("Ingrese EMail: ");
                usuario.EMail = Console.ReadLine();
                Console.Write("Ingrese habilitacion de usuario (1-Si / Otro-No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntities.States.Modified;
                UsuarioNegocio.Save(usuario);
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");

            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
            }

        }
        public void Agregar()
        {
            Usuario usuario = new Usuario();

            Console.Clear();
            Console.Write("Ingrese nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Ingrese apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("Ingrese nombre de usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese clave: ");
            usuario.Clave = Console.ReadLine();
            Console.Write("Ingrese EMail: ");
            usuario.EMail = Console.ReadLine();
            Console.Write("Ingrese habilitacion de usuario (1-Si / Otro-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntities.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: " + usuario.ID);

        }
        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");

            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
            }
        }

    }
}
