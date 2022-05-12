using System;
using System.Collections.Generic;
using System.Text;


namespace tp1_grupo6.Logica
{

	public class Post
	{

		public int ID { get; set; }
		public Usuario usuario { get; set; }
		public string Contenido { get; set; }
		public List<Comentario> Comentarios { get; set; }
		public List<Reaccion> Reacciones { get; set; }
		public List<Tag> Tags { get; set; }
		public DateTime Fecha { get; set; }

		public Post()
		{ }

		public Post(int ID, Usuario usuario, string Contenido, List<Comentario> Comentarios, List<Reaccion> Reacciones, List<Tag> Tags, DateTime Fecha)
		{
			this.ID = ID;
			this.usuario = usuario;
			this.Contenido = Contenido;
			this.Comentarios = Comentarios;
			this.Reacciones = Reacciones;
			this.Tags = Tags;
			this.Fecha = Fecha;
		}
	}
}
