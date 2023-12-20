using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Coderland.Api.HealthChecks
{
	public class CoderlandHealthCheck : IHealthCheck
	{
		public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
		{
			var isOK = true;
			//isOK = Random.Shared.Next(0, 100) % 2 == 0;

			if (isOK)
			{
				return Task.FromResult(HealthCheckResult.Healthy());
			}
			else
			{
				return Task.FromResult(HealthCheckResult.Unhealthy());
			}
		}
	}
}
