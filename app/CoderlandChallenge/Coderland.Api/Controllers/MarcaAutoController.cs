using Microsoft.AspNetCore.Mvc;
using System.Net;
using MediatR;
using Coderland.Domain.Dtos.Responses;
using Coderland.Domain.Dtos.Requests;

namespace Coderland.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class MarcaAutoController : ControllerBase
	{
		private readonly IMediator _mediator;

		public MarcaAutoController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[ProducesResponseType(typeof(Response<MarcaAutoByActiveQueryResponse>), (int)HttpStatusCode.OK)]
		[ProducesResponseType(typeof(Response<MarcaAutoByActiveQueryResponse>), (int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> GetActives()
		{
			var request = new MarcaAutoByActiveQueryRequest()
			{
				EstaActivo = true
			};
			var result = await _mediator.Send(request);
			if (result.State == 400)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}
	}
}
