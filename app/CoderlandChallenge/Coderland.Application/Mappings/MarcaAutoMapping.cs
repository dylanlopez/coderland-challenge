using AutoMapper;
using Coderland.Domain.Dtos.Responses;
using Coderland.Domain.Entities;

namespace Coderland.Application.Mappings
{
	public class MarcaAutoMapping : Profile
	{
		public MarcaAutoMapping()
		{
			CreateMap<MarcaAuto, MarcaAutoByActiveQueryResponse>();
		}
	}
}
