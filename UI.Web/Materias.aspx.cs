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
    public partial class Materias : System.Web.UI.Page
    {
        MateriaLogic _logic;
        private MateriaLogic matLogic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new MateriaLogic();
                }
                return _logic;
            }
        }
        private void LoadGrid()
        {
            this.GridView.DataSource = this.matLogic.GetAll();
            this.GridView.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
                PlanLogic plnLogic = new PlanLogic();
                List<Plan> lista = plnLogic.GetAll();
                foreach (Plan element in lista)
                {
                    idPlanDropDown.Items.Add(element.ID.ToString());
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

        private Materia Entity
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
            this.Entity = this.matLogic.GetOne(id);
            this.idTextBox.Text = this.Entity.ID.ToString();
            this.descripcionTextBox.Text = this.Entity.Descripcion;
            this.hsSemanalesTextBox.Text = this.Entity.HSSemanales.ToString();
            this.hsTotalesTextBox.Text = this.Entity.HSTotales.ToString();
            if (this.FormMode != FormModes.Alta)
            {
                this.idPlanDropDown.SelectedValue = this.Entity.IDPlan.ToString();
            }
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

        private void LoadEntity(Materia materia)
        {
            if (this.FormMode == FormModes.Modificacion || this.FormMode == FormModes.Baja)
            {
                materia.ID = Convert.ToInt32(this.idTextBox.Text);
            }
            materia.Descripcion = this.descripcionTextBox.Text;
            materia.HSSemanales = Convert.ToInt32(this.hsSemanalesTextBox.Text);
            materia.HSTotales = Convert.ToInt32(this.hsTotalesTextBox.Text);
            materia.IDPlan = Convert.ToInt32(this.idPlanDropDown.SelectedValue);
        }

        private void SaveEntity(Materia materia)
        {
            this.matLogic.Save(materia);
        }

        protected void AceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entity = new Materia();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Materia();
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
            this.idPlanDropDown.Enabled = enable;
            this.hsSemanalesTextBox.Enabled = enable;
            this.hsTotalesTextBox.Enabled = enable;
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
            this.matLogic.Delete(id);
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
            this.hsSemanalesTextBox.Text = string.Empty;
            this.hsTotalesTextBox.Text = string.Empty;
            this.idPlanDropDown.SelectedIndex = 0;
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
    