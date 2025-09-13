using AutoBogus;
using AwesomeFiles.BLL.Services.GetArchiveTaskStatus;

namespace AwesomeFiles.UnitTests.Fakers;

public static class GetArchiveTaskStatusRequestFaker
{
    public static GetArchiveTaskStatusRequest Generate()
    {
        return new AutoFaker<GetArchiveTaskStatusRequest>().Generate();
    }
}