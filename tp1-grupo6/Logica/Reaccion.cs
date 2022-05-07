using System;
using System.Collections.Generic;
using System.Text;

namespace tp1_grupo6.Logica
{
    public class Reaccion
    {
        public int ID { get; set; }
        public Enum Tipo { get; set; }
        public Post Post { get; set; }
        public Usuario Usuario { get; set; }


        public Reaccion(int ID, Enum Tipo, Post Post, Usuario Usuario)
        {
            this.ID = ID;
            this.Tipo = Tipo;
            this.Post = Post;
            this.Usuario = Usuario;
        }
    }
}
