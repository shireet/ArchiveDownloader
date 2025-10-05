using MediatR;

namespace AwesomeFiles.Application.Services.GetAllFiles;

public sealed record GetAllFilesRequest() : IRequest<GetAllFilesResponse>;