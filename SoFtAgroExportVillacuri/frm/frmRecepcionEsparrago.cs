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
using Microsoft.VisualBasic;

namespace SoFtAgroExportVillacuri
{
    public partial class frmRecepcionEsparrago : Form
    {
        private string dia = DateTime.Now.ToString("dd");
        private string mes = DateTime.Now.ToString("MM");
        private string ano = DateTime.Now.ToString("yyyy");
        private string mas = "123";
        private string clave;
        public frmRecepcionEsparrago()
        {
            InitializeComponent();
        }
        private void frmRecepcionEsparrago_Load(object sender, EventArgs e)
        {
            cargar();
            Suma();           
        }
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
            if(e.KeyCode == Keys.Enter)
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
        //--------------------------Texbox Placa con modo Autocompletable--------------------/////////
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
        private void txtPesoCampo_TextChanged(object sender, EventArgs e)
        {
            Calculo();
        }
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
                PesoBruto = PesoCampo + (Tara + Parihuela); //PesoCampo * Parihuela;
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


        private void Suma()
        {
            decimal totalPesoCampo = dataGridView1.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["PCampo"].Value));
            decimal totalJabas = dataGridView1.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["Jaba"].Value));
            decimal totalTara = dataGridView1.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["Tara"].Value));
            decimal totalPesoBruto = dataGridView1.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["PBruto"].Value));
            decimal totalPesoNeto = dataGridView1.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["PNeto"].Value));
            decimal totalPesoProm = dataGridView1.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["PesoProm"].Value));

            txtTotalesPesoCampo.Text = totalPesoCampo.ToString();
            txtTotalesJabas.Text = totalJabas.ToString();
            txtTotalesTara.Text = totalTara.ToString();
            txtTotalesPesoBruto.Text = totalPesoBruto.ToString();
            txtTotalesPesoNeto.Text = totalPesoNeto.ToString();
            txtTotalesPesoProm.Text = totalPesoProm.ToString();
        }  
         
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmRecepcionEsparragoAgregar frmRecepcionEsparragoAgrega = new frmRecepcionEsparragoAgregar();
            frmRecepcionEsparragoAgrega.ShowDialog();
            cargar();
            Suma();
        }
        //void activar()
        //{
        //    btnNuevo.Enabled = false;
        //    btnBuscar.Enabled = false;
        //    btnGuardar.Enabled = true;
        //    btnCancelar.Enabled = true;
        //    dtpFechaRecepcion.Enabled = true;
        //    cmbChofer.Enabled = true;
        //    txtPlaca.Enabled = true;
        //    txtJabas.Enabled = true;
        //    cmbTipoJaba.Enabled = true;
        //    cmbTipoParihuela.Enabled = true;
        //    txtPesoCampo.Enabled = true;
        //    btnQuitar.Enabled = true;
        //    btnModificar.Enabled = true;
        //}
        //void desactivar()
        //{
        //    btnNuevo.Enabled = true;
        //    btnBuscar.Enabled = true;
        //    btnGuardar.Enabled = false;
        //    btnCancelar.Enabled = false;
        //    dtpFechaRecepcion.Enabled = false;
        //    cmbChofer.Enabled = false;
        //    txtPlaca.Enabled = false;
        //    txtJabas.Enabled = false;
        //    cmbTipoJaba.Enabled = false;
        //    cmbTipoParihuela.Enabled = false;
        //    txtPesoCampo.Enabled = false;
        //    btnQuitar.Enabled = false;
        //    btnModificar.Enabled = false;
        //}
            
        public void cargar()
        {
            clsRecepcionEsparragoConexion objRecepcionEsparragoConexion = new clsRecepcionEsparragoConexion();
            dataGridView1.DataSource = objRecepcionEsparragoConexion.Mostrar();
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Hora"].Visible = false;
            dataGridView1.Columns["IdChofer"].Visible = false;
            dataGridView1.Columns["IdChofer"].Visible = false;
            dataGridView1.Columns["IdTipoJaba"].Visible = false;            
            dataGridView1.Columns["IdTipoParihuela"].Visible = false;
            dataGridView1.Columns["Registro"].Visible = false;
            dataGridView1.Columns["Maquina"].Visible = false;
            dataGridView1.Columns["Usuario"].Visible = false;
            dataGridView1.Columns["Estado"].Visible = false;            
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            ////////////ListarChoferes();
            ////////////LlenarTxtPlaca();
            ////////////ListarTipoJabas();
            ////////////ListarTipoParihuela();
            ////////////activar();
            ///
            /// 
            /// 
            ////////////clsRecepcionEsparrago objRecepcionEsparrago = new clsRecepcionEsparrago();
            ////////////objRecepcionEsparrago.IdRecepcionPLanta = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            ////////////objRecepcionEsparrago.IdChofer = int.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            ////////////objRecepcionEsparrago.Chofer = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            ////////////lblIdChofer.Text = objRecepcionEsparrago.IdRecepcionPLanta.ToString();
            ////////////lblIdChofer.Text = objRecepcionEsparrago.IdChofer.ToString();
            ////////////cmbChofer.Text = objRecepcionEsparrago.Chofer;


        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {           
            frmInputbox frmInputboxx = new frmInputbox();
            frmInputboxx.ShowDialog();

            clave = frmInputboxx.txtCredencial.Text;

            // clave = Interaction.InputBox("Ingrese Credencial","Contraseña");

            if (clave.Equals(dia + mes + ano + mas))
            {
                try
                {
                    int id = int.Parse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString());
                    clsRecepcionEsparragoConexion objRecepcionEsparragoConexion = new clsRecepcionEsparragoConexion();
                    int resultado = objRecepcionEsparragoConexion.RecepcionEsparragoEliminar(id);
                    if (resultado == 1)
                        MessageBox.Show("Registro eliminado correctamente");
                    else
                        MessageBox.Show("Ocurrió un error");
                    cargar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                MessageBox.Show("No se Elimino el Registro");
            }
            frmInputboxx.txtCredencial.Clear();
            Suma();
            cargar();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            ListarTipoJabas();
            ListarChoferes();
            LlenarTxtPlaca();
            LlenarTxtPlaca();
            ListarTipoParihuela();
            frmInputbox frmInputboxx = new frmInputbox();
            frmInputboxx.ShowDialog();

            clave = frmInputboxx.txtCredencial.Text;

            // clave = Interaction.InputBox("Ingrese Credencial","Contraseña");
            if (dataGridView1.SelectedRows.Count > 0)
            { 
                if (clave.Equals(dia + mes + ano + mas))
                {
                    try
                    {
                        clsRecepcionEsparrago objRecepcionEsparrago = new clsRecepcionEsparrago();
                        objRecepcionEsparrago.IdRecepcionPLanta = int.Parse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString());
                        objRecepcionEsparrago.Fecha = DateTime.Parse(dataGridView1.SelectedRows[0].Cells["Fecha"].Value.ToString());
                        objRecepcionEsparrago.IdChofer = int.Parse(dataGridView1.SelectedRows[0].Cells["IdChofer"].Value.ToString());
                        objRecepcionEsparrago.Chofer = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                        objRecepcionEsparrago.PlacaVehiculo = dataGridView1.SelectedRows[0].Cells["PVehiculo"].Value.ToString();
                        //
                        objRecepcionEsparrago.TotalJabas = float.Parse(dataGridView1.SelectedRows[0].Cells["Jaba"].Value.ToString());
                        objRecepcionEsparrago.IdTipoJaba = int.Parse(dataGridView1.SelectedRows[0].Cells["IdTipoJaba"].Value.ToString());
                        objRecepcionEsparrago.DescripcionJaba = dataGridView1.SelectedRows[0].Cells["TJaba"].Value.ToString();
                        objRecepcionEsparrago.PesoJaba = float.Parse(dataGridView1.SelectedRows[0].Cells["PJaba"].Value.ToString());
                        objRecepcionEsparrago.IdTipoParihuela = int.Parse(dataGridView1.SelectedRows[0].Cells["IdTipoParihuela"].Value.ToString());
                        objRecepcionEsparrago.DescripcionParihuela = dataGridView1.SelectedRows[0].Cells["TParihuela"].Value.ToString();
                        objRecepcionEsparrago.PesoParihuela = float.Parse(dataGridView1.SelectedRows[0].Cells["PParihuela"].Value.ToString());
                        //
                        objRecepcionEsparrago.TotalPesoCampo = float.Parse(dataGridView1.SelectedRows[0].Cells["PCampo"].Value.ToString());
                        //
                        objRecepcionEsparrago.TotalTara = float.Parse(dataGridView1.SelectedRows[0].Cells["Tara"].Value.ToString());
                        objRecepcionEsparrago.TotalPesoBruto = float.Parse(dataGridView1.SelectedRows[0].Cells["PBruto"].Value.ToString());
                        objRecepcionEsparrago.TotalNeto = float.Parse(dataGridView1.SelectedRows[0].Cells["PNeto"].Value.ToString());
                        objRecepcionEsparrago.PesoPromedio = float.Parse(dataGridView1.SelectedRows[0].Cells["PesoProm"].Value.ToString());
                        //----------------------//
    
                        lblID.Text = objRecepcionEsparrago.IdRecepcionPLanta.ToString();
                        dtpFechaRecepcion.Text = objRecepcionEsparrago.Fecha.ToString();
                        lblIdChofer.Text = objRecepcionEsparrago.IdChofer.ToString();
                        cmbChofer.SelectedValue = objRecepcionEsparrago.IdChofer.ToString();
                        //
                        txtPlaca.Text = objRecepcionEsparrago.PlacaVehiculo;
                        //
                        txtJabas.Text = objRecepcionEsparrago.TotalJabas.ToString();
                        lblIdTipoJaba.Text = objRecepcionEsparrago.IdTipoJaba.ToString();
                        cmbTipoJaba.SelectedValue = objRecepcionEsparrago.IdTipoJaba.ToString();
                        txtTipoJabaPeso.Text = objRecepcionEsparrago.PesoJaba.ToString();
                        lblIdTipoParihuela.Text = objRecepcionEsparrago.IdTipoParihuela.ToString();
                        cmbTipoParihuela.SelectedValue = objRecepcionEsparrago.IdTipoParihuela.ToString();
                        txtTipoParihuelaPeso.Text = objRecepcionEsparrago.PesoParihuela.ToString();
                        //
                        txtPesoCampo.Text = objRecepcionEsparrago.TotalPesoCampo.ToString();
                        //
                        txtTara.Text = objRecepcionEsparrago.TotalTara.ToString();
                        txtPesoBruto.Text = objRecepcionEsparrago.TotalPesoBruto.ToString();
                        txtPesoNeto.Text = objRecepcionEsparrago.TotalNeto.ToString();
                        txtPesoPromedio.Text = objRecepcionEsparrago.PesoPromedio.ToString();
                        lblMaquina.Text = Environment.MachineName.Trim();

                        btnModificar.Visible = false;
                        gbPesos.Visible = true;
                        gbMonto.Visible = true;
                        btnActualizar.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                MessageBox.Show("No selecciono ningun registro");
            }
            frmInputboxx.txtCredencial.Clear();
            cargar();            
        }
        private void btnActualizar_Click(object sender, EventArgs e)
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
                objRecepcionEsparrago.IdRecepcionPLanta = int.Parse(lblID.Text);
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
                int resultado = objRecepcionEsparragoConexion.RecepcionEsparragoUpdateBystoredProcedure(objRecepcionEsparrago);
                if (resultado == 1)
                    MessageBox.Show("Actualizado Correctamente");
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
            if (float.Parse(txtPesoBruto.Text) < 0)
            {
                MessageBox.Show("El Peso Bruto no puede ser menor a cero", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (float.Parse(txtPesoNeto.Text) < 0)
            {
                MessageBox.Show("El Peso Neto no puede ser menor a cero", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            gbPesos.Visible = false;
            gbMonto.Visible = false;
            btnActualizar.Visible = false;
            btnModificar.Visible = true;
            cargar();
            Suma();
        }
    

            //private void btnBuscar_Click(object sender, EventArgs e)
            // {
           
            //}

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            frmRecepcionEsparragoBusqueda frmRecepcionEsparragoBusqueda = new frmRecepcionEsparragoBusqueda();
            frmRecepcionEsparragoBusqueda.ShowDialog();
            cargar();
        }
    }
}




