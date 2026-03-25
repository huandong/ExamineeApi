using ExamineeApi.Models;
using ExamineeApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamineeApi.Controllers;

/// <summary>
/// 考生生成及重排API
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ExamineeController : ControllerBase
{
    private readonly IExamineeService _examineeService;

    public ExamineeController(IExamineeService examineeService)
    {
        _examineeService = examineeService;
    }

    /// <summary>
    /// 随机生成20+考生列表
    /// </summary>
    [HttpGet("generate")]
    public ApiResult<List<string>> Generate()
    {
        var list = _examineeService.GenerateExaminees();
        return ApiResult<List<string>>.Success(list, $"生成{list.Count}名考生成功");
    }

    /// <summary>
    /// 重排考生
    /// </summary>
    /// <param name="list">考生列表</param>
    [HttpGet("rearrange")]
    public ApiResult<List<string>> Rearrange([FromQuery] List<string> list)
    {
        var result = _examineeService.RearrangeExaminees(list);
        return ApiResult<List<string>>.Success(result, "考生重排成功");
    }
}