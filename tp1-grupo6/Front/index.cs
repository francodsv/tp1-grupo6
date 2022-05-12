using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using tp1_grupo6.Logica;

namespace tp1_grupo6.Front
{
    public partial class Index : Form
    {
        private RedSocial miRed;
        private Usuario usuario;

        public Index(RedSocial miRed, Usuario usuario)
        {
            InitializeComponent();
            this.miRed = miRed;
            this.usuario = usuario;
        }

        private void index_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //  
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
   



            /*if (miRed.CerrarSesion(usuario) == true)
            {
                Form index = new Index(this.miRed, this.usuario);
                Form login = new Login();
                login.Show();
            }*/

        }
    }
}
