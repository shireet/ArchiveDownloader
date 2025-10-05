using AutoBogus;
using AwesomeFiles.Application.Services.GetAllFiles;

namespace AwesomeFiles.UnitTests.Fakers;

public static class GetAllFilesRequestFaker
{
    public static GetAllFilesRequest Generate()
    {
        return new AutoFaker<GetAllFilesRequest>().Generate();
    }
}