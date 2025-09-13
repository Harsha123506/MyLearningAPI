using My_new_API.Models;

namespace My_new_API.Repositories.Interfaces
{
    public interface IImageRepository
    {
        public Task<Image> UploadImageAsync(Image image);
    }
}
