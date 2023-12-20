using Coderland.Application.Interfaces.Repositories;
using Coderland.Domain.Entities;
using Coderland.Infrastructure.Persistence;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Coderland.Infrastructure.Repositories
{
	public class MarcaAutoRepository : IMarcaAutoRepository
	{
		private readonly CoderlandDBContext _contextFactory;

		public MarcaAutoRepository(CoderlandDBContext contextFactory) => _contextFactory = contextFactory;

		public IQueryable<MarcaAuto> Query(bool asNoTracking = true)
		{
			var result = asNoTracking ? _contextFactory.MarcasAutos.AsNoTracking() : _contextFactory.MarcasAutos;
			return result;
		}

		public IQueryable<MarcaAuto> GetMarcaAutoBy(Expression<Func<MarcaAuto, bool>> predicate, bool asNoTracking = false)
		{
			try
			{
				var result = Query(asNoTracking)
						.Where(predicate);
				return result;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return null;
			}
		}
	}
}
