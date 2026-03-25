using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ExamineeApi.HealthChecks;

/// <summary>
/// 第三方服务健康检查
/// </summary>
public class ThirdPartyHealthCheck : IHealthCheck
{
    private readonly HttpClient _httpClient;

    public ThirdPartyHealthCheck(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _httpClient.GetAsync("http://open.api.tianyancha.com/services/open/ic/baseinfo/normal?keyword=中航重机股份有限公司", cancellationToken);
            return response.IsSuccessStatusCode
                ? HealthCheckResult.Healthy("第三方服务连接正常")
                : HealthCheckResult.Unhealthy("第三方服务连接失败");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy("第三方服务检查异常", ex);
        }
    }
}