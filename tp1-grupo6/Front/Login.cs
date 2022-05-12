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
using EasyEncryption;

namespace tp1_grupo6
{
    public partial class Login : Form
    {
        private const int cantMaxIntentos = 3;
        public RedSocial miRed;
        private Usuario usuario;
        public string usuarioIngresado;
        public string contraseniaIngresada;
        public bool loginOk;
        public IDictionary<string, int> loginHistory = new Dictionary<string, int>();
        private string[] argumentos;

        public Login(string[] args)
        {
            miRed = new RedSocial();
            
            InitializeComponent();
            argumentos = args;
        }
        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelIntentos.Text = "";
            usuarioIngresado = textUsuario.Text;
            contraseniaIngresada = textContrasenia.Text;
            usuario = miRed.devolverUsuario(usuarioIngresado);

            if (usuario != null)
            {
                string contraseniaIngresadaHash = SHA.ComputeSHA256Hash(contraseniaIngresada);
                loginOk = miRed.IniciarUsuario(usuarioIngresado, contraseniaIngresadaHash);
                if (loginOk)
                {
                    if (!usuario.Bloqueado)
                    {
                            argumentos[0] = "user";
                            Form formIndex = new Front.Index(this.miRed, this.usuario);
                            textUsuario.Text = "";
                            textContrasenia.Text = "";
                            loginHistory.Clear();
                            this.Hide();
                            formIndex.ShowDialog();
                            this.Show();
                        
                    }
                    else
                    {
                        labelIntentos.Text = "Su usuario está bloqueado.";
                    }
                }
                else
                {
                    if (loginHistory.TryGetValue(usuarioIngresado, out int value))
                    {
                        loginHistory[usuarioIngresado] = loginHistory[usuarioIngresado] + 1;
                        labelIntentos.Text = "Datos incorrectos, intento " + loginHistory[usuarioIngresado] + "/3";
                        if (loginHistory[usuarioIngresado] == cantMaxIntentos)
                        {
                            miRed.bloquearDesbloquearUsuario(usuario.Mail, true);
                            labelIntentos.Text = "Intento 3/3, usuario bloqueado.";
                        }
                    }
                    else
                    {
                        labelIntentos.Text = "Datos incorrectos, intento 1/3";
                        loginHistory.Add(usuarioIngresado, 1);
                    }
                }
            }
            else
            {
                labelIntentos.Text =  "Usuario inexistente";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            Form registrarse = new Registrar(this.miRed);
            textUsuario.Text = "";
            textContrasenia.Text = "";
            loginHistory.Clear();
            this.Hide();
            registrarse.ShowDialog();
            this.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

