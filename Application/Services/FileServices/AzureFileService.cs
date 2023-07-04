using Azure.Storage.Blobs;
using DataAccess.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;


namespace Application.Services.FileServices;

public class AzureFileService:IAzureFileService
{
    private readonly string _storageConnectionString;
    private readonly string _storageContainerName;

    public AzureFileService(IConfiguration configuration)
    {
        _storageConnectionString = configuration["AzureConnectionString:BlobConnectionString"];
        _storageContainerName = configuration["AzureConnectionString:EmpContainerName"];

    }


    public async Task<string> UploadAsync(IFormFile blob)
    {
        BlobContainerClient container = new BlobContainerClient(_storageConnectionString, _storageContainerName);
        //await container.CreateAsync();

        string FileName = DateTime.Now.ToString() + blob.FileName;
        BlobClient client = container.GetBlobClient(FileName);

        await using (Stream? data = blob.OpenReadStream())
        {
            // Upload the file async
            await client.UploadAsync(data);
        }

            
        return client.Uri.AbsoluteUri;
    }

    public async Task DeleteAsync(string blobUri)
    {
        Uri uri = new Uri(blobUri);
        BlobContainerClient container = new BlobContainerClient(_storageConnectionString, _storageContainerName);
        BlobClient client = container.GetBlobClient(uri.Segments.Last());

        // Delete the blob
        await client.DeleteAsync();
    }



}
