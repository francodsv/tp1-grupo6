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
    public partial class Perfil : Form
    {
        private RedSocial miRed;
        private Usuario usuario;
        public Perfil(RedSocial miRed, Usuario usuario)
        {
            this.miRed = miRed;
            this.usuario = usuario;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {






        }
    }
}
