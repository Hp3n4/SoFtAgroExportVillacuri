using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Drawing.Printing;


namespace SoFtAgroExportVillacuri
{
    public partial class frmRecepcionEsparragoAgregar : Form
    {
        public frmRecepcionEsparragoAgregar()
        {
            InitializeComponent();
        }
        private void frmRecepcionEsparragoAgregar_Load(object sender, EventArgs e)
        {
            ListarChoferes();
            LlenarTxtPlaca();
            ListarTipoJabas();
            ListarTipoParihuela();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //--------------------------BOTON CERRAR--------------------///////////
        private void pTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //------------------------------Termino-------------------------------------//////////////////
        //--------------------------BOTON CERRAR--------------------///////////
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //------------------------------Termino-------------------------------------//////////////////
        //--------------------------BOTON MINIMIZAR--------------------///////////
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //------------------------------Termino-------------------------------------//////////////////
        //--------------------------Fechar--------------------///////////
        private void dtpFechaRecepcion_Enter(object sender, EventArgs e)
        {
            lblFecha.BackColor = Color.FromArgb(38, 106, 46);
        }
        private void dtpFechaRecepcion_Leave(object sender, EventArgs e)
        {
            lblFecha.BackColor = Color.Gray;
        }
        //------------------------------Termino-------------------------------------//////////////////
        //--------------------------LLenar Todo lo Correspondiente al Combobox Xhofer--------------------///////////
        private void ListarChoferes()
        {
            clsRecepcionEsparragoConexion objRecepcion = new clsRecepcionEsparragoConexion();
            cmbChofer.DataSource = objRecepcion.LlenarComboBoxChoferes();
            cmbChofer.ValueMember = "idChofer";
            cmbChofer.DisplayMember = "NomChofer";
        }
        private void cmbChofer_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIdChofer.Text = cmbChofer.SelectedValue.ToString();
        }
        private void cmbChofer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPlaca.Focus();
            }
        }
        private void cmbChofer_Enter(object sender, EventArgs e)
        {
            lblChofer.BackColor = Color.FromArgb(38, 106, 46);
        }

        private void cmbChofer_Leave(object sender, EventArgs e)
        {
            lblChofer.BackColor = Color.Gray;
        }

        //------------------------------Termino-------------------------------------//////////////////
        //--------------------------Texbox Placa con modo Autocompletable--------------------///////////
        private void LlenarTxtPlaca()
        {
            clsRecepcionEsparragoConexion objRecepcionConexion = new clsRecepcionEsparragoConexion();
            objRecepcionConexion.autocompletar(txtPlaca);
        }
        private void txtPlaca_Enter(object sender, EventArgs e)
        {
            lblPlaca.BackColor = Color.FromArgb(38, 106, 46);
        }
        private void txtPlaca_Leave(object sender, EventArgs e)
        {
            lblPlaca.BackColor = Color.Gray;
        }
        //---------------------------------Fin------------------------------------------///////////
        //--------------------------Texbox Jabas--------------------///////////
        private void txtJabas_Enter(object sender, EventArgs e)
        {
            lblJabas.BackColor = Color.FromArgb(38, 106, 46);
        }
        private void txtJabas_Leave(object sender, EventArgs e)
        {
            lblJabas.BackColor = Color.Gray;
        }
        private void txtJabas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtJabas.Text.Length; i++)
            {
                if (txtJabas.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
        private void txtJabas_TextChanged(object sender, EventArgs e)
        {
            Calculo();
        }
        //---------------------------------Fin------------------------------------------///////////
        //----------------------Combobox TipoJabas----------------------//////////////
        private void ListarTipoJabas()
        {
            clsRecepcionEsparragoConexion objRecepcion = new clsRecepcionEsparragoConexion();
            cmbTipoJaba.DataSource = objRecepcion.LlenarComboBoxTipoJaba();
            cmbTipoJaba.ValueMember = "idTipoJaba";
            cmbTipoJaba.DisplayMember = "NomTipoJaba";
        }
        private void cmbTipoJaba_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection Conexion = new SqlConnection();
            Conexion.ConnectionString = clsConexionBd.CadenaConexion;
            SqlCommand cmd = new SqlCommand("select idTipoJaba,NomTipoJaba,PesoJaba from TipoJaba where NomTipoJaba ='" + cmbTipoJaba.Text + "'", Conexion);
            Conexion.Open();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                txtTipoJabaPeso.Text = (string)dr["PesoJaba"].ToString();
            }
            lblIdTipoJaba.Text = cmbTipoJaba.SelectedValue.ToString();
            //Calculo();
        }
        private void cmbTipoJaba_Enter(object sender, EventArgs e)
        {
           lblTipoJaba.BackColor = Color.FromArgb(38, 106, 46);
        }
        private void cmbTipoJaba_Leave(object sender, EventArgs e)
        {
            lblTipoJaba.BackColor = Color.Gray;
        }
        private void txtTipoJabaPeso_TextChanged(object sender, EventArgs e)
        {
            Calculo();
        }
        //-----------------------FIN-------------------------------------/////
        //----------------------Combobox TipoParihuela----------------------//////////////
        private void ListarTipoParihuela()
        {
            clsRecepcionEsparragoConexion objRecepcion = new clsRecepcionEsparragoConexion();
            cmbTipoParihuela.DataSource = objRecepcion.LlenarComboBoxTipoJParihuela();
            cmbTipoParihuela.ValueMember = "idTipoParihuela";
            cmbTipoParihuela.DisplayMember = "NomTipoParihuela";
        }
        private void cmbTipoParihuela_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection Conexion = new SqlConnection();
            Conexion.ConnectionString = clsConexionBd.CadenaConexion;
            SqlCommand cmd = new SqlCommand("select idTipoParihuela,NomTipoParihuela,PesoParihuela from TipoParihuela where NomTipoParihuela ='" + cmbTipoParihuela.Text + "'", Conexion);
            Conexion.Open();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                txtTipoParihuelaPeso.Text = (string)dr["PesoParihuela"].ToString();
            }
            lblIdTipoParihuela.Text = cmbTipoParihuela.SelectedValue.ToString();
        }
        private void cmbTipoParihuela_Enter(object sender, EventArgs e)
        {
            lblParihuela.BackColor = Color.FromArgb(38, 106, 46);
        }

        private void cmbTipoParihuela_Leave(object sender, EventArgs e)
        {
            lblParihuela.BackColor = Color.Gray;
        }
        private void txtTipoParihuelaPeso_TextChanged(object sender, EventArgs e)
        {
            Calculo();
        }
        //-----------------------FIN-------------------------------------/////
        //----------------------txt Peso Campo TipoParihuela----------------------//////////////
        private void txtPesoCampo_Enter(object sender, EventArgs e)
        {
            lblPesoCampo.BackColor = Color.FromArgb(38, 106, 46);
        }

        private void txtPesoCampo_Leave(object sender, EventArgs e)
        {
            lblPesoCampo.BackColor = Color.Gray;
        }

        private void txtPesoCampo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtPesoCampo.Text.Length; i++)
            {
                if (txtPesoCampo.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 3)
                {
                    e.Handled = true;
                    return;
                }
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
        private void txtPesoCampo_TextChanged(object sender, EventArgs e)
        {
            Calculo();
        }
        //-----------------------FIN-------------------------------------/////
        //----------------------calcular----------------------//////////////

        private void Calculo()
        {
            decimal Jabas = 0;
            decimal Tara = 0;
            decimal PesoCampo = 0;
            decimal PesoBruto = 0;
            decimal PesoNeto = 0;
            decimal PesoPromedio = 0;
            decimal Parihuela = 0;
            //if (txtJabas.Text == "" || txtJabas.Text == "0")
            //{
            //    MessageBox.Show("El valor campo Jabas no puede estar vacio", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            try
            {
                Jabas = decimal.Parse(txtJabas.Text);
                Tara = Jabas * decimal.Parse(txtTipoJabaPeso.Text);
                Parihuela = decimal.Parse(txtTipoParihuelaPeso.Text);

                PesoCampo = decimal.Parse(txtPesoCampo.Text);
                PesoBruto = PesoCampo + (Tara + Parihuela);
                PesoNeto = PesoCampo - (Tara + Parihuela);
                PesoPromedio = PesoNeto / Jabas;

                txtTara.Text = Tara.ToString("###,###.00");

                txtPesoBruto.Text = PesoBruto.ToString("###,###.00");
                txtPesoNeto.Text = PesoNeto.ToString("###,###.00");
                txtPesoPromedio.Text = PesoPromedio.ToString("###,###.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //-----------------------FIN-------------------------------------/////
        //----------------------Boton Guardar----------------------//////////////
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtPesoCampo.Text.Equals("") || txtPesoCampo.Text.Equals("0.00") || txtPlaca.Text.Equals("") || float.Parse(txtPesoBruto.Text) < 0 || float.Parse(txtPesoNeto.Text) < 0)
            {
                MessageBox.Show("Coloque bien los valores en los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //try
                //{
                frmMenuPrincipal formMenuPrincipal = new frmMenuPrincipal();
                clsRecepcionEsparrago objRecepcionEsparrago = new clsRecepcionEsparrago();
                clsPublic objPublic = new clsPublic();
                objRecepcionEsparrago.Fecha = dtpFechaRecepcion.Value.Date;
                objRecepcionEsparrago.IdChofer = int.Parse(lblIdChofer.Text);
                objRecepcionEsparrago.PlacaVehiculo = txtPlaca.Text.ToString().Trim();
                objRecepcionEsparrago.IdTipoJaba = int.Parse(lblIdTipoJaba.Text);
                objRecepcionEsparrago.IdTipoParihuela = int.Parse(lblIdTipoParihuela.Text);
                objRecepcionEsparrago.TotalPesoCampo = float.Parse(txtPesoCampo.Text);
                objRecepcionEsparrago.TotalJabas = float.Parse(txtJabas.Text);
                objRecepcionEsparrago.TotalTara = float.Parse(txtTara.Text);
                objRecepcionEsparrago.TotalPesoBruto = float.Parse(txtPesoBruto.Text);
                objRecepcionEsparrago.TotalNeto = float.Parse(txtPesoNeto.Text);
                objRecepcionEsparrago.PesoPromedio = float.Parse(txtPesoPromedio.Text);
                objRecepcionEsparrago.Maquina = Environment.MachineName.Trim();
                objRecepcionEsparrago.Usuario = formMenuPrincipal.lblUsuario.Text;

                clsRecepcionEsparragoConexion objRecepcionEsparragoConexion = new clsRecepcionEsparragoConexion();
                int resultado = objRecepcionEsparragoConexion.RecepcionEsparragoInsertBystoredProcedure(objRecepcionEsparrago);
                if (resultado == 1)
                {
                    MessageBox.Show("Insertado Correctamente");
                    printDocument1 = new PrintDocument();
                    PrinterSettings ps = new PrinterSettings();
                    printDocument1.PrinterSettings = ps;
                    printDocument1.PrintPage += Imprimir;
                    printDocument1.Print();
                    ////////////////Prueba//////////////
                    frmRpt objfrmRpt = new frmRpt();
                    DateTime FecharptRE = dtpFechaRecepcion.Value.Date;
                    objfrmRpt.FecharptRE = FecharptRE;
                    objfrmRpt.ShowDialog();




                }
                    
                else
                    MessageBox.Show("Ocurrió un erro, intente nuevamente");

                //  limpiar();
               // }
                //  catch (Exception ex)
               // {
                //    MessageBox.Show(ex.Message);
               // }                
            }
            if (txtPlaca.Text.Equals(""))
            {
                MessageBox.Show("El campo Placa no puede estar vacio", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (float.Parse(txtJabas.Text) < 0 || txtJabas.Text.Equals(""))
            {
                MessageBox.Show("El campo Jabas no puede ser menor a cero", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (float.Parse(txtPesoCampo.Text) < 0 || txtPesoCampo.Text.Equals(""))
            {
                MessageBox.Show("El Peso Campo no puede ser menor a cero", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (float.Parse(txtPesoBruto.Text) < 0 )
            {
                MessageBox.Show("El Peso Bruto no puede ser menor a cero", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (float.Parse(txtPesoNeto.Text) < 0)
            {
                MessageBox.Show("El Peso Neto no puede ser menor a cero", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            limpiar();
            this.Close();
            //-----------------------FIN-------------------------------------/////
        }
        //----------------------Imprime directamente el contenido----------------------//////////////

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Verdana", 10);
            int ancho = 300;
            int y = 10;

            e.Graphics.DrawString("--- Recepcion de Esparrago ---", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Fecha: " + dtpFechaRecepcion.Value.ToString(), font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Cant Jabas: " + txtJabas.Text + "  |  Peso Jaba: " + txtTipoJabaPeso.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Peso Camp: " + txtPesoCampo.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Tara: " + txtTara.Text + "  | Tipo Parihuela: " + txtTipoParihuelaPeso.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Peso Bruto: " + txtPesoBruto.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Peso Neto: " + txtPesoNeto.Text, font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
        }
        //------------------------FIN-------------------------------////////////


        //----------------------boton cancelar----------------------//////////////
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            this.Close();
        }
        //-----------------------FIN-------------------------------------/////
        //----------------------metodo limpiar----------------------//////////////
        void limpiar()
        {
            lblID.Text = "";
            lblIdChofer.Text = "";
            txtPlaca.Text = "";
            txtJabas.Text = "1";
            txtPesoCampo.Text = "0.00";
            txtTara.Text = "";
            txtPesoBruto.Text = "";
            txtPesoNeto.Text = "";
            txtPesoPromedio.Text = "";
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        //-----------------------FIN-------------------------------------/////
    }
}
