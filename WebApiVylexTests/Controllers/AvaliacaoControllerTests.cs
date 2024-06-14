using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVylex.Controllers;
using WebApiVylex.Models;
using WebApiVylex.Repository.Interface;

namespace WebApiVylexTests.Controllers
{
    public class AvaliacaoControllerTests
    {
        private readonly Mock<IAvaliacaoRepository> _mockAvaliacaoRepo;
        private readonly Mock<ICursoRepository> _mockCursoRepo;
        private readonly Mock<IEstudanteRepository> _mockEstudanteRepo;
        private readonly AvaliacaoController _controller;

        public AvaliacaoControllerTests()
        {
            _mockAvaliacaoRepo = new Mock<IAvaliacaoRepository>();
            _mockCursoRepo = new Mock<ICursoRepository>();
            _mockEstudanteRepo = new Mock<IEstudanteRepository>();
            _controller = new AvaliacaoController(_mockAvaliacaoRepo.Object, _mockCursoRepo.Object, _mockEstudanteRepo.Object);
        }

        [Fact]
        public async Task GetAvaliacoes_ReturnsOkResult_WithListOfAvaliacoes()
        {
            // Arrange
            var avaliacoes = new List<Avaliacao> { new Avaliacao { Id = 1, Estrelas = 5, Comentario = "Ótimo curso" } };
            _mockAvaliacaoRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(avaliacoes);

            // Act
            var result = await _controller.GetAvaliacoes();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnAvaliacoes = Assert.IsType<List<Avaliacao>>(okResult.Value);
            Assert.Single(returnAvaliacoes);
        }

        [Fact]
        public async Task GetAvaliacao_ReturnsNotFound_WhenAvaliacaoDoesNotExist()
        {
            // Arrange
            _mockAvaliacaoRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Avaliacao)null);

            // Act
            var result = await _controller.GetAvaliacao(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetAvaliacao_ReturnsOkResult_WithAvaliacao()
        {
            // Arrange
            var avaliacao = new Avaliacao { Id = 1, Estrelas = 5, Comentario = "Ótimo curso" };
            _mockAvaliacaoRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(avaliacao);

            // Act
            var result = await _controller.GetAvaliacao(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnAvaliacao = Assert.IsType<Avaliacao>(okResult.Value);
            Assert.Equal(1, returnAvaliacao.Id);
        }
    }
}
