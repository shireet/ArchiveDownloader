using AwesomeFiles.Domain.Exceptions;
using AwesomeFiles.Presentation.Mappers;
using AwesomeFiles.Presentation.Models.Dtos;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GetAllFilesResponse = AwesomeFiles.Presentation.Models.Dtos.GetAllFilesResponse;

namespace AwesomeFiles.Presentation.Controller.v1;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class AwesomeFilesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllFilesAsync(CancellationToken cancellationToken)
    {
        var getAllFilesRequest = new Application.Services.GetAllFiles.GetAllFilesRequest();
        var getAllFilesResponse = await mediator.Send(getAllFilesRequest, cancellationToken);
        
        return getAllFilesResponse.Successful
            ? Ok(new GetAllFilesResponse(getAllFilesResponse.FileNames!))
            : StatusCode(500, new GetAllFilesResponse(getAllFilesResponse.Exception!.Message));
    }
    [HttpPost]
    public async Task<IActionResult> StartArchiveAsync([CustomizeValidator]StartArchiveRequest request, CancellationToken cancellationToken)
    {
        var startArchiveRequest = new Application.Services.StartArchive.StartArchiveRequest(request.FileNames.Select(x => x).ToList());
        var startArchiveResponse = await mediator.Send(startArchiveRequest, cancellationToken);

        return startArchiveResponse.Successful
            ? Ok(new StartArchiveResponse(startArchiveResponse.Id))
            : startArchiveResponse.Exception is BusinessException
                ? NotFound(new StartArchiveResponse(startArchiveResponse.Exception.Message))
                : StatusCode(500, new StartArchiveResponse(startArchiveResponse.Exception!.Message));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetArchiveTaskStatusAsync(Guid id, CancellationToken cancellationToken)
    {
        var getArchiveTaskStatusRequest = new Application.Services.GetArchiveTaskStatus.GetArchiveTaskStatusRequest(id);
        var getArchiveTaskStatusResponse = await mediator.Send(getArchiveTaskStatusRequest, cancellationToken);
        
        return getArchiveTaskStatusResponse.Successful
            ? Ok(getArchiveTaskStatusResponse.ToGetArchiveTaskStatusResponse())
            : getArchiveTaskStatusResponse.Exception is BusinessException
                ? NotFound(new ArchiveTaskStatusResponse(getArchiveTaskStatusResponse.Exception.Message))
                : StatusCode(500, new ArchiveTaskStatusResponse(getArchiveTaskStatusResponse.Exception!.Message));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetArchiveAsync(Guid id,  CancellationToken cancellationToken)
    {
        var getArchiveRequest = new Application.Services.GetArchive.GetArchiveRequest(id);
        var getArchiveResponse = await mediator.Send(getArchiveRequest, cancellationToken);
        
        if (!getArchiveResponse.Successful)
            return getArchiveResponse.Exception is BusinessException
                ? NotFound(null)
                : StatusCode(500, null);
        
        var fileName = $"archive_{id}.zip";
        return File(getArchiveResponse.Archive!, "application/zip", fileName);
    }
}