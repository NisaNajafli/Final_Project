using Microsoft.AspNetCore.Http;

namespace DataAccess.Abstracts;

public interface IAzureFileService
{
    public  Task<string> UploadAsync(IFormFile blob);
}
