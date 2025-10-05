using AutoBogus;
using AwesomeFiles.Application.Services.GetAllFiles;

namespace AwesomeFiles.UnitTests.Fakers;

public static class GetAllFilesResponseFaker
{
    public static GetAllFilesResponse Generate()
    {
        return new AutoFaker<GetAllFilesResponse>()
            .RuleFor(x => x.Exception, _ => null)
            .Generate();
    }
}