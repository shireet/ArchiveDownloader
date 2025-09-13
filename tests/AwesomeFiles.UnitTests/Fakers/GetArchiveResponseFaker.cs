using AutoBogus;
using AwesomeFiles.BLL.Services.GetArchive;
using Bogus;

namespace AwesomeFiles.UnitTests.Fakers;

public static class GetArchiveResponseFaker
{
    public static GetArchiveResponse Generate()
    {
        return new GetArchiveResponse(GenerateRandomFile());
    }

    private static FileStream GenerateRandomFile()
    {
        var tempFilePath = Path.GetTempFileName();
    
        var faker = new Faker();
        var randomContent = faker.Lorem.Paragraphs(3); 
    
        
        File.WriteAllText(tempFilePath, randomContent);
        
        return new FileStream(tempFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.DeleteOnClose);
    }
}