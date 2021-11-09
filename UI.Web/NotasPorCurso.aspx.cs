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
    public partial class NotasPorCurso : System.Web.UI.Page
    {
        AlumnoInscripcionLogic _logic;
        private AlumnoInscripcionLogic aluinsLogic
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
        private void LoadGrid()
        {
            this.GridView.DataSource = this.aluinsLogic.GetAllxIdCurso(Convert.ToInt32(Session["IDCurso"]));
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

        private AlumnoInscripcion Entity
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
            this.Entity = this.aluinsLogic.GetOne(id);
            this.IDAlumnoTextBox.Text = this.Entity.IDAlumno.ToString();
            this.IDCursoTextBox.Text = this.Entity.IDCurso.ToString();
            this.notaTextBox.Text = this.Entity.Nota.ToString();
            this.condicionTextBox.Text = this.Entity.Condicion.ToString();

            this.IDAlumnoTextBox.Enabled = false;
            this.IDCursoTextBox.Enabled = false;
        }

        protected void actualizarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        private void LoadEntity(AlumnoInscripcion alu)
        {
            alu.IDAlumno = Convert.ToInt32(this.IDAlumnoTextBox.Text);
            alu.IDCurso = Convert.ToInt32(this.IDCursoTextBox.Text);
            alu.Nota = Convert.ToInt32(this.notaTextBox.Text);
            alu.Condicion = this.condicionTextBox.Text;
        }

        private void SaveEntity(AlumnoInscripcion aluIns)
        {
            this.aluinsLogic.Save(aluIns);
        }

        protected void AceptarLinkButton_Click(object sender, EventArgs e)
        {
            this.Entity = new AlumnoInscripcion();
            this.Entity.ID = this.SelectedID;
            this.Entity.State = BusinessEntities.States.Modified;
            this.LoadEntity(this.Entity);
            this.SaveEntity(this.Entity);
            this.LoadGrid();
            this.ClearForm();

            this.formPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            this.condicionTextBox.Enabled = enable;
            this.notaTextBox.Enabled = enable;
        }

        private void ClearForm()
        {
            this.IDAlumnoTextBox.Text = string.Empty;
            this.IDCursoTextBox.Text = string.Empty;
            this.condicionTextBox.Text = string.Empty;
            this.notaTextBox.Text = string.Empty;
        }

        protected void CancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }

        protected void GridView_SelectedIndexChanged1(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridView.SelectedValue;
        }
    }
}