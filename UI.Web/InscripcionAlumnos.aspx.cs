using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class InscripcionAlumnos : System.Web.UI.Page
    {
        AlumnoInscripcionLogic _logic;
        private AlumnoInscripcionLogic aluLogic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new AlumnoInscripcionLogic();
                }
                return _logic;
            }
        }
        CursoLogic _curLogic;
        private CursoLogic curLogic
        {
            get
            {
                if (_curLogic == null)
                {
                    _curLogic = new CursoLogic();
                }
                return _curLogic;
            }
        }
        AlumnoInscripcion alumnoInsActual { get; set; }
        private void LoadGrid()
        {
            this.GridView.DataSource = this.curLogic.GetAll();
            this.GridView.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
            }
        }
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get
            {
                return (FormModes)this.ViewState["FormMode"];
            }
            set
            {
                this.ViewState["FormMode"] = value;
            }
        }

        private Curso Entity
        {
            get;
            set;
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }
        private void LoadForm(int id)
        {
            this.Entity = this.curLogic.GetOne(id);
            this.idTextBox.Text = this.Entity.ID.ToString();
            this.idComisionTextBox.Text = this.Entity.IDComision.ToString();
            this.idMateriaTextBox.Text = this.Entity.IDMateria.ToString();
            this.cupoTextBox.Text = this.Entity.Cupo.ToString();
            this.anioCalTextBox.Text = this.Entity.AnioCalendario.ToString();
        }

        private void LoadEntity(AlumnoInscripcion aluIns)
        {
            //if (this.FormMode == FormModes.Modificacion || this.FormMode == FormModes.Baja)
            //{
            //    especialidad.ID = Convert.ToInt32(this.idTextBox.Text);
            //}
            aluIns.IDAlumno = Convert.ToInt32(Session["IDPerAlu"]);
            this.Entity = curLogic.GetOne(this.SelectedID);
            aluIns.IDCurso = this.Entity.ID;
            aluIns.Nota = -1;
            aluIns.Condicion = "inscripto";
        }

        private void SaveEntity(AlumnoInscripcion aluIns)
        {
            this.aluLogic.Save(aluIns);
        }

        protected void AceptarLinkButton_Click(object sender, EventArgs e)
        {
            this.alumnoInsActual = new AlumnoInscripcion();
            this.LoadEntity(this.alumnoInsActual);
            this.SaveEntity(this.alumnoInsActual);
            this.LoadGrid();
            Response.Redirect("~/Default.aspx?msj=Inscripción realizada correctamente");
            this.formPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            this.idTextBox.Enabled = false;
        }

        private void ClearForm()
        {
            this.idTextBox.Text = string.Empty;
            this.idComisionTextBox.Text = string.Empty;
            this.idMateriaTextBox.Text = string.Empty;
            this.cupoTextBox.Text = string.Empty;
            this.anioCalTextBox.Text = string.Empty;
        }

        protected void CancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }

        protected void GridView_SelectedIndexChanged1(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridView.SelectedValue;
        }

        protected void inscripcionLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Alta;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }
    }
}