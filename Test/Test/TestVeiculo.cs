using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Controllers;

namespace Tests.Test
{
    [TestClass]
    public class TestVeiculo
    {
        private Mock<InterfaceVeiculoApp> _mockApp;
        private VeiculoController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockApp = new Mock<InterfaceVeiculoApp>();
            _controller = new VeiculoController(_mockApp.Object);
        }

        [TestMethod]
        public async Task GetAll_DeveRetornarOkComListaDeVeiculos()
        {
            // Arrange
            var veiculos = new List<Veiculo>
            {
                new Veiculo { Id = 1, Modelo = "Gol", Placa = "ABC1234", GrupoId = 1 },
                new Veiculo { Id = 2, Modelo = "Civic", Placa = "XYZ9876", GrupoId = 2 }
            };

            _mockApp.Setup(x => x.GetAllAsync()).ReturnsAsync(veiculos);

            // Act
            var resultado = await _controller.GetAll();

            // Assert
            var okResult = resultado.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(veiculos, okResult.Value);
        }

        [TestMethod]
        public async Task GetById_IdInvalido_DeveRetornarBadRequest()
        {
            // Act
            var resultado = await _controller.GetById(0);

            // Assert
            var badRequest = resultado.Result as BadRequestObjectResult;
            Assert.IsNotNull(badRequest);
            Assert.AreEqual("O ID informado é inválido.", badRequest.Value);
        }

        [TestMethod]
        public async Task GetById_VeiculoNaoExiste_DeveRetornarNotFound()
        {
            // Arrange
            _mockApp.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Veiculo?)null);

            // Act
            var resultado = await _controller.GetById(10);

            // Assert
            var notFound = resultado.Result as NotFoundObjectResult;
            Assert.IsNotNull(notFound);
            Assert.AreEqual("Veículo não encontrado.", notFound.Value);
        }

        [TestMethod]
        public async Task GetById_Valido_DeveRetornarOk()
        {
            // Arrange
            var veiculo = new Veiculo { Id = 1, Modelo = "Onix", Placa = "DEF5678", GrupoId = 1 };
            _mockApp.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(veiculo);

            // Act
            var resultado = await _controller.GetById(1);

            // Assert
            var ok = resultado.Result as OkObjectResult;
            Assert.IsNotNull(ok);
            Assert.AreEqual(veiculo, ok.Value);
        }

        [TestMethod]
        public async Task Delete_VeiculoNaoExiste_DeveRetornarNotFound()
        {
            // Arrange
            _mockApp.Setup(x => x.GetByIdAsync(99)).ReturnsAsync((Veiculo?)null);

            // Act
            var resultado = await _controller.Delete(99);

            // Assert
            var notFound = resultado.Result as NotFoundObjectResult;
            Assert.IsNotNull(notFound);
            Assert.AreEqual("Veículo não encontrado.", notFound.Value);
        }

        [TestMethod]
        public async Task Delete_VeiculoExiste_DeveRetornarNoContent()
        {
            // Arrange
            var veiculo = new Veiculo { Id = 1, Modelo = "Palio", Placa = "KLM1234", GrupoId = 1 };
            _mockApp.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(veiculo);

            // Act
            var resultado = await _controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(resultado.Result, typeof(NoContentResult));
            _mockApp.Verify(x => x.DeleteAsync(veiculo), Times.Once);
        }
    }
}
