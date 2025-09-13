using MediatR;

namespace AwesomeFiles.BLL.Services.GetAllFiles;

public sealed record GetAllFilesRequest() : IRequest<GetAllFilesResponse>;