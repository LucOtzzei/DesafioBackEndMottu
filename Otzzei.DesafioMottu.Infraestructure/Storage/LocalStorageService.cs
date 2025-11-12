using Microsoft.Extensions.Configuration;
using OtzzeiDesafioMottu.Domain.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.DesafioMottu.Infraestructure.Storage
{
    public class LocalStorageService : IFileService
    {
        private readonly string _storagePath;

        public LocalStorageService(IConfiguration configuration)
        {
            _storagePath = configuration["Storage:Path"] ?? "uploads";
            Directory.CreateDirectory(_storagePath);
        }

        public async Task<string> SaveAsync(Stream fileStream, string fileName)
        {
            var filePath = Path.Combine(_storagePath, fileName);

            using var fileStreamOut = new FileStream(filePath, FileMode.Create);
            await fileStream.CopyToAsync(fileStreamOut);

            return filePath;
        }
    }
}