﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyEncryption;

namespace tp1_grupo6.Logica
{
    public class RedSocial
    {
        private List<Usuario> usuarios;
        private int IdUsuarios;
        private List<Post> posts;
        private List<Tag> tags;
        public Usuario usuarioActual { get; set; }
        public IDictionary<string, int> loginHistory;
        private const int cantMaxIntentos = 3;

        public RedSocial()
        {
            usuarios = new List<Usuario>();
            posts = new List<Post>();
            tags = new List<Tag>();
            this.usuarioActual = usuarioActual;
            this.IdUsuarios = 0;
            this.loginHistory = new Dictionary<string, int>();
        }

        public bool RegistrarUsuario(int DNI, string Nombre, string Apellido, string Mail, string Password)
        {
            if (!ExisteUsuario(Mail))
            {
                try
                {
                    Usuario usuario = new Usuario(DNI, Nombre, Apellido, Mail, this.Hashear(Password));
                    usuarios.Add(usuario);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        private string Hashear(string contraseñaSinHashear)
        {
            try
            {
                string passwordHash = SHA.ComputeSHA256Hash(contraseñaSinHashear);
                return passwordHash;
            }
            catch (Exception)
            {
                return "error";
            }
        }

        public string Intentos(string usuarioIngresado)
        {
            string mensaje = null;
            if (loginHistory.TryGetValue(usuarioIngresado, out int value))
            {
                loginHistory[usuarioIngresado] = loginHistory[usuarioIngresado] + 1;
                mensaje = "Datos incorrectos, intento " + loginHistory[usuarioIngresado] + "/3";
                if (loginHistory[usuarioIngresado] == cantMaxIntentos)
                {
                    this.bloquearDesbloquearUsuario(usuarioIngresado, true);
                    mensaje = "Intento 3/3, usuario bloqueado.";
                }
            }
            else
            {
                mensaje = "Datos incorrectos, intento 1/3";
                loginHistory.Add(usuarioIngresado, 1);
            }
            return mensaje;
        }


        public bool EstaBloqueado(string Mail)
        {
            return DevolverUsuario(Mail).Bloqueado;
        }


        //Falta probar
        public void ModificarUsuario(int newID, string newNombre, string newApellido, string newMail, string newPassword)
        {

            if (usuarioActual != null && usuarioActual.ID == newID)
            {


                usuarioActual.Nombre = newNombre;
                usuarioActual.Apellido = newApellido;
                usuarioActual.Mail = newMail;
                usuarioActual.Password = newPassword;


            }
        }

        //no se si funciona
        public void EliminarUsuario(Usuario u, string Mail)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Mail == Mail)
                {
                    usuarios.Remove(u);
                }
            }
        }




        // Devuelve el Usuario correspondiente al Mail recibido.
        private Usuario DevolverUsuario(string Mail)
        {
            int a = 0;
            Usuario usuarioEncontrado = null;

            if (usuarios.Count() > 0)
            {
                while (usuarios.Count() > a || usuarioEncontrado == null)
                {
                    if (usuarios[a].Mail == Mail)
                    {
                        usuarioEncontrado = usuarios[a];
                    }
                    a++;
                }
            }
            return usuarioEncontrado;
        }
        // Se autentica al Usuario.
        public bool IniciarUsuario(string Mail, string Password)
        {
            bool ok = false;
            Usuario usuario = this.DevolverUsuario(Mail);
            if (usuario.Password == this.Hashear(Password))
            {
                usuarioActual = usuario;
                ok = true;
            }
            return ok;
        }
        // Se valida si el usuario existe y devuelve true o false
        public bool ExisteUsuario(string Mail)
        {
            if (DevolverUsuario(Mail) != null)
            {
                return true;
            }
            return false;
        }
        // se obtiene el ID del usuario
        public int obtenerUsuarioId(string Mail)
        {
            foreach (Usuario u in usuarios)
            {
                if (u.Mail == Mail)
                {
                    return u.ID;
                }
            }
            return 0;
        }

        // Bloquea/Desbloquea el Usuario que se corresponde con el DNI recibido.
        public bool bloquearDesbloquearUsuario(string Mail, bool Bloqueado)
        {
            bool todoOk = false;
            foreach (Usuario u in usuarios)
            {
                if (u.Mail == Mail)
                {
                    u.Bloqueado = Bloqueado;
                    todoOk = true;
                }
            }
            return todoOk;
        }














        // funciona
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












        // no se si funciona
        public void AgregarAmigo(Usuario amigo)
        {
            if (usuarioActual != null)
            {

                usuarioActual.Amigos.Add(amigo);

            }

        }









        // no funciona
        public void QuitarAmigo(Usuario exAmigo)
        {
            if (usuarioActual != null)
            {
                //usuarioActual.Amigos.Remove(amigo);
                exAmigo.Amigos.Remove(usuarioActual);
            }
        }













        // no se si funciona
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

















        // no funciona
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










        // no hecho
        public void EliminarPost(Post p)
        {

        }














        // no funciona
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

















        // no funciona
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
