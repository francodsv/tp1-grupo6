using System;
using System.Collections.Generic;
using System.Text;

namespace tp1_grupo6.Logica
{
    internal class Tag
    {
        public int ID    { get; set; }
        public String Palabra { get; set; }

        public List<Post> Posts { get; set; }


        public Tag(){}
        public Tag(int ID, String Palabra) {
         
            this.ID = ID;
            this.Palabra = Palabra;




        }
}
}
