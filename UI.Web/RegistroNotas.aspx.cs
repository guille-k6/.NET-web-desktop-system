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
    public partial class RegistroNotas : System.Web.UI.Page
    {
        CursoLogic _logic;
        private CursoLogic curLogic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new CursoLogic();
                }
                return _logic;
            }
        }
        AlumnoInscripcion alumnoInsActual { get; set; }
        private void LoadGrid()
        {
            CursoDocenteLogic curDoc = new CursoDocenteLogic();
            var losCursos = new List<Curso>();
            var DocenteCursos = curDoc.GetAll();
            foreach(DocenteCurso element in DocenteCursos)
            {
                if (element.IDDocente == Convert.ToInt32(Session["IDPerDoc"]))
                {
                    losCursos.Add(curLogic.GetOne(element.IDCurso));                   
                }
            }
            this.GridView.DataSource = losCursos;
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

        private void LoadEntity()
        {
            this.Entity = curLogic.GetOne(this.SelectedID);
        }
        protected void GridView_SelectedIndexChanged1(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridView.SelectedValue;
        }
        protected void elegirLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.Entity = new Curso();
                this.LoadEntity();
                this.LoadGrid();
                Session["IDCurso"] = Entity.ID;
                Response.Redirect("~/NotasPorCurso.aspx");
            }
        }
    }
}
