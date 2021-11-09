using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			/* IMPORTANTE: 
			 * Arreglar: 
						- En CursoDocDesktop ver de agregar pestaña a campo "Cargo"
			*/

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new CursosDocentes()); // X
			//Application.Run(new ModuloUsuarios());
			//Application.Run(new Modulos());
			//Application.Run(new Cursos()); // X 
			//Application.Run(new Comisiones()); // X
			//Application.Run(new Materias()); // X 
			//Application.Run(new Planes()); // X 
			//Application.Run(new Especialidades()); // X 
			//Application.Run(new Alumnos()); // X
			//Application.Run(new Usuarios()); // X
			//Application.Run(new Personas()); // X
			//Application.Run(new ReporteCursos());
			//Application.Run(new ReportePlanes());
			Application.Run(new Menu());
			// Consultar por claves foráneas en la baja (FK).
		}
	}
}
