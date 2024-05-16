using BlogProjeto.Data.Repositorios;
using BlogProjeto.Models;


namespace BlogProjeto.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AutenticacaoService(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public bool Login(string nomeUsuario, string senha)
        {
            var usuario = _usuarioRepositorio.ObterPorNomeUsuario(nomeUsuario);
            if (usuario != null && usuario.Senha == senha)
            {
                // Lógica de autenticação bem-sucedida
                return true;
            }
            return false;
        }

        public bool Registrar(Usuario novoUsuario)
        {
            if (!_usuarioRepositorio.Existe(novoUsuario.NomeUsuario))
            {
                _usuarioRepositorio.Adicionar(novoUsuario);
                _usuarioRepositorio.Salvar();
                return true;
            }
            return false;
        }
    }

    public interface IAutenticacaoService
    {
        bool Login(string nomeUsuario, string senha);
        bool Registrar(Usuario novoUsuario);
    }
}
