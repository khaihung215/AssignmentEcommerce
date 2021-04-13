using AssignmentEcommerce_Backend.Services;
using Moq;

namespace AssignmentEcommerce_Test.Services
{
    public static class FileStorageService
    {
        public static IStorageService IStorageService()
        {
            var fileStorageService = Mock.Of<IStorageService>();

            return fileStorageService;
        }
    }
}
