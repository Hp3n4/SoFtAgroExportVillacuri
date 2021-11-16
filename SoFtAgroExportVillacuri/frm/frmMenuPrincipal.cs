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
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de cerrar la Aplicacion?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
            //Application.Exit();
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");            
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void pBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            pSubMenuReportes.Visible = true;
        }

        private void btnReporte1_Click(object sender, EventArgs e)
        {
            pSubMenuReportes.Visible = false;
        }

        private void btnReporte2_Click(object sender, EventArgs e)
        {
            pSubMenuReportes.Visible = false;
        }

        private void btnReporte3_Click(object sender, EventArgs e)
        {
            pSubMenuReportes.Visible = false;
        }
        private void AbrirFormEnPanel(object formHijo)
        {
            if (this.pContenedor.Controls.Count > 0)
                this.pContenedor.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.pContenedor.Controls.Add(fh);
            this.pContenedor.Tag = fh;
            fh.Show();
        }
        private void btnRecepcion_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmRecepcionEsparrago());
        }
    }
}
