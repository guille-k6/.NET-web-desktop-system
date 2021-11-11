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
using System.Data.SqlClient;

namespace UI.Desktop
{
    public partial class AlumnoDesktop : ApplicationForm
    {
        public AlumnoInscripcion AlumnoActual 
        { get; set; }
        public AlumnoDesktop()
        {
            InitializeComponent();

            PersonaAdapter perAdapter = new PersonaAdapter();
            var lasPersonas = new List<Business.Entities.Personas>();
            lasPersonas = perAdapter.GetAll();
            foreach (Business.Entities.Personas element in lasPersonas)
            {
                if(element.TipoPersona == Business.Entities.Personas.TiposPersonas.alumno)
                cbIDAlumno.Items.Add(element.ID.ToString());
            }

            CursoAdapter curAdapter = new CursoAdapter();
            var losCursos = new List<Business.Entities.Curso>();
            losCursos = curAdapter.GetAll();
            foreach (Business.Entities.Curso element in losCursos)
            {
                cbIDCurso.Items.Add(element.ID.ToString());
            }
        }
        public AlumnoDesktop(ModoForm modo):this()
        {
            this.Modo = modo;
        }
        public AlumnoDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            var alu = new AlumnoInscripcionLogic();

            try
            {
                AlumnoActual = alu.GetOne(ID);
                Console.WriteLine();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al recuperar el alumno");
            }

            this.MapearDeDatos();
        }

        private void AlumnosDesktop_Load(object sender, EventArgs e)
        {

        }
        public override void MapearDeDatos() 
        {
            this.txtIDInscripcion.Text = this.AlumnoActual.ID.ToString();
            this.cbIDAlumno.SelectedItem = this.AlumnoActual.IDAlumno.ToString();
            this.cbIDCurso.SelectedItem = this.AlumnoActual.IDCurso.ToString();
            this.txtCondicion.Text = this.AlumnoActual.Condicion;
            this.txtNota.Text = this.AlumnoActual.Nota.ToString();

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtIDInscripcion.Enabled = false;
                this.cbIDAlumno.Enabled = false;
                this.cbIDCurso.Enabled = false;
                this.txtCondicion.Enabled = false;
                this.txtNota.Enabled = false;
            }
            else if (this.Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }
        public override void MapearADatos() 
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.AlumnoActual = new Business.Entities.AlumnoInscripcion();
            }

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Modo == ModoForm.Modificacion)
                {
                    this.AlumnoActual.ID = Convert.ToInt32(this.txtIDInscripcion.Text);
                }

                this.AlumnoActual.IDAlumno = Convert.ToInt32(this.cbIDAlumno.Text);
                this.AlumnoActual.IDCurso = Convert.ToInt32(this.cbIDCurso.Text);
                this.AlumnoActual.Condicion = this.txtCondicion.Text;
                if (this.txtNota.Text == "")
                {
                    this.AlumnoActual.Nota = -1;
                }
                else
                {
                    this.AlumnoActual.Nota = Convert.ToInt32(this.txtNota.Text);
                }            
            }

            if (this.Modo == ModoForm.Alta)
            {
                AlumnoActual.State = BusinessEntities.States.New;
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                AlumnoActual.State = BusinessEntities.States.Modified;
            }
            
        }
        public override void GuardarCambios() 
        {
            this.MapearADatos();
            var Alulogic = new AlumnoInscripcionLogic();

            if (this.Modo == ModoForm.Baja)
            {
                try
                {
                    Alulogic.Delete(AlumnoActual.ID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error: " + ex.ToString());
                }
            }
            else
            {
                try
                {
                    Alulogic.Save(AlumnoActual);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error: " + ex.ToString());
                }
            }
            
        }
        public override bool Validar() 
        {
            bool val1, val2;

            // Valida que los textbox no estén vacios

            val1 = this.cbIDAlumno.Text != String.Empty
            && this.cbIDCurso.Text != String.Empty
            && this.txtCondicion.Text != String.Empty;

            int a = 2; 
            
            if (!Int32.TryParse(this.txtNota.Text, out a) && this.txtNota.Text != "")
            {
                Notificar("Nota inválida", "La nota debe ser un numero entero entre 1 y 10.", (MessageBoxButtons)0, (MessageBoxIcon)48);
                return false;
            }
            else if(this.txtNota.Text != "" && (Convert.ToInt32(this.txtNota.Text) > 10 || Convert.ToInt32(this.txtNota.Text) < 0))
            {
                val2 = false;
            }
            else
            {
                val2 = true;
            }

            if (val1 == false)
            {
                Notificar("Campos incompletos", "No todos los campos requeridos fueron completados. Por favor, intente nuevamente", (MessageBoxButtons)0, (MessageBoxIcon)48);
                return false;
            }
            else if (val2 == false)
            {
                Notificar("Valor incorrecto", "La nota debe estar entre 1 y 10.", (MessageBoxButtons)0, (MessageBoxIcon)48);
                return false;
            }
            else
            {
                
                return true;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Modo == ModoForm.Baja)
            {
                GuardarCambios();
                Close();
            }
            else if (Validar())
            {
                try
                {
                    GuardarCambios(); // este es el Save
                }
                catch (Exception ex)
                {
                     Notificar("Error de inscripcion", ex.Message, (MessageBoxButtons)0, (MessageBoxIcon)48);
                }
                Close();

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbIDAlumno_SelectedValueChanged(object sender, EventArgs e)
        {
            PersonaAdapter perAdapter = new PersonaAdapter();
            var lasPersonas = new List<Business.Entities.Personas>();
            lasPersonas = perAdapter.GetAll();
            foreach (Business.Entities.Personas element in lasPersonas)
            {
                if (element.ID == Convert.ToInt32(cbIDAlumno.SelectedItem))

                    txtNombreApellido.Text = element.Nombre + " " + element.Apellido;
            }


        }

    }
}
