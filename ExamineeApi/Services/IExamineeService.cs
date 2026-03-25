namespace ExamineeApi.Services;

/// <summary>
/// 考生生成及重排接口
/// </summary>
public interface IExamineeService
{
    /// <summary>
    /// 生成20~30名随机考生
    /// </summary>
    List<string> GenerateExaminees();

    /// <summary>
    /// 重排逻辑
    /// </summary>
    List<string> RearrangeExaminees(List<string> originalList);
}