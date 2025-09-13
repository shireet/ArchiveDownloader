using AutoBogus;
using AwesomeFiles.BLL.Services.GetAllFiles;

namespace AwesomeFiles.UnitTests.Fakers;

public static class GetAllFilesRequestFaker
{
    public static GetAllFilesRequest Generate()
    {
        return new AutoFaker<GetAllFilesRequest>().Generate();
    }
}