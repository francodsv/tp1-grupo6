using System;
using System.Collections.Generic;
using System.Text;

namespace tp1_grupo6.Logica
{
     public class Usuario
    {
        public int ID { get; set; }

        public int DNI { get; set; }

        public String Nombre{ get; set; }

        public String Apellido  { get; set; }
        public String Mail { get; set; }

        public String Password { get; set; }

        public int IntentosFallidos { get; set; }
        public bool Bloqueado { get; set; }
        public List<Usuario> Amigos { get; set; }
        public List <Post> MisPosts { get; set; }
        public List<Comentario> MisComentarios { get; set; }
        public List<Reaccion> MisReacciones { get; set; }

        //creeria que el constructor no necesita crearse con reacciones , comentarios , posts y usuarios
        /*public Usuario(String Nombre, String Password) {
            this.Nombre = Nombre;
            this.Password = Password;
        }*/

        public Usuario(){ }
        public Usuario (int ID,int DNI, String Nombre, String Apellido, String Mail, String Password, int IntentosFallidos, bool Bloqueado)
        {
            this.ID = ID;
            this.DNI = DNI;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Mail=Mail;
            this.Password = Password;
            this.IntentosFallidos = IntentosFallidos;
            this.Bloqueado = false;

        }

        public Usuario(int dni, string nombre, string apellido, string mail, string password)
        {
            DNI = dni;
            Nombre = nombre;
            Apellido = apellido;
            Mail = mail;
            Password = password;
        }

        public override string ToString()
        {
            return ID + "," + DNI + "," + Nombre + "," + Mail + "," + Password + ","  + Bloqueado;

        }
    }
}
