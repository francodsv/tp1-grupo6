using System;
using System.Collections.Generic;
using System.Text;

namespace tp1_grupo6.Logica
{
    public class RedSocial
    {
        List<Usuario> usuarios = new List<Usuario>();

        List<Post> posts = new List<Post>();

        List<Tag> tags = new List<Tag>();

        public Usuario usuarioActual;

        /* CREON QUE NO NECESITARIA CONSTRUCTOR RED SOCIAL
        public RedSocial(List<Usuario> usuarios, List<Post> posts, List<Tag> tags, Usuario usuarioActual)
        {
            this.usuarios = usuarios;
            this.posts = posts;
            this.tags = tags;
            this.usuarioActual = usuarioActual;
        }
        */

        public RegistrarUsuario(Usuario u)
        {

        } 

        public ModificarUsuario(Usuario u)
        {

        }

        public EliminarUsuario()
        {

        }

        public IniciarUsuario(string usuario, string contraseña)
        {
            //bool
        }

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
