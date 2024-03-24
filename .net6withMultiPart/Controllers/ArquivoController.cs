using System;
using arquivoApi.Interfaces;
using arquivoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace arquivoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ArquivoController : ControllerBase
{
    private readonly IFileService _arquivoService;

    public ArquivoController(IFileService arquivoService)
    {
        _arquivoService = arquivoService ?? throw new ArgumentNullException(nameof(arquivoService));
    }

    /// <summary>
    /// Multiple File Upload
    /// </summary>
    /// <param name="fileData"></param>
    /// <returns></returns>
    [HttpPost("UploadFile")]
    public ActionResult PostMultiFile([FromForm] FileUploadModel fileData)
    {
        if (fileData == null) return BadRequest();

        _arquivoService.PostMultiFileAsync(fileData);
        return Ok();
    }

    /// <summary>
    /// Multiple File Download
    /// </summary>
    /// <returns></returns>
    [HttpGet("DownloadFile")]
    public ActionResult GetFileAsync() 
    {
        var memoryStream = new System.IO.MemoryStream();

        _arquivoService.GetFileAsync(memoryStream);

        FileStreamResult fs = new(memoryStream, "application/zip")
        {
            FileDownloadName = "files.zip"
        };

        return fs;
    }
}
