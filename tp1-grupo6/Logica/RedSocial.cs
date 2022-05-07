using System;
using System.Collections.Generic;
using System.Text;


namespace tp1_grupo6.Logica
{
    public class RedSocial
    {
        private List<Usuario> usuarios;

        //List<Post> posts = new List<Post>();

        //List<Tag> tags = new List<Tag>();

        public Usuario usuarioActual { get; set; }

        public RedSocial(List<Usuario> usuarios, Usuario usuarioActual)
        {
            usuarios = new List<Usuario>();
            //this.posts = posts;
            //this.tags = tags;
            this.usuarioActual = usuarioActual;
        }
        

        public void RegistrarUsuario(int ID, int DNI, String Nombre, String Apellido, String Mail, String Password, int IntentosFallidos, bool Bloqueado)
        {   
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Mail != Mail)
                {
                    usuarios.Add(new Usuario(ID, DNI, Nombre, Apellido, Mail, Password, IntentosFallidos, Bloqueado));
                }   
            }   
        } 

        public void ModificarUsuario(Usuario u)
        {

        }

        public void EliminarUsuario(Usuario u, String Mail)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Mail == Mail)
                {
                    usuarios.Remove(u);
                }
            }
                
        }

        /*public IniciarUsuario(string usuario, string contraseña)
        {
            bool encontre = false;
            foreach (Usuario user in usuarios)
            {
                if (user.nombre.Equals(usuario) && user.pass.Equals(pass))
                {
                    encontre = true;
                    usuarioLogged = user;
                }
            }
            return encontre;
        }*/

        public CerrarSesion()
        {

        }

        public AgregarAmigo(Usuario amigo)
        {

        }

        public QuitarAmigo(Usuario exAmigo)
        {

        }

        public Postear(Post p, List<Tag> t)
        {

        }

        public ModificarPost(Post p)
        {

        }

        public EliminarPost(Post p)
        {

        }
    }
}
