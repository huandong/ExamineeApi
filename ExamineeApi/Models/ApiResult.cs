namespace ExamineeApi.Models;

/// <summary>
/// 全局统一API响应模型
/// </summary>
/// <typeparam name="T">数据类型</typeparam>
public class ApiResult<T>
{
    /// <summary>
    /// 响应状态码（200=成功，500=服务器错误）
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// 响应消息
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// 响应数据
    /// </summary>
    public T? Data { get; set; }

    #region 静态方法
    public static ApiResult<T> Success(T? data, string message = "操作成功")
    {
        return new ApiResult<T> { Code = 200, Message = message, Data = data };
    }

    public static ApiResult<T> Fail(string message, int code = 500)
    {
        return new ApiResult<T> { Code = code, Message = message };
    }
    #endregion
}