using Microsoft.AspNetCore.Mvc;
using BlogProjeto.Models;
using BlogProjeto.Services;

namespace BlogProjeto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostagemController : ControllerBase
    {
        private readonly IPostagemService _postagemService;

        public PostagemController(IPostagemService postagemService)
        {
            _postagemService = postagemService;
        }

        [HttpGet]
        public IActionResult ObterTodas()
        {
            var postagens = _postagemService.ObterTodasPostagens();
            return Ok(postagens);
        }

        [HttpPost]
        public IActionResult CriarPostagem([FromBody] Postagem novaPostagem)
        {
            _postagemService.CriarPostagem(novaPostagem);
            return Ok("Postagem criada com sucesso");
        }
    }
}
