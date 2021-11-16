
namespace SoFtAgroExportVillacuri
{
    partial class frmrptRecepcionEsparrago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmrptRecepcionEsparrago));
            this.pTitulo = new System.Windows.Forms.Panel();
            this.ptbIcono = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chChoferes = new System.Windows.Forms.CheckBox();
            this.cmbChoferes = new System.Windows.Forms.ComboBox();
            this.lblChoferes = new System.Windows.Forms.Label();
            this.gbPorsemana = new System.Windows.Forms.GroupBox();
            this.cmbSemana = new System.Windows.Forms.ComboBox();
            this.lblSemana = new System.Windows.Forms.Label();
            this.gbPorFecha = new System.Windows.Forms.GroupBox();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.rdbSemana = new System.Windows.Forms.RadioButton();
            this.rdbFecha = new System.Windows.Forms.RadioButton();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.pTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gbPorsemana.SuspendLayout();
            this.gbPorFecha.SuspendLayout();
            this.gbFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // pTitulo
            // 
            this.pTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(106)))), ((int)(((byte)(46)))));
            this.pTitulo.Controls.Add(this.ptbIcono);
            this.pTitulo.Controls.Add(this.lblTitulo);
            this.pTitulo.Controls.Add(this.btnMinimizar);
            this.pTitulo.Controls.Add(this.btnCerrar);
            this.pTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTitulo.Location = new System.Drawing.Point(0, 0);
            this.pTitulo.Name = "pTitulo";
            this.pTitulo.Size = new System.Drawing.Size(473, 38);
            this.pTitulo.TabIndex = 144;
            this.pTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pTitulo_MouseDown);
            // 
            // ptbIcono
            // 
            this.ptbIcono.Image = global::SoFtAgroExportVillacuri.Properties.Resources.favicon;
            this.ptbIcono.Location = new System.Drawing.Point(0, 1);
            this.ptbIcono.Name = "ptbIcono";
            this.ptbIcono.Size = new System.Drawing.Size(40, 35);
            this.ptbIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbIcono.TabIndex = 145;
            this.ptbIcono.TabStop = false;
            this.ptbIcono.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptbIcono_MouseDown);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(45, 7);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(345, 23);
            this.lblTitulo.TabIndex = 9;
            this.lblTitulo.Text = "REPORTE RECEPCION DE ESPARRAGO";
            this.lblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitulo_MouseDown);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = global::SoFtAgroExportVillacuri.Properties.Resources.minimazar;
            this.btnMinimizar.Location = new System.Drawing.Point(401, 7);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(25, 25);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 8;
            this.btnMinimizar.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnCerrar.ErrorImage")));
            this.btnCerrar.Image = global::SoFtAgroExportVillacuri.Properties.Resources.CerrarForm;
            this.btnCerrar.Location = new System.Drawing.Point(436, 7);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(25, 25);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Gray;
            this.btnImprimir.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Image = global::SoFtAgroExportVillacuri.Properties.Resources.imprimir;
            this.btnImprimir.Location = new System.Drawing.Point(194, 305);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(106, 82);
            this.btnImprimir.TabIndex = 155;
            this.btnImprimir.Text = "imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chChoferes);
            this.groupBox2.Controls.Add(this.cmbChoferes);
            this.groupBox2.Controls.Add(this.lblChoferes);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(27, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 85);
            this.groupBox2.TabIndex = 154;
            this.groupBox2.TabStop = false;
            // 
            // chChoferes
            // 
            this.chChoferes.AutoSize = true;
            this.chChoferes.ForeColor = System.Drawing.Color.White;
            this.chChoferes.Location = new System.Drawing.Point(21, 0);
            this.chChoferes.Name = "chChoferes";
            this.chChoferes.Size = new System.Drawing.Size(84, 21);
            this.chChoferes.TabIndex = 150;
            this.chChoferes.Text = "Choferes";
            this.chChoferes.UseVisualStyleBackColor = true;
            this.chChoferes.CheckedChanged += new System.EventHandler(this.chChoferes_CheckedChanged);
            // 
            // cmbChoferes
            // 
            this.cmbChoferes.DisplayMember = "TipoJaba.NomTipoTabla";
            this.cmbChoferes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChoferes.Enabled = false;
            this.cmbChoferes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChoferes.ForeColor = System.Drawing.Color.Black;
            this.cmbChoferes.FormattingEnabled = true;
            this.cmbChoferes.Location = new System.Drawing.Point(184, 36);
            this.cmbChoferes.Name = "cmbChoferes";
            this.cmbChoferes.Size = new System.Drawing.Size(198, 25);
            this.cmbChoferes.TabIndex = 148;
            this.cmbChoferes.ValueMember = "TipoJaba.idTipoJaba";
            // 
            // lblChoferes
            // 
            this.lblChoferes.AutoSize = true;
            this.lblChoferes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoferes.ForeColor = System.Drawing.Color.White;
            this.lblChoferes.Location = new System.Drawing.Point(55, 40);
            this.lblChoferes.Name = "lblChoferes";
            this.lblChoferes.Size = new System.Drawing.Size(65, 17);
            this.lblChoferes.TabIndex = 4;
            this.lblChoferes.Text = "Choferes";
            // 
            // gbPorsemana
            // 
            this.gbPorsemana.Controls.Add(this.cmbSemana);
            this.gbPorsemana.Controls.Add(this.lblSemana);
            this.gbPorsemana.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPorsemana.Location = new System.Drawing.Point(27, 107);
            this.gbPorsemana.Name = "gbPorsemana";
            this.gbPorsemana.Size = new System.Drawing.Size(422, 101);
            this.gbPorsemana.TabIndex = 153;
            this.gbPorsemana.TabStop = false;
            this.gbPorsemana.Visible = false;
            // 
            // cmbSemana
            // 
            this.cmbSemana.DisplayMember = "TipoJaba.NomTipoTabla";
            this.cmbSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemana.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSemana.ForeColor = System.Drawing.Color.Black;
            this.cmbSemana.FormattingEnabled = true;
            this.cmbSemana.Location = new System.Drawing.Point(215, 36);
            this.cmbSemana.Name = "cmbSemana";
            this.cmbSemana.Size = new System.Drawing.Size(116, 25);
            this.cmbSemana.TabIndex = 148;
            this.cmbSemana.ValueMember = "TipoJaba.idTipoJaba";
            // 
            // lblSemana
            // 
            this.lblSemana.AutoSize = true;
            this.lblSemana.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemana.ForeColor = System.Drawing.Color.White;
            this.lblSemana.Location = new System.Drawing.Point(86, 40);
            this.lblSemana.Name = "lblSemana";
            this.lblSemana.Size = new System.Drawing.Size(80, 17);
            this.lblSemana.TabIndex = 4;
            this.lblSemana.Text = "Nº Semana";
            // 
            // gbPorFecha
            // 
            this.gbPorFecha.Controls.Add(this.dtpFechaFin);
            this.gbPorFecha.Controls.Add(this.lblFechaFin);
            this.gbPorFecha.Controls.Add(this.dtpFechaInicio);
            this.gbPorFecha.Controls.Add(this.lblFechaInicio);
            this.gbPorFecha.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPorFecha.Location = new System.Drawing.Point(27, 107);
            this.gbPorFecha.Name = "gbPorFecha";
            this.gbPorFecha.Size = new System.Drawing.Size(422, 105);
            this.gbPorFecha.TabIndex = 151;
            this.gbPorFecha.TabStop = false;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CalendarFont = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(167, 66);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(116, 23);
            this.dtpFechaFin.TabIndex = 6;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.ForeColor = System.Drawing.Color.White;
            this.lblFechaFin.Location = new System.Drawing.Point(38, 69);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(68, 17);
            this.lblFechaFin.TabIndex = 5;
            this.lblFechaFin.Text = "Fecha Fin";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CalendarFont = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(167, 28);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(116, 23);
            this.dtpFechaInicio.TabIndex = 1;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.ForeColor = System.Drawing.Color.White;
            this.lblFechaInicio.Location = new System.Drawing.Point(38, 31);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(85, 17);
            this.lblFechaInicio.TabIndex = 4;
            this.lblFechaInicio.Text = "Fecha Inicio";
            // 
            // rdbSemana
            // 
            this.rdbSemana.AutoSize = true;
            this.rdbSemana.ForeColor = System.Drawing.Color.White;
            this.rdbSemana.Location = new System.Drawing.Point(259, 22);
            this.rdbSemana.Name = "rdbSemana";
            this.rdbSemana.Size = new System.Drawing.Size(104, 21);
            this.rdbSemana.TabIndex = 156;
            this.rdbSemana.Text = "Por Semana";
            this.rdbSemana.UseVisualStyleBackColor = true;
            this.rdbSemana.CheckedChanged += new System.EventHandler(this.rdbSemana_CheckedChanged);
            // 
            // rdbFecha
            // 
            this.rdbFecha.AutoSize = true;
            this.rdbFecha.Checked = true;
            this.rdbFecha.ForeColor = System.Drawing.Color.White;
            this.rdbFecha.Location = new System.Drawing.Point(81, 22);
            this.rdbFecha.Name = "rdbFecha";
            this.rdbFecha.Size = new System.Drawing.Size(90, 21);
            this.rdbFecha.TabIndex = 157;
            this.rdbFecha.TabStop = true;
            this.rdbFecha.Text = "Por Fecha";
            this.rdbFecha.UseVisualStyleBackColor = true;
            this.rdbFecha.CheckedChanged += new System.EventHandler(this.rdbFecha_CheckedChanged_1);
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.rdbFecha);
            this.gbFiltro.Controls.Add(this.rdbSemana);
            this.gbFiltro.Location = new System.Drawing.Point(27, 42);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(422, 55);
            this.gbFiltro.TabIndex = 158;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtro";
            // 
            // frmrptRecepcionEsparrago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(473, 402);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pTitulo);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.gbPorFecha);
            this.Controls.Add(this.gbPorsemana);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmrptRecepcionEsparrago";
            this.Text = "frmrptRecepcionEsparrago";
            this.pTitulo.ResumeLayout(false);
            this.pTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbPorsemana.ResumeLayout(false);
            this.gbPorsemana.PerformLayout();
            this.gbPorFecha.ResumeLayout(false);
            this.gbPorFecha.PerformLayout();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pTitulo;
        private System.Windows.Forms.PictureBox ptbIcono;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chChoferes;
        private System.Windows.Forms.ComboBox cmbChoferes;
        private System.Windows.Forms.Label lblChoferes;
        private System.Windows.Forms.GroupBox gbPorsemana;
        private System.Windows.Forms.ComboBox cmbSemana;
        private System.Windows.Forms.Label lblSemana;
        private System.Windows.Forms.GroupBox gbPorFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.RadioButton rdbSemana;
        private System.Windows.Forms.RadioButton rdbFecha;
        private System.Windows.Forms.GroupBox gbFiltro;
    }
}