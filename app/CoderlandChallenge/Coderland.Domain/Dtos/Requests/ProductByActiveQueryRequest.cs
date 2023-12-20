using Coderland.Domain.Dtos.Responses;
using MediatR;

namespace Coderland.Domain.Dtos.Requests
{
	public class MarcaAutoByActiveQueryRequest : IRequest<Response<List<MarcaAutoByActiveQueryResponse>>>
	{
		public bool EstaActivo { get; set; }
	}
}
