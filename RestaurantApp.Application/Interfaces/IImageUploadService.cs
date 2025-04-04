using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Application.Interfaces
{
    public interface IImageUploadService
    {
        Task<string?> UploadAsync(Stream fileStream, string contentType, string originalFileName);
    }
}
