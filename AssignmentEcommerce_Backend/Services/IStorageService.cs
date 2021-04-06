using System.IO;
using System.Threading.Tasks;

namespace AssignmentEcommerce_Backend.Services
{
    public interface IStorageService
    {
        string GetFileUrl(string fileName);

        Task SaveFileAsync(Stream mediaBinaryStream, string fileName);

        Task DeleteFileAsync(string fileName);
    }
}
