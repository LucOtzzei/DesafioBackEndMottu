using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Interfaces.IService
{
    public interface IFileService
    {
        Task<string> SaveAsync(Stream fileStream, string fileName);
    }
}
