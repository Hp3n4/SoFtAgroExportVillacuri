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
    public partial class frmrptRecepcionEsparrago : Form
    {
        public frmrptRecepcionEsparrago()
        {
            InitializeComponent();
        }
        //<!----------- PERMITE MOVILIZAR LA BARRA DE TITULO ----------->
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void ptbIcono_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //<!----------- -------- ------FIN -- ----- -- ------ ----------->

        //<!----------- PERMITIE CERRAR EL FORMULARIO- ------ ----------->
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //<!----------- -------- ------FIN ----------- ------ ----------->               
        private void rdbFecha_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        //<!--PERMITE HABILITAR LOS GRUPBOX POR MEDIO DEL RADIO BUTTON--->
        private void rdbSemana_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbSemana.Checked)
            {
                gbPorsemana.Visible = true;
                gbPorFecha.Visible = false;
                ListarSemana();
            }
            else
            {
                gbPorFecha.Visible = true;
                gbPorsemana.Visible = false;
                cmbSemana.DataSource = null;
                cmbSemana.Items.Clear();
            }
        }
        private void rdbFecha_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdbFecha.Checked)
            {
                gbPorsemana.Visible = false;
                cmbSemana.DataSource = null;
                cmbSemana.Items.Clear();
                gbPorFecha.Visible = true;
            }
            else
            {
                gbPorFecha.Visible = false;
                gbPorsemana.Visible = true;
                ListarSemana();
            }
        }
        //<!----------- -------- ------FIN ----------- ------ ----------->

        //<!PERMITE HABILITAR EL GRUPBOX DE CHOFERES POR MEDIO DEL CHECK->
        private void chChoferes_CheckedChanged(object sender, EventArgs e)
        {
            if (chChoferes.Checked)
            {
                cmbChoferes.Enabled = true;
                ListarChoferes();
            }
            else
            {
                cmbChoferes.Enabled = false;
                cmbChoferes.DataSource = null;  // ORIGEN DE LA INFORMACION VACIA
                cmbChoferes.Items.Clear();      // LIMPIA EL COMBOBOX
            }
        }
        //<!----------- -------- ------FIN ----------- ------ ----------->
        
        //<!-----------PERMITELLENAR EL COMBOBOX E LOS CHOFERES---------->
        private void ListarChoferes()
        {
            clsRecepcionEsparragoConexion objRecepcion = new clsRecepcionEsparragoConexion();            
            cmbChoferes.DataSource = objRecepcion.LlenarComboBoxChoferes();
            cmbChoferes.ValueMember = "idChofer";
            cmbChoferes.DisplayMember = "NomChofer";
        }
        //<!----------- -------- ------FIN ----------- ------ ----------->

        //<!-----------PERMITELLENAR EL COMBOBOX E LOS SEMANAS ---------->
        private void ListarSemana()
        {
            clsRecepcionEsparragoConexion objRecepcion = new clsRecepcionEsparragoConexion();
            cmbSemana.DataSource = objRecepcion.LlenarComboBoxNSemanas();
            //cmbChoferes.ValueMember = "idChofer";
            cmbSemana.DisplayMember = "SemanaAnio";
        }
        //<!----------- -------- ------FIN ----------- ------ ----------->
    }
}
