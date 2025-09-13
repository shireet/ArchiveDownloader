using AutoBogus;
using AwesomeFiles.BLL.Services.GetAllFiles;

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