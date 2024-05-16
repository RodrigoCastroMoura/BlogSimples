using BlogProjeto.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlogProjeto.Data.Repositorios
{
    public class PostagemRepositorio : IPostagemRepositorio
    {
        private readonly ApplicationDbContext _context;

        public PostagemRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public Postagem ObterPorId(int id)
        {
            return _context.Postagens.Find(id);
        }

        public void Adicionar(Postagem postagem)
        {
            _context.Postagens.Add(postagem);
        }

        public void Atualizar(Postagem postagem)
        {
            _context.Entry(postagem).State = EntityState.Modified;
        }

        public void Remover(Postagem postagem)
        {
            _context.Postagens.Remove(postagem);
        }

        public List<Postagem> ObterTodas()
        {
            return _context.Postagens.ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }

    public interface IPostagemRepositorio
    {
        Postagem ObterPorId(int id);
        void Adicionar(Postagem postagem);
        void Atualizar(Postagem postagem);
        void Remover(Postagem postagem);
        List<Postagem> ObterTodas();
        void Salvar();
    }
}
