using Xunit;
using Moq;
using BlogProjeto.Data;
using BlogProjeto.Data.Repositorios;
using BlogProjeto.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogProjeto.Tests.Repositorios
{
    public class UsuarioRepositorioTests
    {
        [Fact]
        public void ObterPorNomeUsuario_UsuarioExistente_DeveRetornarUsuario()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var mockDbContext = new ApplicationDbContext(options);
            mockDbContext.Usuarios.Add(new Usuario { Id = 1, NomeUsuario = "usuario", Senha = "senha" });
            mockDbContext.SaveChanges();

            var repositorio = new UsuarioRepositorio(mockDbContext);

            // Act
            var usuario = repositorio.ObterPorNomeUsuario("usuario");

            // Assert
            Assert.NotNull(usuario);
            Assert.Equal("usuario", usuario.NomeUsuario);
            Assert.Equal("senha", usuario.Senha);
        }

        [Fact]
        public void ObterPorNomeUsuario_UsuarioNaoExistente_DeveRetornarNulo()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var mockDbContext = new ApplicationDbContext(options);
            var repositorio = new UsuarioRepositorio(mockDbContext);

            // Act
            var usuario = repositorio.ObterPorNomeUsuario("usuario");

            // Assert
            Assert.Null(usuario);
        }

        // Outros testes...
    }
}
