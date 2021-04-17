using CNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPresentacion
{
    public partial class FrmPrincipal : Form
    {
        
        public FrmPrincipal()
        {
            InitializeComponent();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            pictureBox4.Visible = false;
            pictureBox5.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            pictureBox5.Visible = false;
            pictureBox4.Visible = true;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            pictureBox6.Visible = true;
            pictureBox5.Visible = false;

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            pictureBox5.Visible = true;
            pictureBox6.Visible = false;
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Listar()
        {
            try
            {
                dataVer.DataSource = NPersona.Listar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

    

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtEdad.Clear();
            btnInsertar.Visible = true;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            
            try
            {
                string Rpta = "";
                if(txtNombre.Text == string.Empty || txtApellido.Text == string.Empty || txtTelefono.Text == string.Empty || txtEdad.Text == string.Empty)
                {
                    this.MensajeError("ERROR: No puede dejar campos vacios");
                }
                else
                {
                    Rpta = NPersona.Insertar(txtNombre.Text, txtApellido.Text, txtTelefono.Text, Int32.Parse(txtEdad.Text));
                    if(Rpta.Equals("OK"))
                    {
                        this.MensajeOk("se inserto correctamente");
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        
    }

    
}
