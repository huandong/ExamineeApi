using ExamineeApi.Services;
using Xunit;

namespace ExamineeApi.Tests;

public class ExamineeServiceTests
{
    private readonly IExamineeService _service = new ExamineeService();

    #region 生成考生
    [Fact]
    public void GenerateExaminees_Test()
    {
        // 执行
        var result = _service.GenerateExaminees();

        Assert.True(result.Count >= 20);
        Assert.All(result, x => Assert.StartsWith("L", x));
    }
    #endregion

    #region 重排规则
    [Fact]
    public void RearrangeExaminees_Test()
    {
        var original = new List<string> { "L0", "L1", "L2", "L3", "L4" };
        var expected = new List<string> { "L0", "L4", "L1", "L3", "L2" };

        // 执行
        var result = _service.RearrangeExaminees(original);

        Assert.Equal(expected, result);
    }
    #endregion
}