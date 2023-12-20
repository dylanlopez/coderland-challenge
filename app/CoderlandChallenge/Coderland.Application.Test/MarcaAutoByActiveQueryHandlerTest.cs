using AutoMapper;
using Coderland.Application.Handlers.Queries;
using Coderland.Application.Interfaces.Repositories;
using Coderland.Domain.Dtos.Requests;
using Coderland.Domain.Dtos.Responses;
using Coderland.Domain.Entities;
using FluentAssertions;
using Moq;
using System.Linq.Expressions;

namespace Coderland.Application.Test
{
	public class MarcaAutoByActiveQueryHandlerTest
	{
		private readonly Mock<IMarcaAutoRepository> _mockRepository;
		private readonly Mock<IMapper> _mockMapper;
		private readonly MarcaAutoByActiveQueryHandler _handler;

		public MarcaAutoByActiveQueryHandlerTest()
		{
			_mockRepository = new Mock<IMarcaAutoRepository>();
			_mockMapper = new Mock<IMapper>();
			_handler = new MarcaAutoByActiveQueryHandler(_mockRepository.Object, _mockMapper.Object);
		}

		[Theory]
		[InlineData(1, "Toyota", "Japon", true)]
		public async Task Handle_Ok(int id, string nombre, string paisOrigen, bool estaActivo)
		{
			// Arrange
			var request = new MarcaAutoByActiveQueryRequest { EstaActivo = true };
			var product = new MarcaAuto
			{
				Id = id,
				Nombre = nombre,
				PaisOrigen = paisOrigen,
				EstaActivo = estaActivo
			};
			var responseDto = new List<MarcaAutoByActiveQueryResponse>();

			_mockRepository.Setup(r => r.GetMarcaAutoBy(It.IsAny<Expression<Func<MarcaAuto, bool>>>(), It.IsAny<bool>()))
				.Returns(new List<MarcaAuto> { product }.AsQueryable());

			_mockMapper.Setup(m => m.Map<List<MarcaAutoByActiveQueryResponse>>(It.IsAny<List<MarcaAuto>>()))
				.Returns(responseDto);

			// Act
			var response = await _handler.Handle(request, CancellationToken.None);

			// Assert
			response.Should().NotBeNull();
			response.State.Should().Be(200);
			response.Message.Should().Be("Ok");
			response.Value.Should().NotBeNull();
		}

		[Theory]
		[InlineData(0)]
		[InlineData(99)]
		public async Task Handle_ErrorValidation(int productId)
		{
			// Arrange
			var request = new MarcaAutoByActiveQueryRequest { EstaActivo = true };

			// Act
			var response = await _handler.Handle(request, CancellationToken.None);

			// Assert
			response.Should().NotBeNull();
			response.State.Should().Be(400);
			response.Message.Should().Contain("No se encontró el registro");
			response.Value.Should().BeNull();
		}

		[Fact]
		public async Task Handle_Error()
		{
			// Arrange
			var request = new MarcaAutoByActiveQueryRequest();

			_mockRepository.Setup(r => r.GetMarcaAutoBy(It.IsAny<Expression<Func<MarcaAuto, bool>>>(), It.IsAny<bool>()))
				.Throws(new Exception("Database error"));

			// Act
			var response = await _handler.Handle(request, CancellationToken.None);

			// Assert
			response.Should().NotBeNull();
			response.State.Should().Be(500);
			response.Message.Should().Contain("Error interno en el servidor:");
			response.Value.Should().BeNull();
		}
	}
}