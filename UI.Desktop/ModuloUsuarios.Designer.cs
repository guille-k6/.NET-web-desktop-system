
namespace UI.Desktop
{
    partial class ModuloUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tscModulosUsuarios = new System.Windows.Forms.ToolStripContainer();
            this.tlModulosUsuarios = new System.Windows.Forms.TableLayoutPanel();
            this.dgvModulosUsuarios = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.IDModuloUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Baja = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Modificacion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Consulta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tscModulosUsuarios.ContentPanel.SuspendLayout();
            this.tscModulosUsuarios.TopToolStripPanel.SuspendLayout();
            this.tscModulosUsuarios.SuspendLayout();
            this.tlModulosUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulosUsuarios)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscModulosUsuarios
            // 
            // 
            // tscModulosUsuarios.ContentPanel
            // 
            this.tscModulosUsuarios.ContentPanel.Controls.Add(this.tlModulosUsuarios);
            this.tscModulosUsuarios.ContentPanel.Size = new System.Drawing.Size(1244, 597);
            this.tscModulosUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscModulosUsuarios.Location = new System.Drawing.Point(0, 0);
            this.tscModulosUsuarios.Name = "tscModulosUsuarios";
            this.tscModulosUsuarios.Size = new System.Drawing.Size(1244, 624);
            this.tscModulosUsuarios.TabIndex = 0;
            this.tscModulosUsuarios.Text = "toolStripContainer1";
            // 
            // tscModulosUsuarios.TopToolStripPanel
            // 
            this.tscModulosUsuarios.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // tlModulosUsuarios
            // 
            this.tlModulosUsuarios.ColumnCount = 2;
            this.tlModulosUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlModulosUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlModulosUsuarios.Controls.Add(this.dgvModulosUsuarios, 0, 0);
            this.tlModulosUsuarios.Controls.Add(this.btnActualizar, 0, 1);
            this.tlModulosUsuarios.Controls.Add(this.btnSalir, 1, 1);
            this.tlModulosUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlModulosUsuarios.Location = new System.Drawing.Point(0, 0);
            this.tlModulosUsuarios.Name = "tlModulosUsuarios";
            this.tlModulosUsuarios.RowCount = 2;
            this.tlModulosUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlModulosUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlModulosUsuarios.Size = new System.Drawing.Size(1244, 597);
            this.tlModulosUsuarios.TabIndex = 0;
            // 
            // dgvModulosUsuarios
            // 
            this.dgvModulosUsuarios.AllowUserToAddRows = false;
            this.dgvModulosUsuarios.AllowUserToDeleteRows = false;
            this.dgvModulosUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModulosUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDModuloUsuario,
            this.IDModulo,
            this.IDUsuario,
            this.Alta,
            this.Baja,
            this.Modificacion,
            this.Consulta});
            this.tlModulosUsuarios.SetColumnSpan(this.dgvModulosUsuarios, 2);
            this.dgvModulosUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvModulosUsuarios.Location = new System.Drawing.Point(3, 3);
            this.dgvModulosUsuarios.MultiSelect = false;
            this.dgvModulosUsuarios.Name = "dgvModulosUsuarios";
            this.dgvModulosUsuarios.ReadOnly = true;
            this.dgvModulosUsuarios.RowHeadersWidth = 51;
            this.dgvModulosUsuarios.RowTemplate.Height = 24;
            this.dgvModulosUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModulosUsuarios.Size = new System.Drawing.Size(1238, 562);
            this.dgvModulosUsuarios.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(1076, 571);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(84, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1166, 571);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(4, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(100, 27);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = global::UI.Desktop.Properties.Resources._1486395885_plus_80605;
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(29, 24);
            this.tsbNuevo.Text = "toolStripButton1";
            this.tsbNuevo.ToolTipText = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = global::UI.Desktop.Properties.Resources._1486395883_edit_80608;
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(29, 24);
            this.tsbEditar.Text = "toolStripButton2";
            this.tsbEditar.ToolTipText = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = global::UI.Desktop.Properties.Resources._1486395882_close_80604;
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(29, 24);
            this.tsbEliminar.Text = "toolStripButton3";
            this.tsbEliminar.ToolTipText = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // IDModuloUsuario
            // 
            this.IDModuloUsuario.DataPropertyName = "ID";
            this.IDModuloUsuario.HeaderText = "ID Módulo usuario";
            this.IDModuloUsuario.MinimumWidth = 6;
            this.IDModuloUsuario.Name = "IDModuloUsuario";
            this.IDModuloUsuario.ReadOnly = true;
            this.IDModuloUsuario.Width = 125;
            // 
            // IDModulo
            // 
            this.IDModulo.DataPropertyName = "IDModulo";
            this.IDModulo.HeaderText = "ID Módulo";
            this.IDModulo.MinimumWidth = 6;
            this.IDModulo.Name = "IDModulo";
            this.IDModulo.ReadOnly = true;
            this.IDModulo.Width = 125;
            // 
            // IDUsuario
            // 
            this.IDUsuario.DataPropertyName = "IDUsuario";
            this.IDUsuario.HeaderText = "ID Usuario";
            this.IDUsuario.MinimumWidth = 6;
            this.IDUsuario.Name = "IDUsuario";
            this.IDUsuario.ReadOnly = true;
            this.IDUsuario.Width = 125;
            // 
            // Alta
            // 
            this.Alta.DataPropertyName = "PermiteAlta";
            this.Alta.HeaderText = "Permite Alta";
            this.Alta.MinimumWidth = 6;
            this.Alta.Name = "Alta";
            this.Alta.ReadOnly = true;
            this.Alta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Alta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Alta.Width = 125;
            // 
            // Baja
            // 
            this.Baja.DataPropertyName = "PermiteBaja";
            this.Baja.HeaderText = "Permite Baja";
            this.Baja.MinimumWidth = 6;
            this.Baja.Name = "Baja";
            this.Baja.ReadOnly = true;
            this.Baja.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Baja.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Baja.Width = 125;
            // 
            // Modificacion
            // 
            this.Modificacion.DataPropertyName = "PermiteModificacion";
            this.Modificacion.HeaderText = "Permite Modificación";
            this.Modificacion.MinimumWidth = 6;
            this.Modificacion.Name = "Modificacion";
            this.Modificacion.ReadOnly = true;
            this.Modificacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Modificacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Modificacion.Width = 125;
            // 
            // Consulta
            // 
            this.Consulta.DataPropertyName = "PermiteConsulta";
            this.Consulta.HeaderText = "Permite Consulta";
            this.Consulta.MinimumWidth = 6;
            this.Consulta.Name = "Consulta";
            this.Consulta.ReadOnly = true;
            this.Consulta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Consulta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Consulta.Width = 125;
            // 
            // ModuloUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 624);
            this.Controls.Add(this.tscModulosUsuarios);
            this.Name = "ModuloUsuarios";
            this.Text = "ModuloUsuarioDesktop";
            this.Load += new System.EventHandler(this.ModuloUsuarioDesktop_Load);
            this.tscModulosUsuarios.ContentPanel.ResumeLayout(false);
            this.tscModulosUsuarios.TopToolStripPanel.ResumeLayout(false);
            this.tscModulosUsuarios.TopToolStripPanel.PerformLayout();
            this.tscModulosUsuarios.ResumeLayout(false);
            this.tscModulosUsuarios.PerformLayout();
            this.tlModulosUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulosUsuarios)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscModulosUsuarios;
        private System.Windows.Forms.TableLayoutPanel tlModulosUsuarios;
        private System.Windows.Forms.DataGridView dgvModulosUsuarios;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDModuloUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDModulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDUsuario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Alta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Baja;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Modificacion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Consulta;
    }
}