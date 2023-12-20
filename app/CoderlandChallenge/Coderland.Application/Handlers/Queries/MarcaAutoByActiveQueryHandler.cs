using AutoMapper;
using Coderland.Application.Interfaces.Repositories;
using Coderland.Domain.Dtos.Requests;
using Coderland.Domain.Dtos.Responses;
using MediatR;

namespace Coderland.Application.Handlers.Queries
{
	public class MarcaAutoByActiveQueryHandler : IRequestHandler<MarcaAutoByActiveQueryRequest, Response<List<MarcaAutoByActiveQueryResponse>>>
	{
		private readonly IMarcaAutoRepository _repository;
		private readonly IMapper _mapper;

		public MarcaAutoByActiveQueryHandler(IMarcaAutoRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public Task<Response<List<MarcaAutoByActiveQueryResponse>>> Handle(MarcaAutoByActiveQueryRequest request, CancellationToken cancellationToken)
		{
			var response = new Response<List<MarcaAutoByActiveQueryResponse>>();
			var result = new List<MarcaAutoByActiveQueryResponse>();

			try
			{
				var resultGetProductsBy = _repository.GetMarcaAutoBy(q => q.EstaActivo == request.EstaActivo).ToList();

				if (resultGetProductsBy == null || resultGetProductsBy.Count <= 0)
				{
					response.ResultError("No se encontró el registro");
					return Task.FromResult(response);
				}

				result = _mapper.Map<List<MarcaAutoByActiveQueryResponse>>(resultGetProductsBy);

				response.ResultOk(result);
			}
			catch (Exception ex)
			{
				response.State = 500;
				response.Message = $"Error interno en el servidor: {ex.Message}";
			}

			return Task.FromResult(response);
		}
	}
}
