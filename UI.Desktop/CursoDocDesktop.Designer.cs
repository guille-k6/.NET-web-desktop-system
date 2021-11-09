
namespace UI.Desktop
{
    partial class CursoDocDesktop
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
            this.tlCursosDocentes = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDDictado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cbCargo = new System.Windows.Forms.ComboBox();
            this.cbIDDocente = new System.Windows.Forms.ComboBox();
            this.cbIDCurso = new System.Windows.Forms.ComboBox();
            this.tlCursosDocentes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlCursosDocentes
            // 
            this.tlCursosDocentes.ColumnCount = 4;
            this.tlCursosDocentes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlCursosDocentes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlCursosDocentes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlCursosDocentes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlCursosDocentes.Controls.Add(this.label1, 0, 0);
            this.tlCursosDocentes.Controls.Add(this.txtIDDictado, 1, 0);
            this.tlCursosDocentes.Controls.Add(this.label2, 2, 0);
            this.tlCursosDocentes.Controls.Add(this.label3, 0, 1);
            this.tlCursosDocentes.Controls.Add(this.label4, 2, 1);
            this.tlCursosDocentes.Controls.Add(this.btnCancelar, 3, 2);
            this.tlCursosDocentes.Controls.Add(this.btnAceptar, 2, 2);
            this.tlCursosDocentes.Controls.Add(this.cbCargo, 3, 1);
            this.tlCursosDocentes.Controls.Add(this.cbIDDocente, 1, 1);
            this.tlCursosDocentes.Controls.Add(this.cbIDCurso, 3, 0);
            this.tlCursosDocentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlCursosDocentes.Location = new System.Drawing.Point(0, 0);
            this.tlCursosDocentes.Name = "tlCursosDocentes";
            this.tlCursosDocentes.RowCount = 3;
            this.tlCursosDocentes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.76923F));
            this.tlCursosDocentes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.76923F));
            this.tlCursosDocentes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.46154F));
            this.tlCursosDocentes.Size = new System.Drawing.Size(883, 121);
            this.tlCursosDocentes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Dictado";
            // 
            // txtIDDictado
            // 
            this.txtIDDictado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIDDictado.Enabled = false;
            this.txtIDDictado.Location = new System.Drawing.Point(179, 3);
            this.txtIDDictado.Name = "txtIDDictado";
            this.txtIDDictado.Size = new System.Drawing.Size(258, 22);
            this.txtIDDictado.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(443, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID Curso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "ID Docente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(443, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cargo";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(619, 77);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 34);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(527, 77);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(86, 34);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cbCargo
            // 
            this.cbCargo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCargo.FormattingEnabled = true;
            this.cbCargo.Items.AddRange(new object[] {
            "Titular",
            "Auxiliar"});
            this.cbCargo.Location = new System.Drawing.Point(619, 40);
            this.cbCargo.Name = "cbCargo";
            this.cbCargo.Size = new System.Drawing.Size(261, 24);
            this.cbCargo.TabIndex = 10;
            // 
            // cbIDDocente
            // 
            this.cbIDDocente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIDDocente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIDDocente.FormattingEnabled = true;
            this.cbIDDocente.Location = new System.Drawing.Point(179, 40);
            this.cbIDDocente.Name = "cbIDDocente";
            this.cbIDDocente.Size = new System.Drawing.Size(258, 24);
            this.cbIDDocente.TabIndex = 11;
            // 
            // cbIDCurso
            // 
            this.cbIDCurso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIDCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIDCurso.FormattingEnabled = true;
            this.cbIDCurso.Location = new System.Drawing.Point(619, 3);
            this.cbIDCurso.Name = "cbIDCurso";
            this.cbIDCurso.Size = new System.Drawing.Size(261, 24);
            this.cbIDCurso.TabIndex = 12;
            // 
            // CursoDocDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 121);
            this.Controls.Add(this.tlCursosDocentes);
            this.Name = "CursoDocDesktop";
            this.Text = "CursoDocDesktop";
            this.Load += new System.EventHandler(this.CursoDocDesktop_Load);
            this.tlCursosDocentes.ResumeLayout(false);
            this.tlCursosDocentes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlCursosDocentes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDDictado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cbCargo;
        private System.Windows.Forms.ComboBox cbIDDocente;
        private System.Windows.Forms.ComboBox cbIDCurso;
    }
}