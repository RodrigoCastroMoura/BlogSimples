using BlogProjeto.Models;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

namespace BlogProjeto.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public Usuario ObterPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public Usuario ObterPorNomeUsuario(string nomeUsuario)
        {
            return _context.Usuarios.First(u => u.NomeUsuario == nomeUsuario);
        }

        public void Adicionar(Usuario usuario)
        {

            _context.Usuarios.Add(usuario);
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
        }

        public void Remover(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _context.Usuarios.ToList();
        }

        public bool Existe(string nomeUsuario)
        {
            return _context.Usuarios.Any(u => u.NomeUsuario == nomeUsuario);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }

    public interface IUsuarioRepositorio
    {
        Usuario ObterPorId(int id);
        Usuario ObterPorNomeUsuario(string nomeUsuario);
        void Adicionar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Remover(Usuario usuario);
        IEnumerable<Usuario> ObterTodos();
        bool Existe(string nomeUsuario);
        void Salvar();
    }
}
