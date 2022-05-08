using System;
using System.Collections.Generic;
using System.Text;


namespace tp1_grupo6.Logica
{

	public class Post
{
	public Post()
	{
		public int ID { get; set; }
	public User usuario { get; set; }
	public string Contenido { get; set; }
	public List <Comentario>  Comentarios { get; set; }
    public List <Reaccion> Reacciones { get; set; }
	public List <Tag> Tags { get; set; }
	public Date Fecha { get; set; }




}
}
}