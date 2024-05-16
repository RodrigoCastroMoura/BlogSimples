using Microsoft.AspNetCore.Mvc;
using BlogProjeto.Models;
using BlogProjeto.Services;

namespace BlogProjeto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public AutenticacaoController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (_autenticacaoService.Login(model.NomeUsuario, model.Senha))
            {
                return Ok("Login bem-sucedido");
            }
            return BadRequest("Usuário ou senha inválidos");
        }

        [HttpPost("registrar")]
        public IActionResult Registrar([FromBody] Usuario novoUsuario)
        {
            if (_autenticacaoService.Registrar(novoUsuario))
            {
                return Ok("Usuário registrado com sucesso");
            }
            return BadRequest("Nome de usuário já está em uso");
        }
    }
}
