using System;

namespace BlogProjeto.Models
{
    public class Postagem
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
        public int AutorId { get; set; }
    }
}
