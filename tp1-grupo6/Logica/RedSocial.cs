using System;
using System.Collections.Generic;
using System.Text;


namespace tp1_grupo6.Logica
{
    public class RedSocial
    {
        private List<Usuario> usuarios;

        private int IdUsuarios;

        List<Post> posts;

        private List<Tag> tags;

        public Usuario usuarioActual { get; set; }

        public RedSocial(/*List<Usuario> usuarios, Usuario usuarioActual*/)
        {
            this.usuarios = new List<Usuario>();
            this.posts = new List<Post>();
            this.tags = new List<Tag>();
            this.usuarioActual = usuarioActual;
            this.IdUsuarios = 0;
        }

        public void RegistrarUsuario(int DNI, String Nombre, String Apellido, String Mail, String Password)
        {
            usuarios.Add(new Usuario(DNI, Nombre, Apellido, Mail, Password));
        }

        public void RegistrarUsuario(Usuario user)
        {
            /*foreach (Usuario user in usuarios)
            {
                if (user.Mail != Mail)
                {*/
                    Usuario nuevoUsuario = new Usuario(user.ID, user.DNI, user.Nombre, user.Apellido, user.Mail, user.Password, user.IntentosFallidos, user.Bloqueado);
                    usuarios.Add(nuevoUsuario);
                    IdUsuarios++;
                    nuevoUsuario.ID = IdUsuarios;
                /*}
                else
                {
                    Console.WriteLine("El usuario que desea crear ya se encuentra registrea");
                }
            }*/
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

        public bool IniciarUsuario(String mail, String Password)
        {
            bool encontre = false;
            foreach (Usuario user in usuarios)
            {
                if (user.Mail.Equals(mail) && user.Password.Equals(Password))
                {
                    encontre = true;
                    usuarioActual = user;
                }
                else
                {
                    Console.WriteLine("El usuario no existe o algun dato no es correcto en las credenciales ingresadas");
                }

            }
            return encontre;
        }

        public void CerrarSesion()
        {

        }

        public void AgregarAmigo(Usuario amigo)
        {
            if (usuarioActual != null)
            {
                usuarioActual.Amigos.Add(amigo);
            }

        }

        public void QuitarAmigo(Usuario exAmigo)
        {

        }

        public void Postear(Post p, List<Tag> t)
        {

        }

        public void ModificarPost(Post p)
        {

        }

        public void EliminarPost(Post p)
        {

        }

        public void Comentar(Post p, Comentario c)
        {

        }

        public void ModificarComentario(Post p, Comentario c)
        {

        }

        public void QuitarComentario(Post p, Comentario c)
        {

        }

        public void Reaccionar(Post p, Reaccion r)
        {

        }

        public void ModificarReaccion(Post p, Reaccion r)
        {

        }

        public void QuitarReaccion(Post p, Reaccion r)
        {

        }

        public void MostrarDatos()
        {

        }

        public void MostrarPosts()
        {

        }

        public void MostrarPostsAmigos()
        {

        }

        public void BuscarPosts(string Contenido, DateTime Fecha, Tag t)
        {

        }







    }
}
