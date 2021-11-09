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
    public partial class CursoDesktop : ApplicationForm
    {
        public Curso CursoActual { get; set; }
        public CursoDesktop()
        {
            InitializeComponent();

            this.txtAnioCalendario.Text = DateTime.Now.Year.ToString(); 

            ComisionAdapter comAdap = new ComisionAdapter();
            var lasComisiones = new List<Comision>();
            lasComisiones = comAdap.GetAll();
            foreach (Comision element in lasComisiones)
            {
                cbIDComision.Items.Add(element.ID.ToString());
            }

            MateriaAdapter matAdap = new MateriaAdapter();
            var lasMaterias = new List<Materia>();
            lasMaterias = matAdap.GetAll();
            foreach (Materia element in lasMaterias)
            {
                cbIDMateria.Items.Add(element.ID.ToString());
            }

        }
        public CursoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }
        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            CursoLogic curLogic = new CursoLogic();
            this.CursoActual = curLogic.GetOne(ID);
            this.MapearDeDatos();
        }
        public override void MapearDeDatos() 
        {
            this.txtIDCurso.Text = this.CursoActual.ID.ToString();
            this.cbIDComision.Text = this.CursoActual.IDComision.ToString();
            this.cbIDMateria.Text = this.CursoActual.IDMateria.ToString();
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            if ( (this.Modo == ModoForm.Alta) || (this.Modo == ModoForm.Modificacion) )
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtIDCurso.Enabled = false;
                this.cbIDComision.Enabled = false;
                this.cbIDMateria.Enabled = false;
                this.txtAnioCalendario.Enabled = false;
                this.txtCupo.Enabled = false;
            }

        }
        public override void MapearADatos() 
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.CursoActual = new Curso();
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                this.CursoActual.ID = Convert.ToInt32(this.txtIDCurso.Text);
            }

            this.CursoActual.IDComision = Convert.ToInt32(this.cbIDComision.Text);
            this.CursoActual.IDMateria = Convert.ToInt32(this.cbIDMateria.Text);
            this.CursoActual.AnioCalendario = Convert.ToInt32(this.txtAnioCalendario.Text);
            this.CursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text);

            if (this.Modo == ModoForm.Alta)
            {
                this.CursoActual.State = BusinessEntities.States.New;
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                this.CursoActual.State = BusinessEntities.States.Modified;
            }
        }
        public override void GuardarCambios() 
        {
            this.MapearADatos();
            CursoLogic curLogic = new CursoLogic();
            if (this.Modo == ModoForm.Baja)
            {
                curLogic.Delete(CursoActual.ID);
            }
            else
            {
                curLogic.Save(CursoActual);
            }
        }
        public override bool Validar() 
        {
            bool val1 /*valida que los campos no esten vacios*/;

            val1 = this.cbIDComision.Text != String.Empty &&
                this.cbIDMateria.Text != String.Empty &&
                this.txtAnioCalendario.Text != String.Empty &&
                this.txtCupo.Text != String.Empty;
            int a = 2;
            if (val1 == false)
            {
                Notificar("Campos vacíos", "No puede dejar campos vacíos", (MessageBoxButtons)0, (MessageBoxIcon)48);
                return false;
            }
            if (this.txtAnioCalendario.Text == "")
            {
                Notificar("Año vacío", "El año debe ser cargado.", (MessageBoxButtons)0, (MessageBoxIcon)48);
                return false;
            }
            else if (!Int32.TryParse(this.txtCupo.Text, out a) || Convert.ToInt32(this.txtCupo.Text) > 50 || Convert.ToInt32(this.txtCupo.Text) < 20)
            {
                Notificar("Cupo inválido", "El cupo debe ser un entero entre 20 y 50", (MessageBoxButtons)0, (MessageBoxIcon)48);
                return false;
            }
            else return true;
        }
        private void CursoDesktop_Load(object sender, EventArgs e)
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
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
