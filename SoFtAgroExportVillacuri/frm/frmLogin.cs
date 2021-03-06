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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            if (txtUsuario.Text != "USUARIO" && txtUsuario.TextLength > 2)
            {
                if (txtContrasena.Text != "CLAVE")
                {
                    clsUsuarioAcceder objUsuarioAcceder = new clsUsuarioAcceder();
                    objUsuarioAcceder.Nombre = txtUsuario.Text;
                    objUsuarioAcceder.Clave = txtContrasena.Text;
                    clsUsuarioConexion objUsuarioConexion = new clsUsuarioConexion();
                    bool Validlogin = objUsuarioConexion.Login(objUsuarioAcceder);

                    if (Validlogin == true)
                    {
                        frmMenuPrincipal MenuPrincipal = new frmMenuPrincipal();
                        frmRecepcionEsparrago RecepcionEsparrago = new frmRecepcionEsparrago();
                        //clsPublic objPublic = new clsPublic();
                        //objPublic.Usuario = txtUsuario.Text;
                        //Convert.ToString(objPublic.IdUsuario.ToString()) = Convert.ToString(objUsuarioAcceder.IdUsario);
                        //MessageBox.Show("Welcom" + objUsuarioAcceder.ApellidoPaterno);
                        MenuPrincipal.Show();
                        MenuPrincipal.lblIdUsuario.Text = Convert.ToString(objUsuarioAcceder.IdUsario);
                        //MenuPrincipal.lblUsuario.Text = (objUsuarioAcceder.IdUsario + " " + objUsuarioAcceder.ApellidoMaterno + " " + objUsuarioAcceder.Nombres);
                        MenuPrincipal.lblUsuario.Text = objUsuarioAcceder.Nombre;
                        

                        MenuPrincipal.FormClosed += Logout;
                        this.Hide();
                    }
                    else
                    {
                        msgError("Incorrecto Usuario o Contraseña. \n    Please intentelo Otra vez");
                        txtContrasena.Text = "CLAVE";
                        txtContrasena.UseSystemPasswordChar = false;
                        txtUsuario.Focus();
                    }
                }
                else msgError("Please ingrese la Contraseña");
            }
            else msgError("Please ingrese el Usuario");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "CLAVE")
            {
                txtContrasena.Text = "";
                txtContrasena.ForeColor = Color.LightGray;
                txtContrasena.UseSystemPasswordChar = true;
            }
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "")
            {
                txtContrasena.Text = "CLAVE";
                txtContrasena.ForeColor = Color.DimGray;
                txtContrasena.UseSystemPasswordChar = false;
            }
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void msgError(string msg)
        {
            lblErrorMessagge.Text = "     " + msg;
            lblErrorMessagge.Visible = true;
        }
        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtContrasena.Text = "CLAVE";
            txtContrasena.UseSystemPasswordChar = false;
            txtUsuario.Text = "USUARIO";
            lblErrorMessagge.Visible = false;
            this.Show();
            txtUsuario.Focus();
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter )
            {
                txtContrasena.Focus();
            }
        }
        private void txtContrasena_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.Focus();
            }
        }
    }
}
