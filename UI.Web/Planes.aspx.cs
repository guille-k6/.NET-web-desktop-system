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
    public partial class Planes : System.Web.UI.Page
    {
        PlanLogic _logic;
        private PlanLogic plnLogic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PlanLogic();
                }
                return _logic;
            }
        }
        private void LoadGrid()
        {
            this.GridView.DataSource = this.plnLogic.GetAll();
            this.GridView.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
                EspecialidadLogic espLogic = new EspecialidadLogic();
                List<Especialidad> lista = espLogic.GetAll();
                foreach (Especialidad element in lista)
                {
                    idEspDropDown.Items.Add(element.ID.ToString());
                }
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

        private Plan Entity
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
            this.Entity = this.plnLogic.GetOne(id);
            this.idTextBox.Text = this.Entity.ID.ToString();
            this.descripcionTextBox.Text = this.Entity.Descripcion;
            if (this.FormMode != FormModes.Alta)
            {
                this.idEspDropDown.SelectedValue = this.Entity.IDEspecialidad.ToString();
            }
            //else
            //{
            //    this.idEspDropDown.SelectedIndex = 0;
            //}
            this.idTextBox.Enabled = false;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        private void LoadEntity(Plan plan)
        {
            if (this.FormMode == FormModes.Modificacion || this.FormMode == FormModes.Baja)
            {
                plan.ID = Convert.ToInt32(this.idTextBox.Text);
            }
            plan.Descripcion = this.descripcionTextBox.Text;
            plan.IDEspecialidad = Convert.ToInt32(this.idEspDropDown.SelectedValue);
        }

        private void SaveEntity(Plan plan)
        {
            this.plnLogic.Save(plan);
        }

        protected void AceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entity = new Plan();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Plan();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntities.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }

            this.formPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            this.idTextBox.Enabled = false;
            this.descripcionTextBox.Enabled = enable;
            this.idEspDropDown.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
                //Debido a que los controles quedan deshabilitados luego de ingresar al formulario
                //para eliminar un Usuario hay que volver a habilitarlos antes de Editar.
                //Para lograr esto alcanza con agregar una llamada al método EnableForm en el
                //Event Handler de editarLinkButton ya existente.
            }
        }
        private void DeleteEntity(int id)
        {
            this.plnLogic.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);

        }

        private void ClearForm()
        {
            this.idTextBox.Text = string.Empty;
            this.descripcionTextBox.Text = string.Empty;
            this.idEspDropDown.SelectedIndex = 0;
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