using My_new_API.Data;
using My_new_API.Models;
using My_new_API.Repositories.Interfaces;

namespace My_new_API.Repositories
{
    public class ImageRepository:IImageRepository
    {
        public readonly IWebHostEnvironment _webHostEnvironment;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly DataContext _dataContext;
        public ImageRepository(IWebHostEnvironment webHostEnvironment,IHttpContextAccessor httpContextAccessor,DataContext dataContext) {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _dataContext = dataContext;
        }
        public async Task<Image> UploadImageAsync(Image image)
        {
            string localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images" + image.FileName + image.FileExtension);
            using (var stream = new FileStream(localFilePath, FileMode.Create))
            {
                await image.File.CopyToAsync(stream); // save in specified path in server
            }
            var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}/{image.FileExtension}";
            image.FilePath = urlFilePath;
            await _dataContext.images.AddAsync(image);
            await _dataContext.SaveChangesAsync();
            return image;
        }
    }
}