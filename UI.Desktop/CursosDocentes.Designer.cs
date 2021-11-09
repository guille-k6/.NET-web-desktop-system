
namespace UI.Desktop
{
    partial class CursosDocentes
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
            this.tscCursosDocentes = new System.Windows.Forms.ToolStripContainer();
            this.tsCursosDocentes = new System.Windows.Forms.ToolStrip();
            this.tlCursosDocentes = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCursosDocentes = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.IdDictado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdDocente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tscCursosDocentes.ContentPanel.SuspendLayout();
            this.tscCursosDocentes.TopToolStripPanel.SuspendLayout();
            this.tscCursosDocentes.SuspendLayout();
            this.tsCursosDocentes.SuspendLayout();
            this.tlCursosDocentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursosDocentes)).BeginInit();
            this.SuspendLayout();
            // 
            // tscCursosDocentes
            // 
            // 
            // tscCursosDocentes.ContentPanel
            // 
            this.tscCursosDocentes.ContentPanel.Controls.Add(this.tlCursosDocentes);
            this.tscCursosDocentes.ContentPanel.Size = new System.Drawing.Size(800, 423);
            this.tscCursosDocentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscCursosDocentes.Location = new System.Drawing.Point(0, 0);
            this.tscCursosDocentes.Name = "tscCursosDocentes";
            this.tscCursosDocentes.Size = new System.Drawing.Size(800, 450);
            this.tscCursosDocentes.TabIndex = 0;
            this.tscCursosDocentes.Text = "toolStripContainer1";
            // 
            // tscCursosDocentes.TopToolStripPanel
            // 
            this.tscCursosDocentes.TopToolStripPanel.Controls.Add(this.tsCursosDocentes);
            // 
            // tsCursosDocentes
            // 
            this.tsCursosDocentes.Dock = System.Windows.Forms.DockStyle.None;
            this.tsCursosDocentes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsCursosDocentes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsCursosDocentes.Location = new System.Drawing.Point(4, 0);
            this.tsCursosDocentes.Name = "tsCursosDocentes";
            this.tsCursosDocentes.Size = new System.Drawing.Size(100, 27);
            this.tsCursosDocentes.TabIndex = 0;
            // 
            // tlCursosDocentes
            // 
            this.tlCursosDocentes.ColumnCount = 2;
            this.tlCursosDocentes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlCursosDocentes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlCursosDocentes.Controls.Add(this.dgvCursosDocentes, 0, 0);
            this.tlCursosDocentes.Controls.Add(this.btnActualizar, 0, 1);
            this.tlCursosDocentes.Controls.Add(this.btnSalir, 1, 1);
            this.tlCursosDocentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlCursosDocentes.Location = new System.Drawing.Point(0, 0);
            this.tlCursosDocentes.Name = "tlCursosDocentes";
            this.tlCursosDocentes.RowCount = 2;
            this.tlCursosDocentes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlCursosDocentes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlCursosDocentes.Size = new System.Drawing.Size(800, 423);
            this.tlCursosDocentes.TabIndex = 0;
            // 
            // dgvCursosDocentes
            // 
            this.dgvCursosDocentes.AllowUserToAddRows = false;
            this.dgvCursosDocentes.AllowUserToDeleteRows = false;
            this.dgvCursosDocentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursosDocentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDictado,
            this.IdCurso,
            this.IdDocente,
            this.Cargo});
            this.tlCursosDocentes.SetColumnSpan(this.dgvCursosDocentes, 2);
            this.dgvCursosDocentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCursosDocentes.Location = new System.Drawing.Point(3, 3);
            this.dgvCursosDocentes.MultiSelect = false;
            this.dgvCursosDocentes.Name = "dgvCursosDocentes";
            this.dgvCursosDocentes.ReadOnly = true;
            this.dgvCursosDocentes.RowHeadersWidth = 51;
            this.dgvCursosDocentes.RowTemplate.Height = 24;
            this.dgvCursosDocentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCursosDocentes.Size = new System.Drawing.Size(794, 388);
            this.dgvCursosDocentes.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(631, 397);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(85, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(722, 397);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
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
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
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
            // IdDictado
            // 
            this.IdDictado.DataPropertyName = "ID";
            this.IdDictado.HeaderText = "ID Dictado";
            this.IdDictado.MinimumWidth = 6;
            this.IdDictado.Name = "IdDictado";
            this.IdDictado.ReadOnly = true;
            this.IdDictado.Width = 125;
            // 
            // IdCurso
            // 
            this.IdCurso.DataPropertyName = "IDCurso";
            this.IdCurso.HeaderText = "ID Curso";
            this.IdCurso.MinimumWidth = 6;
            this.IdCurso.Name = "IdCurso";
            this.IdCurso.ReadOnly = true;
            this.IdCurso.Width = 125;
            // 
            // IdDocente
            // 
            this.IdDocente.DataPropertyName = "IDDocente";
            this.IdDocente.HeaderText = "ID Docente";
            this.IdDocente.MinimumWidth = 6;
            this.IdDocente.Name = "IdDocente";
            this.IdDocente.ReadOnly = true;
            this.IdDocente.Width = 125;
            // 
            // Cargo
            // 
            this.Cargo.DataPropertyName = "Cargo";
            this.Cargo.HeaderText = "Cargo";
            this.Cargo.MinimumWidth = 6;
            this.Cargo.Name = "Cargo";
            this.Cargo.ReadOnly = true;
            this.Cargo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cargo.Width = 125;
            // 
            // CursosDocentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tscCursosDocentes);
            this.Name = "CursosDocentes";
            this.Text = "CursosDocentes";
            this.Load += new System.EventHandler(this.CursosDocentes_Load);
            this.tscCursosDocentes.ContentPanel.ResumeLayout(false);
            this.tscCursosDocentes.TopToolStripPanel.ResumeLayout(false);
            this.tscCursosDocentes.TopToolStripPanel.PerformLayout();
            this.tscCursosDocentes.ResumeLayout(false);
            this.tscCursosDocentes.PerformLayout();
            this.tsCursosDocentes.ResumeLayout(false);
            this.tsCursosDocentes.PerformLayout();
            this.tlCursosDocentes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursosDocentes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscCursosDocentes;
        private System.Windows.Forms.TableLayoutPanel tlCursosDocentes;
        private System.Windows.Forms.DataGridView dgvCursosDocentes;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip tsCursosDocentes;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDictado;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDocente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cargo;
    }
}