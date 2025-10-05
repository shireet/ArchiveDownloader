using AutoBogus;
using AwesomeFiles.Application.Services.GetArchive;

namespace AwesomeFiles.UnitTests.Fakers;

public static class GetArchiveRequestFaker
{
    public static GetArchiveRequest Generate()
    {
        return new AutoFaker<GetArchiveRequest>().Generate();
    }

    public static GetArchiveRequest WithId(this GetArchiveRequest request, Guid id)
    {
        return new GetArchiveRequest(id);
    }
}