using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SoFtAgroExportVillacuri
{
    public partial class frmRecepcionEsparragoConfigSemanas : Form
    {
        private string dia = DateTime.Now.ToString("dd");
        private string mes = DateTime.Now.ToString("MM");
        public frmRecepcionEsparragoConfigSemanas()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtSemana.Text.Equals(""))
            {
                MessageBox.Show("Selecciones el inicio de la Semana", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                clsRecepcionEsparragoConfigSemana objRecepcionEsparragoConfigSemana = new clsRecepcionEsparragoConfigSemana();
                objRecepcionEsparragoConfigSemana.Anio = int.Parse(txtAnio.Text);
                objRecepcionEsparragoConfigSemana.Mes = int.Parse(mes);
                objRecepcionEsparragoConfigSemana.Dia = int.Parse(dia);
                objRecepcionEsparragoConfigSemana.Desde = dtpFechaDesde.Value.Date;
                objRecepcionEsparragoConfigSemana.Hasta = dtpFechaHasta.Value.Date;
                objRecepcionEsparragoConfigSemana.Semana = int.Parse(txtSemana.Text);
                objRecepcionEsparragoConfigSemana.PC = Environment.MachineName.Trim();

                clsConfigSemanaConexion objConfigSemanaConexion = new clsConfigSemanaConexion();
                int resultado = objConfigSemanaConexion.ConfigSemanaInsertBystoredProcedure(objRecepcionEsparragoConfigSemana);
                if (resultado == 1)
                    MessageBox.Show("Insertado Correctamente");
                else
                    MessageBox.Show("Ocurrió un erro, intente nuevamente");
            }
        }

        private void dtpFechaDesde_Leave(object sender, EventArgs e)
        {
            txtAnio.Text = dtpFechaDesde.Value.ToString("yyyy");
            System.Globalization.CultureInfo norwCulture =
            System.Globalization.CultureInfo.CreateSpecificCulture("es");
            System.Globalization.Calendar cal = norwCulture.Calendar;
            int weekNo = cal.GetWeekOfYear(dtpFechaDesde.Value, norwCulture.DateTimeFormat.CalendarWeekRule, norwCulture.DateTimeFormat.FirstDayOfWeek);            
            txtSemana.Text = weekNo.ToString();
        }

        private void dtpFechaDesde_TabIndexChanged(object sender, EventArgs e)
        {
            //txtAnio.Text = dtpFechaDesde.Value.ToString("yyyy");
        }

        private void pTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void lblConfiguracion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public void cargar()
        {
            clsRecepcionEsparragoConexion objRecepcionEsparragoConexion = new clsRecepcionEsparragoConexion();
            dataGridView1.DataSource = objRecepcionEsparragoConexion.MostrarConfigSemana();
            dataGridView1.Columns["idsemana"].Visible = false;
            dataGridView1.Columns["Mes"].Visible = false;
            dataGridView1.Columns["Dia"].Visible = false;                    
            dataGridView1.Columns["Estado"].Visible = false;
            dataGridView1.Columns["PC"].Visible = false;            
        }

        private void frmRecepcionEsparragoConfigSemanas_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            txtAnio.Text = "";
            txtSemana.Text = "";
        }
    }
}
