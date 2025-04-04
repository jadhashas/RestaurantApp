using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Application.Interfaces;

namespace RestaurantApp.Infrastructure.Services
{
    public class ImageUploadService : IImageUploadService
    {
        private readonly long _maxFileSize = 2 * 1024 * 1024; // 2 Mo
        private readonly string[] _allowedMimeTypes = ["image/jpeg", "image/png", "image/gif"];
        private readonly string[] _allowedExtensions = [".jpg", ".jpeg", ".png", ".gif"];
        private readonly string _uploadPath = Path.Combine("wwwroot", "uploads");

        public async Task<string?> UploadAsync(Stream fileStream, string contentType, string originalFileName)
        {
            if (!_allowedMimeTypes.Contains(contentType.ToLower()))
                throw new InvalidDataException("Format d'image non supporté.");

            if (fileStream.Length > _maxFileSize)
                throw new InvalidDataException("Fichier trop volumineux (max 2 Mo).");

            var ext = Path.GetExtension(originalFileName).ToLowerInvariant();
            if (!_allowedExtensions.Contains(ext))
                throw new InvalidDataException("Extension non autorisée.");

            var fileHash = await ComputeFileHashAsync(fileStream);
            var fileName = $"{fileHash}{ext}";
            var filePath = Path.Combine(_uploadPath, fileName);

            if (!File.Exists(filePath))
            {
                fileStream.Position = 0;
                using var fs = new FileStream(filePath, FileMode.Create);
                await fileStream.CopyToAsync(fs);
            }

            return $"/uploads/{fileName}";
        }


        private async Task<string> ComputeFileHashAsync(Stream stream)
        {
            using var sha256 = SHA256.Create();
            stream.Position = 0;
            var hash = await sha256.ComputeHashAsync(stream);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
