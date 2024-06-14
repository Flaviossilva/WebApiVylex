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
    public class EstudanteControllerTests
    {
        private readonly Mock<IEstudanteRepository> _mockEstudanteRepo;
        private readonly EstudanteController _controller;

        public EstudanteControllerTests()
        {
            _mockEstudanteRepo = new Mock<IEstudanteRepository>();
            _controller = new EstudanteController(_mockEstudanteRepo.Object);
        }

        [Fact]
        public async Task GetEstudantes_ReturnsOkResult_WithListOfEstudantes()
        {
            // Arrange
            var estudantes = new List<Estudante> { new Estudante { Id = 1, Nome = "Estudante Teste", Email = "teste@teste.com" } };
            _mockEstudanteRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(estudantes);

            // Act
            var result = await _controller.GetEstudantes();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnEstudantes = Assert.IsType<List<Estudante>>(okResult.Value);
            Assert.Single(returnEstudantes);
        }

        [Fact]
        public async Task GetEstudante_ReturnsNotFound_WhenEstudanteDoesNotExist()
        {
            // Arrange
            _mockEstudanteRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Estudante)null);

            // Act
            var result = await _controller.GetEstudante(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetEstudante_ReturnsOkResult_WithEstudante()
        {
            // Arrange
            var estudante = new Estudante { Id = 1, Nome = "Estudante Teste", Email = "teste@teste.com" };
            _mockEstudanteRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(estudante);

            // Act
            var result = await _controller.GetEstudante(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnEstudante = Assert.IsType<Estudante>(okResult.Value);
            Assert.Equal(1, returnEstudante.Id);
        }
    }
}
