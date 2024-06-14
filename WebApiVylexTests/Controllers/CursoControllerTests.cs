using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVylex.Controllers;
using WebApiVylex.DTOs;
using WebApiVylex.Models;
using WebApiVylex.Repository.Interface;

namespace WebApiVylexTests.Controllers
{
    public class CursoControllerTests
    {
        private readonly Mock<ICursoRepository> _mockCursoRepo;
        private readonly Mock<IAvaliacaoRepository> _mockAvaliacaoRepo;
        private readonly CursoController _controller;

        public CursoControllerTests()
        {
            _mockCursoRepo = new Mock<ICursoRepository>();
            _mockAvaliacaoRepo = new Mock<IAvaliacaoRepository>();
            _controller = new CursoController(_mockCursoRepo.Object, _mockAvaliacaoRepo.Object);
        }

        [Fact]
        public async Task GetCursoComAvaliacoes_ReturnsNotFound_WhenCursoDoesNotExist()
        {
            // Arrange
            _mockCursoRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Curso)null);

            // Act
            var result = await _controller.GetCursoComAvaliacoes(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetCursoComAvaliacoes_ReturnsCursoWithAvaliacoes_WhenCursoExists()
        {
            // Arrange
            var curso = new Curso { Id = 1, Nome = "Curso Teste", Descricao = "Descrição Teste" };
            var estudante = new Estudante { Id = 1, Nome = "Estudante Teste" };
            var avaliacoes = new List<Avaliacao>
        {
            new Avaliacao { Id = 1, CursoId = 1, EstudanteId = 1, Estudante = estudante, Estrelas = 5, Comentario = "Ótimo curso", DataHora = DateTime.Now }
        };

            _mockCursoRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(curso);
            _mockAvaliacaoRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(avaliacoes);

            // Act
            var result = await _controller.GetCursoComAvaliacoes(1);
            var okResult = result.Result as OkObjectResult;
            var cursoComAvaliacoes = okResult.Value as CursoComAvaliacoesDto;

            // Assert
            Assert.NotNull(okResult);
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotNull(cursoComAvaliacoes);
            Assert.Equal(1, cursoComAvaliacoes.Id);
            Assert.Single(cursoComAvaliacoes.Avaliacoes);
        }
    }
}
