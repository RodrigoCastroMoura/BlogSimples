using BlogProjeto.Data.Repositorios;
using BlogProjeto.Models;

using System.Collections.Generic;

namespace BlogProjeto.Services
{
    public class PostagemService : IPostagemService
    {
        private readonly IPostagemRepositorio _postagemRepositorio;

        public PostagemService(IPostagemRepositorio postagemRepositorio)
        {
            _postagemRepositorio = postagemRepositorio;
        }

        public void CriarPostagem(Postagem novaPostagem)
        {
            _postagemRepositorio.Adicionar(novaPostagem);
            _postagemRepositorio.Salvar();
        }

        public List<Postagem> ObterTodasPostagens()
        {
            return _postagemRepositorio.ObterTodas();
        }
    }
    public interface IPostagemService
    {
        void CriarPostagem(Postagem novaPostagem);
        List<Postagem> ObterTodasPostagens();
    }
}
