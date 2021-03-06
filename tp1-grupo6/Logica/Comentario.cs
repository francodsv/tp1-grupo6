using System;
using System.Collections.Generic;
using System.Text;

namespace tp1_grupo6.Logica
{
    public class Comentario
    {
        public int ID { get; set; }
        public Post Post { get; set; }
        public string Contenido { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime fecha { get; set; }


        public Comentario(int ID, Post Post, string Contenido, Usuario Usuario, DateTime fecha)
        {
            this.ID = ID;
            this.Post = Post;
            this.Contenido = Contenido;
            this.Usuario = Usuario;
            this.fecha = fecha;
        }
    }
}
