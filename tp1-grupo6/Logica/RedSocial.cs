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
            if (usuarios.Count > 0)
            {
                bool encontre = false;
                //registro el ID del usuario a modificar
                int id = 0;
                id = u.ID;
                foreach (Usuario nuevoUsuario in usuarios)
                {
                    if (nuevoUsuario.ID == id)
                    {
                        usuarios.Remove(u);
                    }
                    else
                    {
                       // Usuario nuevoUsuario = new Usuario(user.ID, user.DNI, user.Nombre, user.Apellido, user.Mail, user.Password, user.IntentosFallidos, user.Bloqueado);
                        usuarios.Add(nuevoUsuario);
                        IdUsuarios++;
                        nuevoUsuario.ID = IdUsuarios;
                    }
                }
            }
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

        public bool CerrarSesion(Usuario u)
        {
            //Pregunto si existe usuario Actual
            if (usuarioActual != null) 
            {
                //seteo el usuario actual a null
                usuarioActual = null;
            }
            return true;
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
            if (usuarioActual != null)
            {
                //usuarioActual.Amigos.Remove(amigo);
                exAmigo.Amigos.Remove(usuarioActual);
            }
        }

        public void Postear(Post p, List<Tag> t)
        {
            bool encontre = false;

            posts.Add(p);
            usuarioActual.MisPosts.Add(p);
            foreach (Tag tagP in t)
            {
                encontre = false;

                foreach (Tag tag in tags)
                {
                    if (tag == tagP)
                    {
                        encontre = true;
                    }
                }

                if (encontre == false)
                {
                    tags.Add(tagP);
                }

                tagP.Posts.Add(p);
                p.Tags.Add(tagP);

            }
        }

        public void ModificarPost(int pID, Usuario pUsuario, string pContenido, List<Comentario> pComentarios, List<Reaccion> pReacciones, List<Tag> pTags, DateTime pFecha)
        {
            foreach (Post post in posts)
            {
                if (post.ID == pID)
                {
                    //post.Usuario = pUsuario;
                    post.Contenido = pContenido;
                    post.Comentarios = pComentarios;
                    post.Reacciones = pReacciones;
                    post.Tags = pTags;
                    post.Fecha = pFecha;

                }
            }
        }

        public void EliminarPost(Post p)
        {

        }

        public void Comentar(Post p, Comentario c)
        {
            //pregunto si el conteo de post es mayor a 0 para determinar si existen posts
            if (posts.Count > 0)
            {
                bool encontre = false;
                //registro el ID del post a guardar
                int id = 0;
                id = p.ID;
                foreach (Post postAux in posts)
                {
                    if (postAux.ID == id)
                    {
                        encontre = true;
                        //Agrego al Post actual el comentario
                        postAux.Comentarios.Add(c);
                        //al usuario actual le agrego a su lista el comentario que realizó
                        usuarioActual.MisComentarios.Add(c);
                        //si realiza mas comentarios deben tener ID  diferente
                        //usuarioActual.MisComentarios.
                    }
                }
            }
        }

        public void ModificarComentario(Post p, Comentario c)
        {
                if (posts.Count > 0)
                {
                    bool encontre = false;
                    //registro el ID del post a guardar
                    int id = 0;
                    id = p.ID;
                    foreach (Post postAux in posts)
                    {
                        if (postAux.ID == id)
                        {
                            encontre = true;
                            //remuevo el ultimo comentario dentro del pool de comentarios del usuario actual
                            //usuarioActual.MisComentarios.Remove(usuarioActual.MisComentarios.Last());
                            //remuevo el ultimo Post dentro del pool de Posts 
                            //postAux.Comentarios.Remove(postAux.Comentarios.Last());
                            //al usuario actual le agrego a su lista el comentario que realizó
                            postAux.Comentarios.Add(c);
                        }
                    }
                }
         }


        public void QuitarComentario(Post p, Comentario c)
        {
            {
                if (posts.Count > 0)
                {

                    bool encontre = false;


                    //registro el ID del post a guardar
                    int id = 0;

                    id = p.ID;



                    foreach (Post postAux in posts)
                    {

                        if (postAux.ID == id)
                        {
                            encontre = true;


                            //remuevo el ultimo Post dentro del pool de Posts 
                           // postAux.Comentarios.Remove(postAux.Comentarios.Last());
                        }

                    }
                }
            }
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
