
using Moq;
using SuperHeroWeb.Business.Interfaces;
using SuperHeroWeb.Controllers;
using SuperHeroWeb.Models;
using Xunit;


namespace SuperHeroWeb.Tests
{
    public class SuperHeroControllerTests
    {
        private readonly Mock<ISuperHeroService> _mockSuperHeroService;
        private readonly SuperHeroController _controller;

        public SuperHeroControllerTests()
        {
            _mockSuperHeroService = new Mock<ISuperHeroService>();
            _controller = new SuperHeroController(_mockSuperHeroService.Object);
        }

        [Fact]
        public void GetAllSuperHeros_OkResult()
        {
            // Arrange
            var superHeros = new List<SuperHero>
            {
                new SuperHero { Id = 1, Name = "Superman", SuperPowers = "Super strength, flight, heat vision", Team = "Justice League", Level = 10 },
                new SuperHero { Id = 2, Name = "Batman", SuperPowers = "Intelligence, fighting skills", Team = "Justice League", Level = 9 }
            };

            _mockSuperHeroService.Setup(service => service.GetAllSuperHeros()).Returns(superHeros);

            // Act
            var result = _controller.GetAllSuperHeros();

            // Assert
            Assert.NotNull(result);
            _mockSuperHeroService.Verify(x => x.GetAllSuperHeros(), Times.Once);
        }


    }
}
