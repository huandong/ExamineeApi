namespace ExamineeApi.Services;

/// <summary>
/// 考生生成及重排实现
/// </summary>
public class ExamineeService : IExamineeService
{
    private readonly Random _random = new();

    /// <summary>
    /// 生成20~30名随机考生
    /// </summary>
    public List<string> GenerateExaminees()
    {
        // 随机数量：20 - 30 人
        int count = _random.Next(20, 31);
        return Enumerable.Range(0, count).Select(i => $"L{i}").ToList();
    }

    /// <summary>
    /// 重排逻辑
    /// </summary>
    public List<string> RearrangeExaminees(List<string> oldList)
    {
        if (oldList == null || oldList.Count <= 0)
            return new List<string>();

        List<string> newList = new List<string>();
        int s = 0;
        int e = oldList.Count - 1;

        while (s <= e)
        {
            newList.Add(oldList[s]);
            s++;

            if (s <= e)
            {
                newList.Add(oldList[e]);
                e--;
            }
        }

        return newList;
    }
}