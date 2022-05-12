using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tp1_grupo6.Logica;
using tp1_grupo6.Front;

namespace tp1_grupo6
{
    public partial class Login : Form
    {

        public RedSocial miRed;

        private Usuario usuario;

        public Login()
        {
            InitializeComponent();
            miRed = new RedSocial();
            miRed.RegistrarUsuario(95710895, "Franco", "Perez", "mail@gmail.com", "contraseña");
            
        }
        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (miRed.IniciarUsuario(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("OK");
                Form index = new Front.Index(this.miRed, this.usuario);
                Form login = new Login();  
                index.Close();
                login.Show();
            }
            else
            {
                MessageBox.Show("El usuario no existe o algun dato no es correcto en las credenciales ingresadas");
                //label3.Text = "Inicio de sesión: NO";
            }
        }
    }
}
