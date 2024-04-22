using Application.Services.ImageService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.ImageService;
public class AmazonImageServiceAdapter : ImageServiceBase
{
    public override Task DeleteAsync(string imageUrl)
    {
        // AWS bağlantı kodları..
        throw new NotImplementedException();
    }

    public override Task<string> UploadAsync(IFormFile formFile)
    {
        // AWS bağlantı kodları..
        throw new NotImplementedException();
    }
}
