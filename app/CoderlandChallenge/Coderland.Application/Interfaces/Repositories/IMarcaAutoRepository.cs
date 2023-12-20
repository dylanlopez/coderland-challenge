using Coderland.Domain.Entities;
using System.Linq.Expressions;

namespace Coderland.Application.Interfaces.Repositories
{
	public interface IMarcaAutoRepository
	{
		IQueryable<MarcaAuto> Query(bool asNoTracking = true);
		IQueryable<MarcaAuto> GetMarcaAutoBy(Expression<Func<MarcaAuto, bool>> predicate, bool asNoTracking = false);
	}
}
