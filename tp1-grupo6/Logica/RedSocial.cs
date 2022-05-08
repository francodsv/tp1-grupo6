using System;
using System.Collections.Generic;
using System.Text;


namespace tp1_grupo6.Logica
{
    public class RedSocial
    {
        private List<Usuario> usuarios;

        private List<Post> posts;

        private List<Tag> tags;

        public Usuario usuarioActual { get; set; }

        private int IdUsuarios;

        public RedSocial(List<Usuario> usuarios, List<Post> posts, List<Tag> tags, Usuario usuarioActual)
        {
            this.usuarios = new List<Usuario>();
            this.posts = new List<Post>();
            this.tags = new List<Tag>();
            this.usuarioActual = usuarioActual;
            this.IdUsuarios = 0;
        }
        

        public void RegistrarUsuario(string Mail)
        {   
            foreach (Usuario user in usuarios)
            {
                if (user.Mail != Mail)
                {
                    Usuario nuevoUsuario = new Usuario(user.ID, user.DNI, user.Nombre, user.Apellido, user.Mail, user.Password, user.IntentosFallidos, user.Bloqueado);
                    usuarios.Add(nuevoUsuario);
                    IdUsuarios++;
                    nuevoUsuario.ID = IdUsuarios;
                }
                else
                {
                    Console.WriteLine("El usuario que desea crear ya se encuentra registrado");
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
            }
            return encontre;
        }

        public void CerrarSesion()
        {
            if(usuarioActual != null)
            {
                usuarioActual = null;
            }
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
            if (usuarioActual.Amigos.Contains(exAmigo))
            {
                usuarioActual = exAmigo;

                usuarioActual.Amigos.Remove(exAmigo);
            }

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

        public Comentar(Post p, Comentario c)
        {

        }

        public ModificarComentario(Post p, Comentario c)
        {

        }

        public QuitarComentario(Post p, Comentario c)
        {

        }

        public Reaccionar(Post p, Reaccion r)
        {

        }

        public ModificarReaccion(Post p, Reaccion r)
        {

        }

        public QuitarReaccion(Post p, Reaccion r)
        {

        }

        public MostrarDatos()
        {

        }

        public MostrarPosts()
        {

        }

        public MostrarPostsAmigos()
        {

        }

        public BuscarPosts(string Contenido, DateTime Fecha, Tag t)
        {

        }







    }
}
