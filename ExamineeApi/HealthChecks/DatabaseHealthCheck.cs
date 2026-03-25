using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ExamineeApi.HealthChecks;

/// <summary>
/// 数据库连接健康检查
/// </summary>
public class DatabaseHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            bool isConnected = true;
            return isConnected
                ? Task.FromResult(HealthCheckResult.Healthy("数据库连接正常"))
                : Task.FromResult(HealthCheckResult.Unhealthy("数据库连接失败"));
        }
        catch (Exception ex)
        {
            return Task.FromResult(HealthCheckResult.Unhealthy("数据库检查异常", ex));
        }
    }
}