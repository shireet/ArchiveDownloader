using AwesomeFiles.DAL.Interfaces;
using MediatR;

namespace AwesomeFiles.BLL.Services.GetAllFiles;

public class GetAllFilesHandler(
    IFileRepository fileRepository
    ) : IRequestHandler<GetAllFilesRequest, GetAllFilesResponse>
{
    public async Task<GetAllFilesResponse> Handle(GetAllFilesRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var fileNames = await fileRepository.GetAllNamesAsync(cancellationToken);
            return new GetAllFilesResponse(fileNames);
        }
        catch (Exception e)
        {
            throw;
        }
    }
}