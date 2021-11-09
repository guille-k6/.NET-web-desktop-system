using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Data.Database;

namespace UI.Desktop
{
    public partial class CursoDocDesktop : ApplicationForm
    {
        public DocenteCurso CursoDocActual { get; set; }

        public string Trunca(string input)
        {
            int cont = 0;
                while(!input[cont].Equals('-') && input.Length > cont)
                {
                    cont++;
                }
                string idDocente = "";
                for(int i=0; i<(cont); i++)
                {
                    idDocente = idDocente + input[i];
                }
            return idDocente;
        }

        public CursoDocDesktop()
        {
            InitializeComponent();

            PersonaAdapter adap = new PersonaAdapter();
            var losDocentes = new List<Business.Entities.Personas>();
            losDocentes = adap.GetAll();
            foreach (Business.Entities.Personas element in losDocentes)
            {
                if (element.TipoPersona == Business.Entities.Personas.TiposPersonas.docente)
                {
                    cbIDDocente.Items.Add(element.ID.ToString() +" - "+ element.Nombre.ToString() + " "+ element.Apellido.ToString());
                }
            }

            CursoAdapter curAdapter = new CursoAdapter();
            var losCursos = new List<Business.Entities.Curso>();
            losCursos = curAdapter.GetAll();
            foreach (Business.Entities.Curso element in losCursos)
            {
                cbIDCurso.Items.Add(element.ID.ToString());
            }
        }
        public CursoDocDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }
        public CursoDocDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            var curDocLogic = new CursoDocenteLogic();
            CursoDocActual = curDocLogic.GetOne(ID);
            this.MapearDeDatos();
        }
        private void CursoDocDesktop_Load(object sender, EventArgs e)
        {

        }
        public override void MapearDeDatos() 
        {
            this.txtIDDictado.Text = CursoDocActual.ID.ToString();
            this.cbIDCurso.SelectedItem = CursoDocActual.IDCurso.ToString();

            PersonaAdapter adap = new PersonaAdapter();
            var losDocentes = new List<Business.Entities.Personas>();
            losDocentes = adap.GetAll();
            string elNombre="", elApellido ="";
            foreach (Business.Entities.Personas element in losDocentes)
            {
                if (element.ID == CursoDocActual.IDDocente)
                {
                    elNombre = element.Nombre;
                    elApellido = element.Apellido;
                }
            }
            this.cbIDDocente.SelectedItem = CursoDocActual.IDDocente.ToString() + " - " + elNombre + " " + elApellido;
            this.cbCargo.SelectedIndex = Convert.ToInt32(CursoDocActual.Cargo);

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.cbIDCurso.Enabled = false;
                this.cbIDDocente.Enabled = false;
                this.cbCargo.Enabled = false;
            }
            else
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }
        public override void MapearADatos() 
        {
            if (this.Modo == ModoForm.Alta)
            {
                CursoDocActual = new DocenteCurso();
                this.CursoDocActual.State = BusinessEntities.States.New;
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                this.CursoDocActual.State = BusinessEntities.States.Modified;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                
                this.CursoDocActual.IDDocente = Convert.ToInt32(Trunca(this.cbIDDocente.Text));
                this.CursoDocActual.IDCurso = Convert.ToInt32(this.cbIDCurso.Text);
                if (this.cbCargo.SelectedIndex == 0)
                {
                    this.CursoDocActual.Cargo = Business.Entities.DocenteCurso.TiposCargos.Titular;
                }
                else if (this.cbCargo.SelectedIndex == 1)
                {
                    this.CursoDocActual.Cargo = Business.Entities.DocenteCurso.TiposCargos.Auxiliar;
                }
                    //this.CursoDocActual.Cargo = (Business.Entities.DocenteCurso.TiposCargos)(this.cbCargo.SelectedIndex+1);
            }
        }
        public override void GuardarCambios() 
        {
            MapearADatos();
            var docLogic = new CursoDocenteLogic();
            if (this.Modo == ModoForm.Baja)
            {
                docLogic.Delete(CursoDocActual.ID);
            }
            else
            {
                docLogic.Save(CursoDocActual);
            }
        }
        public override bool Validar() 
        {
            bool val1;

            // Valida que los textbox no estén vacios

            val1 = this.cbIDCurso.Text != String.Empty &&
                this.cbIDDocente.Text != String.Empty;

            if (val1 == false)
            {
                Notificar("Campos incompletos", "No todos los campos requeridos fueron completados. Por favor, intente nuevamente", (MessageBoxButtons)0, (MessageBoxIcon)48);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
            }
            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
